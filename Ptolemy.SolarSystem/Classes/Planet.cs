using System.Windows;

namespace Ptolemy.SolarSystem
{
    internal class Planet
    {
        #region Member Variables
        private readonly Axis _axisFromEarthToDeferentCenter;
        private readonly Orbit _deferentOrbit;
        private readonly Orbit _epicycleOrbit;
        #endregion

        #region Constructors
        internal Planet(
            double distanceFromEarthCenterToDeferentCenter,
            double distanceFromDeferentCenterToEpicycleCenter,
            double returnsInMeanOrbit,
            int returnsInAnomaly,
            double returnsOfMeanSun,
            double epochApogee,
            double epochMean,
            double epochAnomaly,
            bool usesEquant)
        {
            // Earth "axis" - the static position of the deferent center around the earth
            _axisFromEarthToDeferentCenter = new Axis(
                direction: epochApogee,
                distance: distanceFromEarthCenterToDeferentCenter);

            // Deferent Orbit - can include an equant center
            if (usesEquant)
            {
                _deferentOrbit = new Orbit(
                    directionAtEpoch: epochMean,
                    radius: PtolemyMath.PartsInRadius,
                    rotationsOfOrbitPerPeriod: returnsInMeanOrbit,
                    rotationsOfMeanSunPerPeriod: returnsOfMeanSun,
                    equantDirection: epochApogee,
                    equantDistance: distanceFromEarthCenterToDeferentCenter);
            }
            else
            {
                _deferentOrbit = new Orbit(
                    directionAtEpoch: epochMean,
                    radius: PtolemyMath.PartsInRadius,
                    rotationsOfOrbitPerPeriod: returnsInMeanOrbit,
                    rotationsOfMeanSunPerPeriod: returnsOfMeanSun);
            }

            // Epicycle Orbit - no equant center
            _epicycleOrbit = new Orbit(
                directionAtEpoch: epochAnomaly,
                radius: distanceFromDeferentCenterToEpicycleCenter,
                rotationsOfOrbitPerPeriod: returnsInAnomaly,
                rotationsOfMeanSunPerPeriod: returnsOfMeanSun);
        }
        #endregion

        #region Public Interface

        /// <summary>
        /// Get position data for the planet.
        /// See PlanetPositionData for details on what information comes back from this method.
        /// This method will fill out all public properties of PlanetPositionData.
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        internal PlanetPositionData GetPositionData
            (PtolemyDateTime currentTime)
        {
            Point deferentCenter,
                  equantCenter,
                  epicycleCenter,
                  planetCenter;

            // Extracting helpful values into named variables
            Point center = new Point(0.0, 0.0);

            // **** DEFERENT CENTER *****

            // Calculate Deferent center with Earth orbit
            deferentCenter = _axisFromEarthToDeferentCenter.GetEndPointFromOrigin(center);
            double directionOfEccentre = _axisFromEarthToDeferentCenter.GetDirection();
            double radiusOfDeferent = _deferentOrbit.GetRadius();

            // ***** EPICYCLE CENTER *****

            // Calculate Epicycle center with Deferent orbit
            double meanDirectionOfDeferentOrbit;
            epicycleCenter = _deferentOrbit.GetPosition(
                currentTime: currentTime,
                meanDirectionOfOrbit: out meanDirectionOfDeferentOrbit,
                equantCenter: out equantCenter);
            double radiusOfEpicycle = _epicycleOrbit.GetRadius();
            bool hasEquant = (int)equantCenter.X == 0 && (int)equantCenter.Y == 0;

            // Offsets the epicycle center correctly from the deferent center
            epicycleCenter = PtolemyMath.AddPoints(point1: deferentCenter, point2: epicycleCenter);

            // ***** PLANET CENTER *****

            // Calculate Planet center with Epicycle orbit
            planetCenter = _epicycleOrbit.GetPosition(currentTime: currentTime);

            // Offsets the planet center correctly from the epicycle center
            planetCenter = PtolemyMath.AddPoints(point1: epicycleCenter, point2: planetCenter);

            // Rotates the planet center correctly around the epicycle center
            planetCenter = PtolemyMath.RotatePointAroundOriginByAngle(
                point: planetCenter,
                origin: epicycleCenter,
                angle: meanDirectionOfDeferentOrbit - directionOfEccentre);

            // Create a new DTO and return it
            return new PlanetPositionData
            {
                DeferentCenter = deferentCenter,
                EquantCenter = equantCenter,
                EpicycleCenter = epicycleCenter,
                PlanetCenter = planetCenter,

                HasEquant = hasEquant,

                RadiusOfDeferent = radiusOfDeferent,
                RadiusOfEpicycle = radiusOfEpicycle
            };
        }
        #endregion
    }
}
