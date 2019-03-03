﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.SpecialObjects.Portals
{
    /// <summary>Represents a portal object.</summary>
    public abstract class Portal : SpecialObject
    {
        /// <summary>The object ID of the portal.</summary>
        public new abstract int ObjectID { get; }

        /// <summary>Initializes a new instance of the <seealso cref="Portal"/> class.</summary>
        public Portal()
            : base()
        {
            base.ObjectID = ObjectID;
        }
    }
}
