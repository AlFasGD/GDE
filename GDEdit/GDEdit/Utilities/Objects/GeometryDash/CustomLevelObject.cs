﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;
using GDEdit.Utilities.Functions.General;

namespace GDEdit.Utilities.Objects.GeometryDash
{
    /// <summary>Represents a custom level object.</summary>
    public class CustomLevelObject
    {
        /// <summary>The objects of the custom object.</summary>
        public List<LevelObject> LevelObjects;
        
        /// <summary>Creates a new instance of the <seealso cref="CustomLevelObject"/> class from the specified list of objects.</summary>
        /// <param name="levelObjects">The objects this custom object has.</param>
        public CustomLevelObject(List<LevelObject> levelObjects)
        {
            LevelObjects = levelObjects.Clone();
            if (LevelObjects.Count > 0)
            {
                double avgX = 0;
                double avgY = 0;
                for (int i = 0; i < LevelObjects.Count; i++)
                {
                    avgX += (double)LevelObjects[i][ObjectParameter.X];
                    avgY += (double)LevelObjects[i][ObjectParameter.Y];
                }
                avgX /= LevelObjects.Count;
                avgY /= LevelObjects.Count;
                for (int i = 0; i < LevelObjects.Count; i++)
                {
                    LevelObjects[i][ObjectParameter.X] = (double)LevelObjects[i][ObjectParameter.X] - avgX;
                    LevelObjects[i][ObjectParameter.Y] = (double)LevelObjects[i][ObjectParameter.Y] - avgY;
                }
            }
        }
    }
}