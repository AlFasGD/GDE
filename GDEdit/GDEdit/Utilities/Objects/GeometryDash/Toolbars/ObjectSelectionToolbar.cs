﻿using GDEdit.Utilities.Objects.GeometryDash.LevelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.Toolbars
{
    /// <summary>Contains the information of an object selection toolbar.</summary>
    public class ObjectSelectionToolbar
    {
        /// <summary>The tabs of the toolbar.</summary>
        public List<ObjectSelectionToolbarTab> Tabs { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="ObjectSelectionToolbar"/> class.</summary>
        public ObjectSelectionToolbar()
        {
            Tabs = new List<ObjectSelectionToolbarTab>();
        }
        /// <summary>Initializes a new instance of the <seealso cref="ObjectSelectionToolbar"/> class.</summary>
        /// <param name="tabs">The tabs this <seealso cref="ObjectSelectionToolbar"/> will have.</param>
        public ObjectSelectionToolbar(List<ObjectSelectionToolbarTab> tabs)
        {
            Tabs = tabs;
        }
    }
}
