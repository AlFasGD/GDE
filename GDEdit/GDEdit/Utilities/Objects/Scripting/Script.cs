using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Functions.Extensions;
using GDEdit.Utilities.Objects.GeometryDash;

namespace GDEdit.Utilities.Objects.Scripting
{
    /// <summary>Represents a script for the editor.</summary>
    public abstract class Script
    {
        private bool compilationSucceeded;
        private List<string> lines;
        private string source;

        private List<CompilationIssue> issues;

        /// <summary>The script's lines.</summary>
        protected List<string> Lines
        {
            get
            {
                if (lines == null)
                    lines = source.Split('\n').ToList();
                return lines;
            }
            set => source = (lines = value).Combine("\n");
        }
        /// <summary>The script's source code.</summary>
        protected string Source
        {
            get => source;
            set
            {
                source = value;
                lines = null;
            }
        }

        public List<CompilationIssue> Issues => issues;

        /// <summary>Initializes a new instance of the <seealso cref="Script"/> class.</summary>
        /// <param name="source">The source of the script.</param>
        public Script(string source)
        {
            Source = source;
            InitializeScript();
            compilationSucceeded = CompileScript(out issues);
        }
        /// <summary>Executes the script.</summary>
        /// <param name="level">The level to apply the script on.</param>
        public void Execute(Level level) => Execute(new[] { level });
        /// <summary>Executes the script.</summary>
        /// <param name="levels">The levels to apply the script on.</param>
        public void Execute(Level[] levels)
        {
            if (compilationSucceeded)
                ExecuteScript(levels);
        }
        /// <summary>Executes the script.</summary>
        /// <param name="levels">The levels to apply the script on.</param>
        public void Execute(List<Level> levels) => Execute(levels.ToArray());

        /// <summary>Compiles the script. Returns <see langword="true"/> if the compilation succeeded, otherwise <see langword="false"/>.</summary>
        /// <param name="errors">The errors that may have occurred during compilation.</param>
        public abstract bool CompileScript(out List<CompilationIssue> errors);

        /// <summary>Initializes the script before it is compiled.</summary>
        protected abstract void InitializeScript();
        /// <summary>Executes the script.</summary>
        /// <param name="levels">The levels to apply the script on.</param>
        protected abstract void ExecuteScript(Level[] levels);
    }
}
