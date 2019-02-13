﻿using GDE.App.Main.Colours;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics;
using osuTK;
using System;
using GDE.App.Main.Levels.Metas;

namespace GDE.App.Main.Screens.Menu.Components
{
    public class Toolbar : Container
    {
        public Bindable<Level> Level = new Bindable<Level>(new Level
        {
            AuthorName = "Unknown author",
            Name = "Unknown name",
            Position = 0,
            Verified = false,
            Length = 0,
            Song = new Song
            {
                AuthorName = "Unknown author",
                Name = "Unknown name",
                AuthorNG = "Unkown author NG",
                ID = 000000,
                Link = "Unkown link"
            },
        });

        public Action Edit;
        public Action Delete;

        private SpriteText LevelName, SongName;

        public Toolbar()
        {
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = GDEColours.FromHex("161616")
                },
                new FillFlowContainer
                {
                    Direction = FillDirection.Horizontal,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        LevelName = new SpriteText
                        {
                            Margin = new MarginPadding(5),
                            Text = Level.Value.Name,
                            TextSize = 30
                        },
                        SongName = new SpriteText
                        {
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft,
                            Margin = new MarginPadding(5),
                            Colour = GDEColours.FromHex("666666"),
                            Text = Level.Value.Song.Name,
                            TextSize = 25,
                        }
                    }
                },
                new FillFlowContainer
                {
                    Direction = FillDirection.Horizontal,
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Button
                        {
                            Anchor = Anchor.CentreRight,
                            Origin = Anchor.CentreRight,
                            Margin = new MarginPadding(5),
                            Size = new Vector2(80, 30),
                            BackgroundColour = GDEColours.FromHex("c6262e"),
                            Text = "Delete",
                            Action = () => Edit?.Invoke()
                        },
                        new Button
                        {
                            Anchor = Anchor.CentreRight,
                            Origin = Anchor.CentreRight,
                            Margin = new MarginPadding(5),
                            Size = new Vector2(80, 30),
                            BackgroundColour = GDEColours.FromHex("242424"),
                            Text = "Edit",
                            Action = () => Delete?.Invoke()
                        }
                    }
                }
            };

            Level.ValueChanged += OnChanged;
        }

        private void OnChanged(Level obj)
        {
            LevelName.Text = obj.Name;
            SongName.Text = obj.Song.Name;
        }
    }
}