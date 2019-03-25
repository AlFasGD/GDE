using System.CodeDom.Compiler;
using static GDEdit.Utilities.Objects.Scripting.CompilationIssueType;

namespace GDEdit.Utilities.Objects.Scripting
{
    /// <summary>Represents a compilation issue.</summary>
    public class CompilationIssue
    {
        /// <summary>The line at which the issue occurs.</summary>
        public int Line { get; set; }
        /// <summary>The column at which the issue occurs.</summary>
        public int Column { get; set; }
        /// <summary>The code of the compilation issue.</summary>
        public string Code { get; set; }
        /// <summary>The text of the compilation issue.</summary>
        public string Text { get; set; }
        /// <summary>The type of the compilation issue.</summary>
        public CompilationIssueType Type { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="CompilationIssue"/> class.</summary>
        /// <param name="line">The line at which the issue occurs.</param>
        /// <param name="column">The column at which the issue occurs.</param>
        /// <param name="code">The code of the compilation issue.</param>
        /// <param name="text">The text of the compilation issue.</param>
        /// <param name="type">The type of the compilation issue.</param>
        public CompilationIssue(int line, int column, string code, string text, CompilationIssueType type = Error)
        {
            Line = line;
            Column = column;
            Code = code;
            Text = text;
            Type = type;
        }
        /// <summary>Initializes a new instance of the <seealso cref="CompilationIssue"/> class from a <seealso cref="CompilerError"/> instance.</summary>
        /// <param name="error">The <seealso cref="CompilerError"/> instance to create this <seealso cref="CompilationIssue"/> from.</param>
        public CompilationIssue(CompilerError error) : this(error.Line, error.Column, error.ErrorNumber, error.ErrorText, GetIssueType(error.IsWarning)) { }

        private static CompilationIssueType GetIssueType(bool isWarning) => isWarning ? Warning : Error;
    }

    /// <summary>Represets a compilation issue type.</summary>
    public enum CompilationIssueType
    {
        /// <summary>Represets a compilation error.</summary>
        Error,
        /// <summary>Represets a compilation warning.</summary>
        Warning,
        /// <summary>Represets a compilation message.</summary>
        Message,
        /// <summary>Represets a compilation suggestion.</summary>
        Suggestion,
    }
}
