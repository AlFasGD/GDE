﻿using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;
using GDEdit.Utilities.Functions.GeometryDash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.SpecialObjects.Portals.GamemodePortals
{
    /// <summary>Represents a ball portal.</summary>
    public class BallPortal : GamemodePortal, IHasCheckedProperty
    {
        /// <summary>The object ID of the ball portal.</summary>
        public override int ObjectID => (int)ManipulationPortalType.Ball;
        /// <summary>The gamemode the gamemode portal transforms the player into.</summary>
        public override Gamemode Gamemode => Gamemode.Ball;

        /// <summary>The checked property of the ball portal that determines whether the borders of the player's gamemode will be shown or not.</summary>
        [ObjectStringMappable(ObjectParameter.PortalChecked)]
        public bool Checked { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="BallPortal"/> class.</summary>
        public BallPortal() : base() { }
    }
}
