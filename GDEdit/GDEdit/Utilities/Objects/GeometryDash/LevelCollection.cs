﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash
{
    /// <summary>Represents a collection of <seealso cref="Level"/>s.</summary>
    public class LevelCollection : List<Level>
    {
        /// <summary>Initializes a new instance of the <seealso cref="LevelCollection"/> class.</summary>
        public LevelCollection() : base() { }
        /// <summary>Initializes a new instance of the <seealso cref="LevelCollection"/> class.</summary>
        /// <param name="l">The list to initialize this <seealso cref="LevelCollection"/> from.</param>
        public LevelCollection(List<Level> l) : base(l) { }

        /// <summary>Returns the <seealso cref="string"/> representation of the <seealso cref="LevelCollection"/>.</summary>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("<d>");
            for (int i = 0; i < Count; i++)
                result = result.Append($"<k>k_{i}</k><d>").Append(this[i].RawLevel).Append("</d>");
            return result.Append("</d>").ToString();
        }
    }
}
