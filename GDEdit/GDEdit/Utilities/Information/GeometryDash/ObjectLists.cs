﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Information.GeometryDash
{
    /// <summary>Contains information about the objects in the game.</summary>
    public static class ObjectLists
    {
        /// <summary>The total count of different objects in the game.</summary>
        public const int TotalDifferentObjectCount = 1607;

        /// <summary>The object IDs of all the triggers.</summary>
        public static readonly int[] TriggerList = { 29, 30, 32, 33, 105, 744, 899, 900, 901, 915, 1006, 1007, 1049, 1268, 1346, 1347, 1520, 1585, 1595, 1611, 1612, 1613, 1616, 1811, 1812, 1814, 1815, 1817, 1818, 1819 };
        /// <summary>The object IDs of all the manipulation portals.</summary>
        public static readonly int[] ManipulationPortalList = { 13, 47, 111, 1331 };
        /// <summary>The object IDs of all the speed portals.</summary>
        public static readonly int[] SpeedPortalList = { 200, 201, 202, 203, 1334 };
        /// <summary>The object IDs of all the orbs.</summary>
        public static readonly int[] OrbList = { 36, 84, 141, 1022, 1330, 1333, 1704, 1751 };
        /// <summary>The object IDs of all the pickup items.</summary>
        public static readonly int[] PickupItemList = { 1275, 1587, 1589, 1598, 1614 };
        /// <summary>The object IDs of all the pulsating objects.</summary>
        public static readonly int[] PulsatingObjectList = { 1839, 1840, 1841, 1842 };
        /// <summary>The object IDs of all the rotating objects.</summary>
        public static readonly int[] RotatingObjectList = { 85, 86, 87, 97, 137, 138, 139, 154, 155, 156, 180, 181, 182, 183, 184, 185, 186, 187, 188, 222, 223, 224, 375, 376, 377, 378, 394, 395, 396, 678, 679, 680, 740, 741, 742, 997, 998, 999, 1000, 1019, 1020, 1021, 1055, 1056, 1057, 1058, 1059, 1060, 1061, 1521, 1522, 1523, 1524, 1525, 1526, 1527, 1528, 1582, 1619, 1620, 1705, 1706, 1707, 1708, 1709, 1710, 1734, 1735, 1736, 1752, 1831, 1832, 1833, 1834 };
        /// <summary>The object IDs of all the objects that are not just general objects but cannot be categorized.</summary>
        public static readonly int[] NotGeneralObjectList = { 13, 29, 30, 32, 33, 36, 47, 84, 85, 86, 87, 97, 105, 111, 137, 138, 139, 141, 154, 155, 156, 180, 181, 182, 183, 184, 185, 186, 187, 188, 200, 201, 202, 203, 222, 223, 224, 375, 376, 377, 378, 394, 395, 396, 678, 679, 680, 740, 741, 742, 744, 899, 900, 901, 915, 997, 998, 999, 1000, 1006, 1007, 1019, 1020, 1021, 1022, 1049, 1055, 1056, 1057, 1058, 1059, 1060, 1061, 1268, 1275, 1330, 1331, 1333, 1334, 1346, 1347, 1520, 1521, 1522, 1523, 1524, 1525, 1526, 1527, 1528, 1582, 1585, 1587, 1589, 1595, 1598, 1611, 1612, 1613, 1614, 1616, 1619, 1620, 1704, 1705, 1706, 1707, 1708, 1709, 1710, 1734, 1735, 1736, 1751, 1752, 1811, 1812, 1814, 1815, 1817, 1818, 1819, 1831, 1832, 1833, 1834, 1839, 1840, 1841, 1842 };
    }
}
