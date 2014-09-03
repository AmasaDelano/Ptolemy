using System.Windows;

namespace Ptolemy.SolarSystem
{
    internal sealed class Axis
    {
        #region Member Variables
        private readonly double _direction;
        private readonly double _distance;
        #endregion

        #region Constructors
        internal Axis(double direction, double distance)
        {
            _direction = direction;
            _distance = distance;
        }
        #endregion

        #region Public Interface
        internal double GetDirection()
        {
            return _direction;
        }

        internal Point GetEndPointFromOrigin(Point origin)
        {
            double xOffset = PtolemyMath.Sine(_direction) * _distance,
                   yOffset = PtolemyMath.Cosine(_direction) * _distance;

            return new Point(
                x: origin.X + xOffset,
                y: origin.Y + yOffset);
        }
        #endregion
    }
}
