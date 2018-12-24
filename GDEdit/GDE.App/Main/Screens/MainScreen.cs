﻿using osuTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using GDE.App.Main.Colours;
using GDE.App.Main.UI.Tabs;

namespace GDE.App.Main.Screens
{
    public class MainScreen : Screen
    {
        private Box box;
        private TextureStore ts;

        [BackgroundDependencyLoader]
        private void load(TextureStore texStore)
        {
            ts = texStore;

            Add(new DrawSizePreservingFillContainer
            {
                Strategy = DrawSizePreservationStrategy.Average,
                Children = new Drawable[]
                {
                    box = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Colour = GDEColours.FromHex("151515")
                    },
                    new LevelTab
                    {
                        Size = new Vector2(0.08f, 0.04f),
                        Origin = Anchor.TopLeft,
                        Anchor = Anchor.TopLeft,
                    }
                }
            });
        }
    }
}
