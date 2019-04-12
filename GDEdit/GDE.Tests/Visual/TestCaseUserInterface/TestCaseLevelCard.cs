﻿using GDE.App.Main.Screens.Menu.Components;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using osuTK;

namespace GDE.Tests.Visual.TestCaseUserInterface
{
    public class TestCaseLevelCard : TestCase
    {
        private LevelCard card;

        public TestCaseLevelCard()
        {
            Children = new Drawable[]
            {
                card = new LevelCard(null)
                {
                    Size = new Vector2(250, 100),
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre
                }
            };
        }
    }
}
