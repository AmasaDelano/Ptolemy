using System;
using System.Windows;

namespace Ptolemy.SolarSystem
{
    /// <summary>
    /// Contains common mathematical operations which Ptolemy uses.
    /// </summary>
    internal static class PtolemyMath
    {
        #region Constants
        // ***** PUBLIC *****
        internal const int PartsInRadius = 60;
        internal const int DegreesInTriangle = 180;
        internal const int DegreesInCircle = 360;
        // H208: Tropical. Sidereal is 365;15;25 days
        internal static readonly double DaysInAMeanYear = GetDecimalFromHexadecimal(365, 14, 48);
        // ***** PRIVATE *****
        private const double RadiansInCircle = 2 * Math.PI;
        #endregion

        #region Public Interface
        /// <summary>
        /// Gets the a hexadecimal number, which is used frequently by Ptolemy, to a decimal number.
        /// Input each "piece" of the hexadecimal number as a new parameter.
        /// </summary>
        /// <remarks>
        /// Example of a hexadecimal angle: 12 + 24/60 + 59/360, written as 12°24'59"
        /// </remarks>
        /// <param name="ones"></param>
        /// <param name="sixtiethsAndSoOn"></param>
        /// <returns></returns>
        internal static double GetDecimalFromHexadecimal(int ones, params int[] sixtiethsAndSoOn)
        {
            double degrees = ones;
            for (int i = 0; i < sixtiethsAndSoOn.Length; i += 1)
            {
                degrees += ((sixtiethsAndSoOn[i]) / Math.Pow(60, i + 1));
            }
            return degrees;
        }

        /// <summary>
        /// Get the number of rotations given the mean time elapsed.
        /// </summary>
        /// <param name="years"></param>
        /// <param name="days"></param>
        /// <param name="sixtieths"></param>
        /// <returns></returns>
        internal static double GetRotationsFromMeanTime(int years, int days, int sixtieths)
        {
            return years + (PtolemyMath.GetDecimalFromHexadecimal(days, sixtieths) / PtolemyMath.DaysInAMeanYear);
        }

        /// <summary>
        /// Returns the ratio between the parts (p) and the radius, which always has 60p.
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        internal static double GetRatioFromParts(double parts)
        {
            return parts / PartsInRadius;
        }

        /// <summary>
        /// Gets the sine of an angle given in degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns>Sine of the angle given in degrees</returns>
        internal static double Sine(double degrees)
        {
            double radians = GetRadiansFromDegrees(degrees);
            return Math.Sin(radians);
        }

        /// <summary>
        /// Returns the number of degrees in the angle whose sine is given.
        /// </summary>
        /// <param name="sine">Sine of an angle</param>
        /// <returns>Degrees of the angle</returns>
        internal static double ArcSine(double sine)
        {
            double radians = GetRadiansFromDegrees(sine);
            return Math.Asin(radians);
        }

        /// <summary>
        /// Gets the cosine of an angle given in degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns>Cosine of the angle given in degrees</returns>
        internal static double Cosine(double degrees)
        {
            double radians = GetRadiansFromDegrees(degrees);
            return Math.Cos(radians);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="origin"></param>
        /// <param name="angle">Angle to rotate by, in degrees</param>
        /// <returns></returns>
        internal static Point RotatePointAroundOriginByAngle(Point point, Point origin, double angle)
        {
            double x = Cosine(angle) * (point.X - origin.X) - Sine(angle) * (point.Y - origin.Y) + origin.X;
            double y = Sine(angle) * (point.X - origin.X) + Cosine(angle) * (point.Y - origin.Y) + origin.Y;

            return new Point(x: x, y: y);
        }

        /// <summary>
        /// Adds two points together
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        internal static Point AddPoints(Point point1, Point point2)
        {
            return new Point(
                x: point1.X + point2.X,
                y: point1.Y + point2.Y);
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Gets the number of radians equal to the given number of degrees.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns>Radians</returns>
        private static double GetRadiansFromDegrees(double degrees)
        {
            return (degrees * RadiansInCircle) / DegreesInCircle;
        }
        #endregion
    }
}
