﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Information.GeometryDash
{
    /// <summary>Provides information about the speeds of the player in the game.</summary>
    public static class Speeds
    {
        /// <summary>The units the player moves per second with a 1.0 speed multiplier.</summary>
        public const double UnitsPerSecond = 360;

        /// <summary>The speed multiplier for the slow speed (&lt;).</summary>
        public const double SlowSpeedMultiplier = 0.7;
        /// <summary>The speed multiplier for the normal speed (&gt;).</summary>
        public const double NormalSpeedMultiplier = 0.9;
        /// <summary>The speed multiplier for the fast speed (&gt;&gt;).</summary>
        public const double FastSpeedMultiplier = 1.1;
        /// <summary>The speed multiplier for the faster speed (&gt;&gt;&gt;).</summary>
        public const double FasterSpeedMultiplier = 1.3;
        /// <summary>The speed multiplier for the very faster speed (&gt;&gt;&gt;&gt;).</summary>
        public const double VeryFasterSpeedMultiplier = 1.6;

        /// <summary>The (ESTIMATED) speed in uniits per second of the slow speed (&lt;).</summary>
        public const double SlowSpeed = 251.3;
        /// <summary>The (ESTIMATED) speed in uniits per second of the normal speed (&gt;).</summary>
        public const double NormalSpeed = 311.6;
        /// <summary>The (ESTIMATED) speed in uniits per second of the fast speed (&gt;&gt;).</summary>
        public const double FastSpeed = 387.4;
        /// <summary>The speed in uniits per second of the faster speed (&gt;&gt;&gt;).</summary>
        public const double FasterSpeed = 468;
        /// <summary>The speed in uniits per second of the very faster speed (&gt;&gt;&gt;&gt;).</summary>
        public const double VeryFasterSpeed = 576;
    }
}
