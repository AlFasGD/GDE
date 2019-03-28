using GDEdit.Utilities.Objects.GeometryDash;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GDEdit.Utilities.Objects.Scripting
{
    /// <summary>Represents a miniC# script for the editor. miniC# is a custom variation of C# for the purposes of quickly creating scripts.</summary>
    public class MiniCSharpScript : CSharpScript
    {
        // TODO: Support multiple files?

        /// <summary>Initializes a new instance of the <seealso cref="MiniCSharpScript"/> class.</summary>
        /// <param name="source">The source of the miniC# script.</param>
        public MiniCSharpScript(string source)
            : base(source)
        {

        }

        /// <summary>Initializes the script before it is compiled.</summary>
        protected override void InitializeScript()
        {
            base.InitializeScript();

            var tree = CSharpSyntaxTree.ParseText(Source);
            var root = tree.GetCompilationUnitRoot();

            // Add proper usings
            var systemNamespaces = new[]
            {
                "using System;",
                "using System.Collections.Generic;",
                "using System.Linq;",
                "using System.Text;",
            };
            var namespaces = Assembly.GetExecutingAssembly().DefinedTypes.Where(t => t.Namespace.StartsWith("GDEdit.Utilities.")).Distinct().Select(t => $"using {t.Namespace};").Concat(systemNamespaces);
            var usings = namespaces.Select(n => UsingDirective(IdentifierName(n))).ToArray();
            root.AddUsings(usings);

            // Add script nodes into main function
            var nodes = root.ChildNodes().Where(n => DetermineKind(n.Kind()));
            bool containsMain = root.ChildNodes().Any(MatchMainFunction);
            if (nodes.Any())
            {
                // If there already exists a Main function with the same signature, an error should be thrown, since the entire code must be either in that function or not include that function at all.
                var list = NodeOrTokenList(nodes.Select(n => (SyntaxNodeOrToken)n));
                var method = GenerateMainMethod(nodes.Select(n => n as StatementSyntax).ToArray());
                root = root.AddMembers(method).RemoveNodes(nodes, SyntaxRemoveOptions.KeepNoTrivia); // Update tree?
            }
            else if (!containsMain)
            {
                root = root.AddMembers(GenerateMainMethod());
            }

            // Add functions into Program class
            var functions = root.ChildNodes().Where(n => n.IsKind(SyntaxKind.ClassDeclaration));
            if (functions.Any())
            {
                var list = NodeOrTokenList(functions.Select(n => (SyntaxNodeOrToken)n));
                var cl = GenerateProgramClass(functions.Select(n => n as MemberDeclarationSyntax).ToArray());
                root = root.AddMembers(cl).RemoveNodes(functions, SyntaxRemoveOptions.KeepNoTrivia); // Update tree?
            }

            // Add classes into namespace
            var classes = root.ChildNodes().Where(n => n.IsKind(SyntaxKind.NamespaceDeclaration));
            if (classes.Any())
            {
                var list = NodeOrTokenList(classes.Select(n => (SyntaxNodeOrToken)n));
                var ns = GenerateScriptNamespace(classes.Select(n => n as MemberDeclarationSyntax).ToArray());
                root = root.AddMembers(ns).RemoveNodes(classes, SyntaxRemoveOptions.KeepNoTrivia); // Update tree?
            }
        }

        // IMPORTANT: Seriously test this, everything is completely made up from partial documentation and brain assumptions
        private static NamespaceDeclarationSyntax GenerateScriptNamespace(params MemberDeclarationSyntax[] members)
        {
            var c = NamespaceDeclaration(ParseName("GDEdit.CustomScript"));
            return c.AddMembers(members);
        }
        private static ClassDeclarationSyntax GenerateProgramClass(params MemberDeclarationSyntax[] members)
        {
            var c = ClassDeclaration("Program");
            return c.AddModifiers(Token(StaticKeyword)).AddMembers(members);
        }
        private static MethodDeclarationSyntax GenerateMainMethod(params StatementSyntax[] statements)
        {
            var method = MethodDeclaration(ParseTypeName("void"), "Main");
            return method.AddParameterListParameters(Parameter(ParseToken("Level level"))).AddBodyStatements(statements); // Potential problem here
        }

        private static bool DetermineKind(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.ClassDeclaration:
                case SyntaxKind.StructDeclaration:
                case SyntaxKind.DelegateDeclaration:
                case SyntaxKind.InterfaceDeclaration:
                case SyntaxKind.EnumDeclaration:
                case SyntaxKind.MethodDeclaration:
                case SyntaxKind.UsingDirective:
                    return false;
                default:
                    return true;
            }
        }

        private static bool MatchNamespace(SyntaxNode n)
        {
            if (n is NamespaceDeclarationSyntax s)
            {
                if (s.Name.ToFullString() != "GDEdit.CustomScript")
                    return false;
                return true;
            }
            return false;
        }
        private static bool MatchClass(SyntaxNode n)
        {
            if (n is ClassDeclarationSyntax c)
            {
                if (c.Identifier.ToFullString() != "Program")
                    return false;
                return true;
            }
            return false;
        }
        private static bool MatchMainFunction(SyntaxNode n)
        {
            if (n is MethodDeclarationSyntax m)
            {
                // This shit looks suspicious; NEEDS TESTING
                var v = ParseTypeName("void") as SimpleNameSyntax;
                if ((m.ReturnType as SimpleNameSyntax).Identifier != v.Identifier)
                    return false;
                if (m.Identifier.ToFullString() != "Main")
                    return false;
                var paramListString = m.ParameterList.ToFullString();
                if (!paramListString.StartsWith("Level") || paramListString.Contains(","))
                    return false;
                return true;
            }
            return false;
        }

        // DO NOT DELETE, unless the tree is tested to work properly even with compiler errors in directives
        private void OldInitializeScriptImplementation()
        {
            var lines = Lines;
            int line = 0;
            int column = 0;
            bool foundUsings = false;

            // Enumerate through directives and usings
            while (!foundUsings)
            {
                string word = GetNextWord();
                if (word.StartsWith("#"))
                    continue;
                if (!(foundUsings = word != "using" && word != "extern")) // Supporting extern alias just in case
                    ForwardEnumerator(';', false, 1);
                IncrementEnumerator();
            }

            // TODO: Ensure the entire class contains a void Main(Level level) function and move any code inside

            // Contain the source code in a class to ensure 
            lines.InsertRange(0, new[]
            {
                "namespace GDEdit.CustomScript",
                "{",
                "public static class Program",
                "{",
            });
            lines.AddRange(new[]
            {
                "}",
                "}",
            });
            // Add the necessary usings
            lines.InsertRange(0, new[]
            {
                "using System;",
                "using System.Collections.Generic;",
                "using System.Linq;",
                "using System.Text;",
            });
            lines.InsertRange(0, Assembly.GetExecutingAssembly().DefinedTypes.Where(t => t.Namespace.StartsWith("GDEdit.Utilities.")).Distinct().Select(t => $"using {t.Namespace};"));

            // Subroutines
            string GetNextWord()
            {
                ForwardEnumerator(' ', true);
                int length = 0;
                while ((column + length) < lines[line].Length && lines[line][column + length] != ' ')
                    length++;
                return lines[line].Substring(column, length);
            }
            void IncrementEnumerator(int step = 1)
            {
                column += step;
                while (column >= lines[line].Length)
                    column -= lines[line++].Length;
            }
            void ForwardEnumerator(char requestedCharacter, bool forwardWhileMatchingCharacter, int skipAfter = 0)
            {
                while (lines[line][column] == requestedCharacter == forwardWhileMatchingCharacter)
                    if (++column >= lines[line].Length)
                    {
                        line++;
                        column = 0;
                    }
                IncrementEnumerator(skipAfter);
            }
        }
    }
}
