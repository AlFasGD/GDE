﻿using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.SpecialObjects.Portals
{
    /// <summary>Represents a yellow teleportation portal. Should not be available to be created through the editor.</summary>
    [NonGeneratable("Cannot create an instance of the yellow teleportation portal without assigning it to a blue teleportation portal.")]
    [ObjectID(PortalType.YellowTeleportation)]
    public class YellowTeleportationPortal : Portal
    {
        // This is static to avoid getting the exact same value more than once
        private static readonly PropertyInfo[] properties = typeof(GeneralObject).GetProperties();

        /// <summary>The blue teleportation portal to which this belongs.</summary>
        public readonly BlueTeleportationPortal LinkedTeleportationPortal;

        /// <summary>The object ID of the yellow teleportation portal.</summary>
        public override int ObjectID => (int)PortalType.YellowTeleportation;

        /// <summary>Initializes a new instance of the <seealso cref="YellowTeleportationPortal"/> class.</summary>
        public YellowTeleportationPortal(BlueTeleportationPortal p)
            : base()
        {
            LinkedTeleportationPortal = p;
            SetProperties(p);
        }

        /// <summary>Returns a clone of this <seealso cref="YellowTeleportationPortal"/>.</summary>
        public override GeneralObject Clone() => new YellowTeleportationPortal(LinkedTeleportationPortal);

        // Do not override EqualsInherited to avoid recursion when comparing the parent blue teleportation portal
        /// <summary>Determines whether this object's type is the same as another object's type</summary>
        /// <param name="other">The other object to check whether its type is the same as this one's.</param>
        protected override bool EqualsType(GeneralObject other) => other is YellowTeleportationPortal;

        /// <summary>Sets the properties of this <seealso cref="YellowTeleportationPortal"/> according to the linked <seealso cref="BlueTeleportationPortal"/>.</summary>
        private void SetProperties(BlueTeleportationPortal a)
        {
            foreach (var p in properties)
                p.SetValue(this, p.GetValue(a));
            Y = a.Y + a.YellowTeleportationPortalDistance;
            Rotation = a.Rotation;
        }
    }
}
