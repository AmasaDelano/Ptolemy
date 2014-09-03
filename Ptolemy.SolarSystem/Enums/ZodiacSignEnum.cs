﻿namespace Ptolemy.SolarSystem
{
    public enum ZodiacSignEnum
    {
        Aries = 0,
        Taurus = 1,
        Gemini = 2,
        Cancer = 3,
        Leo = 4,
        Virgo = 5,
        Libra = 6,
        Scorpio = 7,
        Sagittarius = 8,
        Capricorn = 9,
        Aquarius = 10,
        Pisces = 11
    }

    public static class ZodiacSignEnumHelper
    {
        public static int GetDegrees(this ZodiacSignEnum zodiacSignEnum)
        {
            return ((int) zodiacSignEnum) * 30;
        }
    }
}
