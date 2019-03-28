using GDEdit.Utilities.Objects.GeometryDash;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GDEdit.Utilities.Objects.Scripting
{
    /// <summary>Represents a C# script for the editor.</summary>
    public class CSharpScript : Script
    {
        // TODO: Support multiple files?

        private Assembly assembly;
        /// <summary>Initializes a new instance of the <seealso cref="CSharpScript"/> class.</summary>
        /// <param name="source">The source of the C# script.</param>
        public CSharpScript(string source)
            : base(source)
        {

        }

        /// <summary>Compiles the script. Returns <see langword="true"/> if the compilation succeeded, otherwise <see langword="false"/>.</summary>
        public override bool CompileScript(out List<CompilationIssue> errors)
        {
            CSharpCodeProvider c = new CSharpCodeProvider();
            var parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                OutputAssembly = "GDEdit.EditorScript",
            };
            parameters.ReferencedAssemblies.Add("GDEdit");
            var r = c.CompileAssemblyFromSource(parameters, new[] { Source });
            assembly = r.CompiledAssembly;
            errors = new List<CompilationIssue>();
            foreach (CompilerError e in r.Errors)
                errors.Add(new CompilationIssue(e));
            return r.Errors.HasErrors;
        }
        /// <summary>Initializes the script before it is compiled.</summary>
        protected override void InitializeScript()
        {
            base.InitializeScript();
        }
        /// <summary>Executes the script.</summary>
        /// <param name="level">The level to apply the script on.</param>
        protected override void ExecuteScript(Level[] levels)
        {
            MethodInfo main = null;
            assembly.DefinedTypes.ToList().Find(t => MatchMain(t, out main));
            if (main != null)
                main.Invoke(null, levels);
        }

        private static bool MatchMain(TypeInfo info, out MethodInfo main)
        {
            main = info.GetMethod("Main", new[] { typeof(Level[]) });
            return main != null;
        }
    }
}
