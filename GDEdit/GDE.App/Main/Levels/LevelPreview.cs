﻿using GDE.App.Main.Objects;
using GDEdit.Application;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace GDE.App.Main.Levels
{
    public class LevelPreview : Container
    {
        private int i;
        private Database database;

        public bool AllowDrag = true;

        public LevelPreview(int index)
        {
            i = index;

            AutoSizeAxes = Axes.Both;
            
            foreach (var o in database.UserLevels[i].LevelObjects)
                Add(new ObjectBase(o));
        }

        [BackgroundDependencyLoader]
        private void load(DatabaseCollection databases)
        {
            database = databases[0];
        }

        protected override bool OnDrag(DragEvent e)
        {
            if (!AllowDrag)
                return false;

            Position += e.Delta;
            return true;
        }

        protected override bool OnDragEnd(DragEndEvent e) => true;
        protected override bool OnDragStart(DragStartEvent e) => AllowDrag;
    }
}
