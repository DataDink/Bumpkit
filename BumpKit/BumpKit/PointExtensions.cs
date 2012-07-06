using System;
using System.Drawing;

namespace BumpKit
{
    public static class PointExtensions
    {
        /// <summary>
        /// Converts to an integer based point
        /// </summary>
        public static Point ToPoint(this PointF pointF)
        {
            return new Point((int)pointF.X, (int)pointF.Y);
        }

        /// <summary>
        /// Plots a new point the given distance and direction from the current point.
        /// </summary>
        /// <param name="origin">The originating point.</param>
        /// <param name="angle">The direction to plot</param>
        /// <param name="distance">The distance to plot</param>
        /// <returns>The plotted point</returns>
        public static PointF Plot(this PointF origin, float angle, float distance)
        {
            var radians = Math.PI/180*angle;
            var xplot = Math.Cos(radians)*distance;
            var yplot = Math.Sin(radians)*distance;
            return new PointF(origin.X + (float)xplot, origin.Y + (float)yplot);
        }

        /// <summary>
        /// Returns the distance the current plot is from 0, 0
        /// </summary>
        /// <param name="plot">The current plot</param>
        /// <returns>The point's distance</returns>
        public static double GetDistance(this PointF plot)
        {
            return Math.Sqrt(Math.Pow(plot.X, 2) + Math.Pow(plot.Y, 2));
        }

        /// <summary>
        /// Returns the angle the current plot is from 0, 0
        /// </summary>
        /// <param name="plot">The current plot</param>
        /// <returns>The point's angle</returns>
        public static double GetAngle(this PointF plot)
        {
            return Math.Atan(plot.Y/plot.X)*180/Math.PI;
        }
    }
}
