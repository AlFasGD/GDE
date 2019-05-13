﻿using GDE.App.Main.Objects;
using GDEdit.Application.Editor;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Input;
using osu.Framework.Input.Events;
using osuTK;

namespace GDE.App.Main.Screens.Edit.Components
{
    public class Camera : Container
    {
        private Editor editor;

        public Camera(Editor Editor)
        {
            editor = Editor;
        }

        protected override bool OnDrag(DragEvent e)
        {
            foreach (var child in Children)
            {
                child.Position += e.Delta;
            }

            return true;
        }

        protected override bool OnDragEnd(DragEndEvent e) => true;
        protected override bool OnDragStart(DragStartEvent e) => true;

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.ShiftPressed)
                if (editor != null)
                    editor.Swipe = true;
            return base.OnKeyDown(e);
        }
        protected override bool OnKeyUp(KeyUpEvent e)
        {
            if (e.ShiftPressed)
                if (editor != null)
                    editor.Swipe = false;
            return base.OnKeyUp(e);
        }

        public void AddGhostObject(GeneralObject o)
        {
            Add(new GridSnappedCursorContainer
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new GhostObject(o)
                    {
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft
                    }
                }
            });
        }

        public void AddGhostObject(int id)
        {
            Add(new GridSnappedCursorContainer
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new GhostObject(id)
                    {
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                        // Something must be done so that the object does not initially appear
                    }
                }
            });
        }

        private class GridSnappedCursorContainer : CursorContainer, IRequireHighFrequencyMousePosition
        {
            public int SnapResolution { get; set; }

            public GridSnappedCursorContainer(int snapResolution = 30)
                : base()
            {
                SnapResolution = snapResolution;
            }

            protected override bool OnMouseMove(MouseMoveEvent e)
            {
                foreach (var child in Children)
                    child.Position = ConvertMousePositionToEditor(e.ScreenSpaceMousePosition);

                return true;
            }

            public Vector2 ConvertMousePositionToEditor(Vector2 mousePosition)
            {
                float x = mousePosition.X;
                x -= x % SnapResolution;

                float y = mousePosition.Y;
                y -= y % SnapResolution;

                return new Vector2(x, y);
            }

            protected override bool OnClick(ClickEvent e)
            {
                foreach (var child in Children)
                    child.Expire();

                return base.OnClick(e);
            }
        }

        private class GhostObject : ObjectBase
        {
            public GhostObject(GeneralObject o) : base(o) { }
            public GhostObject(int id) : base(id) { }

            [BackgroundDependencyLoader]
            private void load()
            {
                Alpha = 0.5f;
            }
        }
    }
}
