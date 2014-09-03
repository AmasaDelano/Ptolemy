using System.Windows;

namespace Ptolemy.SolarSystem
{
    /// <summary>
    /// Represents a perfectly circular orbit with an orbiting entity moving along the circumference.
    /// </summary>
    internal sealed class Orbit
    {
        #region Member Variables
        /// <summary>
        /// Direction the orbit is pointing at the time of epoch.
        /// </summary>
        private readonly double _directionAtEpoch;
        /// <summary>
        /// Radius of the circular orbit, in parts.
        /// </summary>
        private readonly double _radius;

        /// <summary>
        /// Number of rotations in one period of the orbit.
        /// </summary>
        private readonly double _rotationsOfOrbitPerPeriod;
        /// <summary>
        /// Number of rotations of the mean sun in one period of the orbit.
        /// </summary>
        private readonly double _rotationsOfMeanSunPerPeriod;

        /// <summary>
        /// Direction of the equant center. 0 if orbit does not have an equant center.
        /// </summary>
        private readonly double _equantDirection;
        /// <summary>
        /// Distance from the center of the orbit to the equant center. 0 if orbit does not have an equant center.
        /// </summary>
        private readonly double _equantDistance;
        #endregion

        #region Constructors

        internal Orbit(
            double directionAtEpoch,
            double radius,
            double rotationsOfOrbitPerPeriod,
            double rotationsOfMeanSunPerPeriod)
        {
            _directionAtEpoch = directionAtEpoch;
            _radius = radius;
            _rotationsOfOrbitPerPeriod = rotationsOfOrbitPerPeriod;
            _rotationsOfMeanSunPerPeriod = rotationsOfMeanSunPerPeriod;
        }

        internal Orbit(
            double directionAtEpoch,
            double radius,
            double rotationsOfOrbitPerPeriod,
            double rotationsOfMeanSunPerPeriod,
            double equantDirection,
            double equantDistance)
            : this(
                directionAtEpoch: directionAtEpoch,
                radius: radius,
                rotationsOfOrbitPerPeriod: rotationsOfOrbitPerPeriod,
                rotationsOfMeanSunPerPeriod: rotationsOfMeanSunPerPeriod)
        {
            _equantDirection = equantDirection;
            _equantDistance = equantDistance;
        }
        #endregion

        #region Public Interface

        /// <summary>
        /// Returns the radius of the orbit
        /// </summary>
        /// <returns></returns>
        internal double GetRadius()
        {
            return _radius;
        }

        /// <summary>
        /// Gets the position of the orbiting entity at the given time, originating from the given center point,
        /// and with the "parent orbit" facing in the given direction.
        /// </summary>
        /// <param name="currentTime">Date and time of orbit position</param>
        /// <param name="meanDirectionOfOrbit"></param>
        /// <param name="equantCenter"></param>
        /// <returns></returns>
        internal Point GetPosition(
            PtolemyDateTime currentTime,
            out double meanDirectionOfOrbit,
            out Point equantCenter)
        {
            // Extracting some helpful values into named variables
            bool equantCenterExists = _equantDistance > 0.0;
            Point center = new Point(x: 0.0, y: 0.0);

            // Calculate the mean degrees moved from the direction at epoch
            double meanDegreesMovedSinceEpoch = this.GetMeanDegreesMovedSinceEpoch(currentTime);

            // Get the "mean" direction of the planet
            double meanDirection = (_directionAtEpoch + meanDegreesMovedSinceEpoch) % PtolemyMath.DegreesInCircle;

            // By default (i.e. without a equant center), the mean direction is the same as the calculated direction of the orbit
            double calculatedDirectionOfOrbit = meanDirection;
            
            // If an equant center exists, factor it into the real direction of the orbiting body.
            if (equantCenterExists)
            {
                calculatedDirectionOfOrbit = this.GetDirectionOfOrbitFromDirectionOfEquant(meanDirection);
            }

            // Find the position of the orbiting entity, given the direction and the distance
            Axis axis = new Axis(direction: calculatedDirectionOfOrbit, distance: _radius);
            Point position = axis.GetEndPointFromOrigin(center);

            // Setting the orbit's mean direction (output parameter)
            meanDirectionOfOrbit = calculatedDirectionOfOrbit;

            // Setting the equant center (output parameter)
            if (equantCenterExists)
            {
                Axis axisFromOrbitToEquant = new Axis(_equantDirection, _equantDistance);
                equantCenter = axisFromOrbitToEquant.GetEndPointFromOrigin(center);
            }
            else
            {
                equantCenter = center;
            }

            // Return the position of the orbiting body
            return position;
        }

