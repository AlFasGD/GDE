﻿using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;
using GDEdit.Utilities.Information.GeometryDash;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects.Triggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.SpecialObjects.Orbs
{
    /// <summary>Represents a trigger orb.</summary>
    public abstract class TriggerOrb : Orb, IHasTargetGroupID
    {
        /// <summary>Represents the Target Group ID of the trigger orb.</summary>
        [ObjectStringMappable(ObjectParameter.TargetGroupID)]
        public int TargetGroupID { get; set; }
        /// <summary>Represents the Activate Group property of the trigger orb.</summary>
        [ObjectStringMappable(ObjectParameter.ActivateGroup)]
        public bool ActivateGroup { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="TriggerOrb"/> class.</summary>
        public TriggerOrb() : base() { }
    }
}
