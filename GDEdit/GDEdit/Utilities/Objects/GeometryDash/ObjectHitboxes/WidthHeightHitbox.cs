﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDEdit.Utilities.Objects.General;

namespace GDEdit.Utilities.Objects.GeometryDash.ObjectHitboxes
{
    /// <summary>Represents a hitbox that has a height and a width.</summary>
    public abstract class WidthHeightHitbox : HitboxType, IHasHeight, IHasWidth
    {
        /// <summary>The width of the hitbox.</summary>
        public double Width { get; set; }
        /// <summary>The height of the hitbox.</summary>
        public double Height { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="WidthHeightHitbox"/> class.</summary>
        /// <param name="both">The length of both dimensions of the hitbox.</param>
        public WidthHeightHitbox(double both) : this(both, both) { }
        /// <summary>Initializes a new instance of the <seealso cref="WidthHeightHitbox"/> class.</summary>
        /// <param name="width">The width of the hitbox.</param>
        /// <param name="height">The height of the hitbox.</param>
        public WidthHeightHitbox(double width, double height)
            : base()
        {
            Width = width;
            Height = height;
        }

        /// <summary>Returns the distance between the center of the hitbox and its edge.</summary>
        /// <param name="rotation">The rotation in degrees to get the distance at.</param>
        public override double GetRadiusAtRotation(double rotation)
        {
            double rad = rotation * Math.PI / 180;
            double w = Width / 2;
            double h = Height / 2;
            // The points (x, y) are an ellipse contained in the rectangle
            double x = Math.Cos(rad) * w;
            double y = Math.Sin(rad) * h;
            Point result = new Point(x, y);
            // Check whether the point does not touch the horizontal lines of the rectangle
            if (y < h && y > -h)
            {
                double k = w / x;
                double a = k * x;
                double b = k * y;
                if (b > h || b < -h)
                {
                    a *= h / b;
                    b = h;
                }
                result.X = a;
                result.Y = b;
            }
            return new Point(0).DistanceFrom(result);
        }

        /// <summary>Determines whether a point is within the hitbox.</summary>
        /// <param name="point">The point's location.</param>
        /// <param name="hitboxCenter">The hitbox's center.</param>
        public override bool IsPointWithinHitbox(Point point, Point hitboxCenter)
        {
            Point start = new Point(hitboxCenter.X - Width / 2, hitboxCenter.Y - Height / 2);
            Point end = new Point(hitboxCenter.X + Width / 2, hitboxCenter.Y + Height / 2);
            return start <= point && point <= end;
        }
    }
}
