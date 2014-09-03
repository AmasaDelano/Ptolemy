using System;
using System.Globalization;

namespace Ptolemy.SolarSystem
{
    /// <summary>
    /// When the year is greater than A.D. 1582, this date time conforms to the Gregorian calendar.
    /// For years before and including A.D. 1582, including B.C. years, this date time conforms to the Julian calendar.
    /// </summary>
    public sealed class PtolemyDateTime
    {
        #region Class Variables
        private const int LastYearOfJulianCalendar = 1582;
        private const int MaxYear = 9999;
        private const int MinYear = -9999;
        private const int JulianLeapYearInterval = 4;
        private const int FakeYearZero = MaxYear - (MaxYear % JulianLeapYearInterval);
        #endregion

        #region Member Variables
        private long _ticks;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new Ptolemy date time given a year (-9999 through 9999), month, day, hour, and minute.
        /// </summary>
        /// <param name="year">Year of the date time, from -9999 to 9999 inclusive.</param>
        /// <param name="month">Month of the date time, from 1 to 12</param>
        /// <param name="day">Day of the date time</param>
        /// <param name="hour">Hour of the date time, from 1 to 24</param>
        /// <param name="minute">Minute of the date time, from 0 to 59</param>
        public PtolemyDateTime(int year, int month, int day, int hour, int minute)
        {
            bool isAdEra = year >= 1;

            long ticks = 0;
            
            if (!isAdEra)
            {
                ticks = new DateTime(year: FakeYearZero, month: 1, day: 1).Ticks;
            }

            DateTime dateTime = new DateTime(
                            year: isAdEra
                                    ? year
                                    : FakeYearZero + year,
                            month: month,
                            day: day,
                            hour: hour,
                            minute: minute,
                            second: 0,
                            calendar: year > LastYearOfJulianCalendar
                                    ? (Calendar)(new GregorianCalendar())
                                    : (Calendar)(new JulianCalendar()));

            ticks += (dateTime.Ticks * (isAdEra ? 1 : -1));

            ticks *= (isAdEra ? 1 : -1);

            _ticks = ticks;
        }

        public PtolemyDateTime(long ticks)
        {
            _ticks = ticks;
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// H254: Year 1 of Nabonassar, Thoth 1 in the Egyptian calendar, noon (747 BC, Feb 26th at noon)
        /// </summary>
        internal static PtolemyDateTime TimeOfEpoch
        {
            get
            {
                return new PtolemyDateTime(
                    year: -746,
                    month: 2,
                    day: 26,
                    hour: 12,
                    minute: 0);
            }
        }


        public static PtolemyDateTime Now
        {
            get
            {
                DateTime now = DateTime.Now;
                return new PtolemyDateTime(now.Ticks);
            }
        }
        /// <summary>
        /// The number of ticks since the very beginning of A.D 1. Negative ticks indicate B.C.
        /// </summary>
        public long Ticks
        {
            get
            {
                return _ticks;
            }
        }
        /// <summary>
        /// Returns a new PtolemyDateTime with a specified number of ticks added to the current one
        /// </summary>
        /// <param name="ticks">Positive or negative number of ticks</param>
        /// <returns>A new PtolemyDateTime, the result of adding ticks to the old one</returns>
        public PtolemyDateTime AddTicks(long ticks)
        {
            return new PtolemyDateTime(_ticks + ticks);
        }
        #endregion
    }
}
