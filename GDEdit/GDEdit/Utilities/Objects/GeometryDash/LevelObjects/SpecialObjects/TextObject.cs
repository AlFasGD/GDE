﻿using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;
using GDEdit.Utilities.Information.GeometryDash;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects.Triggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.SpecialObjects
{
    /// <summary>Represents a text object.</summary>
    public class TextObject : SpecialObject
    {
        /// <summary>Represents the Text property of the text object encoded in base 64.</summary>
        [ObjectStringMappable(ObjectParameter.TextObjectText)]
        public string Base64Text => Convert.ToBase64String(Encoding.UTF8.GetBytes(Text));

        /// <summary>Represents the Text property of the text object.</summary>
        public string Text { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="TextObject"/> class.</summary>
        /// <param name="x">The X location of the object.</param>
        /// <param name="y">The Y location of the object.</param>
        /// <param name="text">The text of the text object.</param>
        public TextObject(double x, double y, string text = "")
            : base()
        {
            X = x;
            Y = y;
            Text = text;
        }
    }
}
