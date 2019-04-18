﻿using DiscordRPC;
using GDE.App.Main.Colors;
using GDE.App.Main.Levels;
using GDE.App.Main.Screens.Edit.Components;
using GDE.App.Main.Tools;
using GDEdit.Application;
using GDEdit.Application.Editor;
using GDEdit.Utilities.Objects.GeometryDash;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK;

namespace GDE.App.Main.Screens.Edit
{
    public class EditorScreen : Screen
    {
        private TextureStore texStore;
        private Box background;
        private int i;

        private Database database;
        private LevelPreview preview;
        private Level level => database.UserLevels[i];

        private Editor editor;
        private Grid grid;

        [BackgroundDependencyLoader]
        private void load(DatabaseCollection databases, TextureStore ts)
        {
            database = databases[0];

            texStore = ts;
            background.Texture = texStore.Get("Backgrounds/game_bg_01_001-uhd.png");
        }

        public EditorScreen(int index, Level level)
        {
            editor = new Editor(level);
            // TODO: Inject editor into dependencies to work with the other things

            RPC.UpdatePresence(editor.Level.Name, "Editing a level", new Assets
            {
                LargeImageKey = "gde",
                LargeImageText = "GD Edit"
            });

            i = index;

            AddRangeInternal(new Drawable[]
            {
                background = new Box
                {
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    Depth = float.MaxValue,
                    Colour = GDEColors.FromHex("4f4f4f"),
                    Size = new Vector2(2048, 2048)
                },
                grid = new Grid(),
                preview = new LevelPreview(index)
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                },
                new EditorTools(preview)
                {
                    Size = new Vector2(150, 300),
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft
                },
            });
        }

        protected override bool OnDrag(DragEvent e)
        {
            grid.GridPosition += e.Delta;
            return base.OnDrag(e);
        }
        protected override bool OnDragStart(DragStartEvent e) => true;
        protected override bool OnDragEnd(DragEndEvent e) => true;

        protected override bool OnScroll(ScrollEvent e)
        {
            grid.GridPosition += e.ScrollDelta;
            return base.OnScroll(e);
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.ShiftPressed)
                editor.Swipe = true;
            return base.OnKeyDown(e);
        }
        protected override bool OnKeyUp(KeyUpEvent e)
        {
            if (e.ShiftPressed)
                editor.Swipe = false;
            return base.OnKeyUp(e);
        }
    }
}
