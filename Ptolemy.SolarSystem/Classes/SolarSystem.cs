﻿using System.Collections.Generic;

namespace Ptolemy.SolarSystem
{
    public sealed class SolarSystem
    {
        #region Member Variables

        private readonly Dictionary<PlanetTypes, Planet> _planets;

        private PtolemyDateTime _currentTime;
        private double _directionOfAries;

        #endregion

        #region Constructors

        public SolarSystem()
        {
            _planets = GetRealPlanets();

            // Time is, by default, right now.
            _currentTime = PtolemyDateTime.Now;

            // Aries is straight up.
            _directionOfAries = 0;
        }

        #endregion

        #region Public Interface
        
        public void SetCurrentTime(PtolemyDateTime currentTime)
        {
            _currentTime = currentTime;
        }

        public PtolemyDateTime GetCurrentTime()
        {
            return _currentTime;
        }

        public void AdvanceCurrentTime(long ticks)
        {
            _currentTime = _currentTime.AddTicks(ticks);
        }

        /// <summary>
        /// Gets raw position data: earth is at x=0,y=0, Aries is facing 0 degrees (straight up).
        /// </summary>
        /// <param name="planetType"></param>
        /// <returns></returns>
        public PlanetPositionData GetPlanetPositionData(PlanetTypes planetType)
        {
            Planet planet = _planets[planetType];

            if (planet == null)
            {
                return null;
            }

            // Retrieve the raw position data
            PlanetPositionData data = planet.GetPositionData(currentTime: _currentTime);

            // Return raw position data
            return data;
        }

        #endregion

        #region Private Helpers