        /// <summary>
        /// Gets the position of the orbiting entity at the given time, originating from the given center point,
        /// and with the "parent orbit" facing in the given direction.
        /// </summary>
        /// <param name="currentTime">Date and time of orbit position</param>
        /// <param name="meanDirectionOfOrbit"></param>
        /// <returns></returns>
        internal Point GetPosition(
            PtolemyDateTime currentTime,
            out double meanDirectionOfOrbit)
        {
            // The equant center is not actually outputted from this method.
            Point dummy;

            return GetPosition(
                currentTime: currentTime,
                meanDirectionOfOrbit: out meanDirectionOfOrbit,
                equantCenter: out dummy);
        }

        /// <summary>
        /// Gets the position of the orbiting entity at the given time, originating from the given center point,
        /// and with the "parent orbit" facing in the given direction.
        /// </summary>
        /// <param name="currentTime">Date and time of orbit position</param>
        /// <returns></returns>
        internal Point GetPosition(
            PtolemyDateTime currentTime)
        {
            // The equant center and mean direction of orbit are not actually outputted from this method.
            double dummy;

            return GetPosition(
                currentTime: currentTime,
                meanDirectionOfOrbit: out dummy);
        }
        #endregion

        #region Private Helpers
        private double GetMeanDegreesMovedSinceEpoch(PtolemyDateTime currentTime)
        {
            // Extracting helpful values as named variables
            const long ticksPerDay = 864000000000;

            // Each line does one conversion.
            // Ultimately, converting:
            //  ticks passed since epoch to
            //  periods for this orbit since the epoch to
            //  mean degrees moved over those periods

            long ticksSinceEpoch = currentTime.Ticks - PtolemyDateTime.TimeOfEpoch.Ticks;

            double daysSinceEpoch = ((double) ticksSinceEpoch) / ticksPerDay;

            double meanYearsSinceEpoch = daysSinceEpoch / PtolemyMath.DaysInAMeanYear;

            // Division by zero check
            if (_rotationsOfMeanSunPerPeriod == 0.0)
            {
                return 0.0;
            }

            double periodsSinceEpoch = meanYearsSinceEpoch / _rotationsOfMeanSunPerPeriod;

            double rotationsOfOrbitSinceEpoch = periodsSinceEpoch * _rotationsOfOrbitPerPeriod;

            double meanDegreesMovedSinceEpoch = rotationsOfOrbitSinceEpoch * PtolemyMath.DegreesInCircle;

            return meanDegreesMovedSinceEpoch;
        }

        private double GetDirectionOfOrbitFromDirectionOfEquant(double directionFromEquantCenter)
        {
            // Reference drawing: http://www.mathpages.com/home/kmath639/kmath639.htm (third diagram from top)

            // By law of sines:
            // sin (180 - b) / R = sin (b - a) / E
            //
            // E sin (180 - b) = R sin (b - 1)
            // sin-1 ( E sin (180 - b) / R ) = b - a
            // so
            // a = b - sin-1 (E sin (180 - b) / R)
            // 
            // a = directionFromOrbitCenter
            // b = directionFromEquantCenter
            // R = _distance
            // E = _equantDistance

            double directionFromOrbitCenter = directionFromEquantCenter -
                PtolemyMath.ArcSine(
                    (_equantDistance * PtolemyMath.Sine(
                        PtolemyMath.DegreesInTriangle - directionFromEquantCenter
                        )) / _radius);

            return directionFromOrbitCenter;
        }
        #endregion
    }
}
