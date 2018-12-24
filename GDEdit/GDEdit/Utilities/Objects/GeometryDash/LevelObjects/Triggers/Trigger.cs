﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Attributes;
using GDEdit.Utilities.Enumerations.GeometryDash.GamesaveValues;

namespace GDEdit.Utilities.Objects.GeometryDash.LevelObjects.Triggers
{
    public abstract class Trigger : GeneralObject
    {
        private bool touchTriggered, spawnTriggered;

        // IMPORTANT: If we want to change the object IDs of objects through some function, this has to be reworked
        [ObjectStringMappable(ObjectParameter.Duration)]
        public new virtual int ObjectID { get; }
        
        [ObjectStringMappable(ObjectParameter.TouchTriggered)]
        public bool TouchTriggered
        {
            get => touchTriggered;
            set
            {
                if (value && spawnTriggered)
                    spawnTriggered = false;
                touchTriggered = value;
            }
        }
        [ObjectStringMappable(ObjectParameter.SpawnTriggered)]
        public bool SpawnTriggered
        {
            get => spawnTriggered;
            set
            {
                if (value && touchTriggered)
                    touchTriggered = false;
                spawnTriggered = value;
            }
        }
        [ObjectStringMappable(ObjectParameter.MultiTrigger)]
        public bool MultiTrigger { get; set; }

        public Trigger()
        {

        }
        public Trigger(bool touchTriggered)
        {
            TouchTriggered = touchTriggered;
        }
        public Trigger(bool spawnTriggered, bool multiTrigger)
        {
            SpawnTriggered = spawnTriggered;
            MultiTrigger = multiTrigger;
        }
    }
}