        private Planet GetDeferentSun()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: PtolemyMath.GetDecimalFromHexadecimal(2, 29, 1800), // H236: EZ = 2;29.5p where the radius of the eccentre = 60p, so the ratio is (2+29.5/60)
                distanceFromDeferentCenterToEpicycleCenter: 0,
                returnsInMeanOrbit: 1,
                returnsInAnomaly: 1,
                returnsOfMeanSun: 1,
                epochApogee: (int) ZodiacSigns.Gemini + PtolemyMath.GetDecimalFromHexadecimal(5, 30), // H256, H257
                epochMean: (int) ZodiacSigns.Pisces + PtolemyMath.GetDecimalFromHexadecimal(0, 45), // H263
                epochAnomaly: (int) ZodiacSigns.Pisces + PtolemyMath.GetDecimalFromHexadecimal(3, 8), // H263
                usesEquant: false
                );
        }

        private Planet GetEpicycleSun()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: 0,
                distanceFromDeferentCenterToEpicycleCenter: PtolemyMath.GetDecimalFromHexadecimal(2, 29, 1800), // H236: EZ = 2;29.5p where the radius of the eccentre = 60p, so the ratio is (2+29.5/60)
                returnsInMeanOrbit: 1,
                returnsInAnomaly: 1,
                returnsOfMeanSun: 1,
                epochApogee: (int) ZodiacSigns.Gemini + PtolemyMath.GetDecimalFromHexadecimal(5, 30), // H256, H257
                epochMean: (int) ZodiacSigns.Pisces + PtolemyMath.GetDecimalFromHexadecimal(0, 45), // H263
                epochAnomaly: (int) ZodiacSigns.Pisces + PtolemyMath.GetDecimalFromHexadecimal(3, 8), // H263
                usesEquant: false
                );
        }

        private Planet GetVenus()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: PtolemyMath.GetDecimalFromHexadecimal(1, 15), // H302: DE is about 1;15p to deferent radius AD, which is 60p, so 1;15/60
                distanceFromDeferentCenterToEpicycleCenter: PtolemyMath.GetDecimalFromHexadecimal(43, 10), // H302: AZ = 43;10p of 60p deferent radius AD, so 43;10/60
                returnsInMeanOrbit: 8 - (2.25 / PtolemyMath.DegreesInCircle),
                returnsInAnomaly: 5, // H215: 5 epicyclic rotations to 8 mean sun rotations less 2;18 days
                returnsOfMeanSun: PtolemyMath.GetRotationsFromMeanTime(years: 8, days: -2, sixtieths: 18),
                epochApogee: (int) ZodiacSigns.Taurus + PtolemyMath.GetDecimalFromHexadecimal(16, 10), // H316 & H250
                epochMean: (int) ZodiacSigns.Pisces + PtolemyMath.GetDecimalFromHexadecimal(0, 45),
                epochAnomaly: PtolemyMath.GetDecimalFromHexadecimal(71, 7),
                usesEquant: true
                );
        }

        private Planet GetMars()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: 6, // H342: D-theta = 6p after the corrections
                distanceFromDeferentCenterToEpicycleCenter: PtolemyMath.GetDecimalFromHexadecimal(39, 30), // H351: BN = 39;30
                returnsInMeanOrbit: 32 + ((3 + (1/6)) / PtolemyMath.DegreesInCircle),
                returnsInAnomaly: 37,
                returnsOfMeanSun: PtolemyMath.GetRotationsFromMeanTime(years: 79, days: 3, sixtieths: 13), // H215: 37 returns in anomaly to 32 plus 3 1/6 degrees mean returns to 79 years plus 3;13 days 
                epochApogee: (int) ZodiacSigns.Cancer + PtolemyMath.GetDecimalFromHexadecimal(16, 40), // H250
                epochMean: (int) ZodiacSigns.Aries + PtolemyMath.GetDecimalFromHexadecimal(3, 32),
                epochAnomaly: PtolemyMath.GetDecimalFromHexadecimal(327, 13),
                usesEquant: true
                );
        }

        private Planet GetSaturn()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: PtolemyMath.GetDecimalFromHexadecimal(3, 25), // H411: DZ = 3;25p
                distanceFromDeferentCenterToEpicycleCenter: PtolemyMath.GetDecimalFromHexadecimal(6, 30), // H419
                returnsInMeanOrbit: 2 + ((1 + (43/60)) / PtolemyMath.DegreesInCircle), // H215
                returnsInAnomaly: 57, // H215: 57 returns in anomaly to 
                returnsOfMeanSun: PtolemyMath.GetRotationsFromMeanTime(years: 59, days: 1, sixtieths: 45),  // H215
                epochApogee: (int) ZodiacSigns.Scorpio + PtolemyMath.GetDecimalFromHexadecimal(14, 10), // H250
                epochMean: (int) ZodiacSigns.Libra + PtolemyMath.GetDecimalFromHexadecimal(4, 41),
                epochAnomaly: PtolemyMath.GetDecimalFromHexadecimal(34, 2),
                usesEquant: true
                );
        }

        private Planet GetJupiter()
        {
            return new Planet(
                distanceFromEarthCenterToDeferentCenter: PtolemyMath.GetDecimalFromHexadecimal(2, 45), // H379: DZ = 2;45p
                distanceFromDeferentCenterToEpicycleCenter: PtolemyMath.GetDecimalFromHexadecimal(11, 30), // H386: BK = 11;30p
                returnsInMeanOrbit: 6 - ((4 + (1/6)) / PtolemyMath.DegreesInCircle), // H215
                returnsInAnomaly: 65, // H215: 65 returns in anomaly to 
                returnsOfMeanSun: PtolemyMath.GetRotationsFromMeanTime(years: 71, days: -4, sixtieths: 6), // H215
                epochApogee: (int) ZodiacSigns.Virgo + PtolemyMath.GetDecimalFromHexadecimal(2, 9), // H250
                epochMean: (int) ZodiacSigns.Libra + PtolemyMath.GetDecimalFromHexadecimal(4, 41),
                epochAnomaly: PtolemyMath.GetDecimalFromHexadecimal(146, 4),
                usesEquant: true
                );
        }

        private Dictionary<PlanetTypes, Planet> GetRealPlanets()
        {
            Dictionary<PlanetTypes, Planet> planets = new Dictionary<PlanetTypes, Planet>();

            // Deferent Sun
            planets.Add(PlanetTypes.SunDeferent, this.GetDeferentSun());

            // Epicyclic Sun
            planets.Add(PlanetTypes.SunEpicycle, this.GetEpicycleSun());

            // Venus
            planets.Add(PlanetTypes.Venus, this.GetVenus());

            // Mars
            planets.Add(PlanetTypes.Mars, this.GetMars());

            // Jupiter
            planets.Add(PlanetTypes.Jupiter, this.GetJupiter());

            // Saturn
            planets.Add(PlanetTypes.Saturn, this.GetSaturn());

            return planets;
        }

        #endregion
    }
}
