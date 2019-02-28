﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Enumerations.GeometryDash
{
    /// <summary>This enumeration provides values for the coordinates to rely on from a position value of a trigger.</summary>
    public enum TargetPosCoordinates : byte
    {
        /// <summary>Represents the value for both coordinates.</summary>
        Both,
        /// <summary>Represents the value for only the X coordinate.</summary>
        XOnly,
        /// <summary>Represents the value for only the Y coordinate.</summary>
        YOnly
    }
}
