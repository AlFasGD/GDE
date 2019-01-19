﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Enumerations.GeometryDash;
using GDEdit.Utilities.Functions.Extensions;
using GDEdit.Utilities.Functions.General;
using GDEdit.Utilities.Functions.GeometryDash;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects;

namespace GDEdit.Utilities.Objects.GeometryDash
{
    /// <summary>Represents a level in the game.</summary>
    public class Level
    {
        private List<Guideline> levelGuidelines;
        private string levelGuidelinesString;

        #region Properties
        /// <summary>Returns the name of the level followed by its revision if needed.</summary>
        public string LevelNameWithRevision => $"{Name}{(Revision > 0 ? $" (Rev. {Revision})" : "")}";
        /// <summary>The name of the level.</summary>
        public string Name;
        /// <summary>The level string.</summary>
        public string LevelString; // TODO: Change to property which uses RawLevel
        /// <summary>The decrypted form of the level string.</summary>
        public string DecryptedLevelString;
        /// <summary>The guideline string of the level.</summary>
        public string LevelGuidelinesString
        {
            get => levelGuidelinesString;
            set
            {
                levelGuidelines = null; // Reset and only analyze if requested
                levelGuidelinesString = value;
            }
        }
        /// <summary>The description of the level.</summary>
        public string LevelDescription = "";
        /// <summary>The raw form of the level as found in the gamesave.</summary>
        public string RawLevel;
        /// <summary>The revision of the level.</summary>
        public int Revision;
        /// <summary>The official song ID used in the level.</summary>
        public int OfficialSongID;
        /// <summary>The custom song ID used in the level.</summary>
        public int CustomSongID;
        /// <summary>The level object count.</summary>
        public int ObjectCount => LevelObjects.Count - ObjectCounts.ValueOrDefault((int)TriggerType.StartPos);
        /// <summary>The level trigger count.</summary>
        public int TriggerCount => LevelObjects.TriggerCount;
        /// <summary>The attempts made in the level.</summary>
        public int Attempts;
        /// <summary>The ID of the level.</summary>
        public int LevelID;
        /// <summary>The version of the level.</summary>
        public int Version;
        /// <summary>The length of the level.</summary>
        public int Length;
        /// <summary>The folder of the level.</summary>
        public int Folder;
        /// <summary>The time spent in the editor building the level in seconds.</summary>
        public int BuildTime;
        /// <summary>The time spent in the editor building the level.</summary>
        public TimeSpan TotalBuildTime
        {
            get => new TimeSpan(0, 0, BuildTime);
            set => BuildTime = (int)value.TotalSeconds;
        }
        /// <summary>Determines whether the level has been verified or not.</summary>
        public bool VerifiedStatus;
        /// <summary>Determines whether the level has been uploaded or not.</summary>
        public bool UploadedStatus;
        /// <summary>The level's objects.</summary>
        public LevelObjectCollection LevelObjects { get; set; }
        /// <summary>The level's guidelines.</summary>
        public List<Guideline> Guidelines
        {
            get
            {
                if (levelGuidelines == null)
                    levelGuidelines = Gamesave.GetGuidelines(LevelGuidelinesString);
                return levelGuidelines;
            }
            set
            {
                levelGuidelines = value;
                LevelGuidelinesString = GetGuidelineString(levelGuidelines);
            }
        }
        /// <summary>Contains the number of times each object ID has been used in the level.</summary>
        public Dictionary<int, int> ObjectCounts;
        #endregion

        #region Constructors
        /// <summary>Creates a new empty instance of the <see cref="Level"/> class.</summary>
        public Level() { }
        /// <summary>Creates a new instance of the <see cref="Level"/> class from a raw string containing a level without getting its info.</summary>
        /// <param name="level">The raw string containing the level.</param>
        public Level(string level)
        {
            RawLevel = level;
        }
        #endregion

        #region Functions
        /// <summary>Returns the guideline string of a list of guidelines.</summary>
        /// <param name="guidelines">The list of guidelines to get the guideline string of.</param>
        public static string GetGuidelineString(List<Guideline> guidelines)
        {
            StringBuilder result = new StringBuilder();
            foreach (var g in guidelines)
                result.Append(g.ToString() + "~");
            return result.ToString();
        }
        #endregion
    }
}