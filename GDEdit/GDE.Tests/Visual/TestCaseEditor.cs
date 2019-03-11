﻿using GDE.App.Main.Screens.Edit;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osu.Framework.Testing;

namespace GDE.Tests.Visual
{
    public class TestCaseEditor : TestCase
    {
        public TestCaseEditor()
        {
            Add(new ScreenStack(new Editor(0))
            {
                RelativeSizeAxes = Axes.Both
            });
        }
    }
}
