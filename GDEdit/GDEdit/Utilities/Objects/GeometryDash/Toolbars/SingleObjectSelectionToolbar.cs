﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Objects.GeometryDash.Toolbars
{
    public class SingleObjectSelectionToolbar : ObjectSelectionToolbar
    {
        private int selectedTabIndex;

        /// <summary>Gets or sets the index of the currently selected tab.</summary>
        public int SelectedTabIndex
        {
            get => selectedTabIndex;
            set
            {
                if (selectedTabIndex < 0 || selectedTabIndex >= Tabs.Count)
                    throw new IndexOutOfRangeException();
                selectedTabIndex = value;
            }
        }
        /// <summary>Gets or sets the currently selected tab.</summary>
        public ObjectSelectionToolbarTab SelectedTab
        {
            get => Tabs[selectedTabIndex];
            set
            {
                int index = Tabs.IndexOf(value);
                if (index < 0)
                    throw new Exception("The tab is not in this toolbar.");
                selectedTabIndex = index;
            }
        }
    }
}
