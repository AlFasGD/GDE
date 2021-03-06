﻿using GDE.App.Main.Colors;
using GDE.App.Main.Containers;
using GDE.App.Main.Objects;
using GDE.App.Main.Overlays;
using GDE.App.Main.Panels;
using GDE.App.Main.Screens.Menu.Components;
using GDE.App.Main.Tools;
using GDE.App.Main.UI;
using GDEdit.Application;
using GDEdit.Application.Editor;
using GDEdit.Utilities.Objects.GeometryDash;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Transforms;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GDE.App.Main.Screens.Edit.Components
{
    public class ObjectAdditionPanel : Panel
    {
        protected override string Name => "Object Addition";

        private ObjectButton currentlyActiveButton;
        private FillFlowContainer container;
        private Camera camera;

        public int SelectedObjectID { get; private set; }

        public float SnapResolution = 30f;

        public BindableBool AbleToPlace = new BindableBool();

        public ObjectAdditionPanel(Camera camera)
        {
            this.camera = camera;
            Add(container = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.Both,
                Spacing = new Vector2(5),
                Margin = new MarginPadding
                {
                    Top = 35,
                    Horizontal = 5
                },
            });

            for (var i = 1; i < 10; i++)
            {
                ObjectButton objectButton;

                container.Add(objectButton = new ObjectButton(i)
                {
                    Size = new Vector2(40),
                });

                objectButton.Action = () =>
                {
                    if (objectButton.ToggleActive())
                    {
                        if (currentlyActiveButton != null)
                            currentlyActiveButton.Active = false;

                        currentlyActiveButton = objectButton;
                        AbleToPlace.Value = true;
                        camera.ShowGhostObject();
                        camera.SetGhostObjectID(SelectedObjectID = objectButton.ObjectID);
                    }
                    else if (currentlyActiveButton == objectButton)
                    {
                        currentlyActiveButton = null;
                        AbleToPlace.Value = false;
                        camera.HideGhostObject();
                    }
                };
            }
        }

        private class ObjectButton : Button
        {
            private bool active;

            public bool Active
            {
                get => active;
                set => this.TransformTo(nameof(BackgroundColour), GDEColors.FromHex((active = value) ? "383" : "333"));
            }
            public int ObjectID => Object.ObjectID;
            public ObjectBase Object { get; }

            public ObjectButton(int objectID = 1)
            {
                BackgroundColour = GDEColors.FromHex("333");

                Add(Object = new ObjectBase(new GeneralObject(objectID))
                {
                    Depth = -1,
                    Selectable = false
                });
            }

            /// <summary>Inverts the Active property and returns the new value.</summary>
            public bool ToggleActive() => Active = !Active;
        }
    }
}
