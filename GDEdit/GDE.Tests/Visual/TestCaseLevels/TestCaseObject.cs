﻿using GDE.App.Main.Objects;
using GDEdit.Utilities.Objects.GeometryDash.LevelObjects;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;
using osuTK;
using osuTK.Graphics;

namespace GDE.Tests.Visual.TestCaseLevel
{
    public class TestCaseObject : TestCase
    {
        private ObjectBase obj;

        public TestCaseObject()
        {
            Children = new Drawable[]
            {
                new Box
                {
                    Colour = new Color4(95, 95, 95, 255),
                    RelativeSizeAxes = Axes.Both
                },
                obj = new ObjectBase(new GeneralObject())
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Size = new Vector2(100)
                }
            };

            AddSliderStep("Object ID", 1, 1600, 1, v => obj.ObjectID = v);
            AddStep("Move 1", () => obj.ObjectID++);
            AddStep("Move -1", () => obj.ObjectID--);
        }
    }
}
