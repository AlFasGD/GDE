﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.Triggers.Interfaces
{
    /// <summary>Represents a trigger which contains a definition for the color.</summary>
    public interface IHasColor
    {
        /// <summary>The red part of the color.</summary>
        [ObjectStringMappable(ObjectParameter.Red)]
        byte Red { get; set; }
        /// <summary>The green part of the color.</summary>
        [ObjectStringMappable(ObjectParameter.Green)]
        byte Green { get; set; }
        /// <summary>The blue part of the color.</summary>
        [ObjectStringMappable(ObjectParameter.Blue)]
        byte Blue { get; set; }
    }
}
