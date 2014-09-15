using System;
using NUnit.Framework;

namespace Ptolemy.SolarSystem.Tests
{
    [TestFixture]
    public class PtolemyDateTimeTests
    {
        [Test]
        public void PtolemyDateTimeNow_GetTicksOfNowProperty_TicksAreEqualToDateTimeNowTicks()
        {
            // ARRANGE
            PtolemyDateTime ptolemyNow = PtolemyDateTime.Now;
            DateTime now = DateTime.Now;
            long ticksInFiveMilliseconds = new TimeSpan(0, 0, 0, 0, milliseconds: 5).Ticks;

            // ACT
            long ptolemyTicks = ptolemyNow.Ticks;

            // ASSERT
            Assert.IsTrue(Math.Abs(now.Ticks - ptolemyTicks) < ticksInFiveMilliseconds);
        }

        [Test]
        public void PtolemyDateTimeConstructor_GetTicksOfAdDate_TicksAreEqualToSameDateInDateTime()
        {
            // ARRANGE
            PtolemyDateTime ptolemyDateTime = new PtolemyDateTime(year: 1990, month: 4, day: 3, hour: 14, minute: 0);
            DateTime dateTime = new DateTime(year: 1990, month: 4, day: 3, hour: 14, minute: 0, second: 0);

            // ACT
            long ptolemyTicks = ptolemyDateTime.Ticks;

            // ASSERT
            Assert.AreEqual(dateTime.Ticks, ptolemyTicks);
        }

        [Test]
        public void PtolemyDateTimeTicks_GetTicksOfAdDate_TicksArePositive()
        {
            // ARRANGE
            PtolemyDateTime ptolemyAd = new PtolemyDateTime(2, 1, 1, 1, 1);

            // ACT
            long ptolemyTicks = ptolemyAd.Ticks;

            // ASSERT
            Assert.IsTrue(ptolemyTicks > 0);
        }

        [Test]
        public void PtolemyDateTimeTicks_GetTicksOfBcDate_TicksAreNegative()
        {
            // ARRANGE
            PtolemyDateTime ptolemyBc = new PtolemyDateTime(-1, 1, 1, 1, 1);

            // ACT
            long ptolemyTicks = ptolemyBc.Ticks;

            // ASSERT
            Assert.IsTrue(ptolemyTicks < 0);
        }

        [Test]
        public void PtolemyDateTimeAddTicks_AddPositiveTicksToAdDate_TicksIncreases()
        {
            // ARRANGE
            PtolemyDateTime ptolemyAd = new PtolemyDateTime(2, 1, 1, 1, 1);
            long originalTicks = ptolemyAd.Ticks;

            // ACT
            PtolemyDateTime newDateTime = ptolemyAd.AddTicks(10);

            // ASSERT
            Assert.AreEqual(newDateTime.Ticks, originalTicks + 10);
        }

        [Test]
        public void PtolemyDateTimeAddTicks_AddPositiveTicksToBcDate_TicksIncreases()
        {
            // ARRANGE
            PtolemyDateTime ptolemyBc = new PtolemyDateTime(-1, 1, 1, 1, 1);
            long originalTicks = ptolemyBc.Ticks;

            // ACT
            PtolemyDateTime newDateTime = ptolemyBc.AddTicks(10);

            // ASSERT
            Assert.AreEqual(newDateTime.Ticks, originalTicks + 10);
        }

        [Test]
        public void PtolemyDateTimeAddTicks_AddNegativeTicksToAdDate_TicksDecreases()
        {
            // ARRANGE
            PtolemyDateTime ptolemyAd = new PtolemyDateTime(2, 1, 1, 1, 1);
            long originalTicks = ptolemyAd.Ticks;

            // ACT
            PtolemyDateTime newDateTime = ptolemyAd.AddTicks(-10);

            // ASSERT
            Assert.AreEqual(newDateTime.Ticks, originalTicks - 10);
        }

        [Test]
        public void PtolemyDateTimeAddTicks_AddNegativeTicksToBcDate_TicksDecreases()
        {
            // ARRANGE
            PtolemyDateTime ptolemyBc = new PtolemyDateTime(-1, 1, 1, 1, 1);
            long originalTicks = ptolemyBc.Ticks;

            // ACT
            PtolemyDateTime newDateTime = ptolemyBc.AddTicks(-10);

            // ASSERT
            Assert.AreEqual(newDateTime.Ticks, originalTicks - 10);
        }

        [Test]
        public void PtolemyDateTimeTicks_AddTicksFromBcToAd_TicksArePositive()
        {
            // ARRANGE
            PtolemyDateTime ptolemyBc = new PtolemyDateTime(-1, 1, 1, 1, 1);
            long ticksInTwoYears = new TimeSpan(365 * 2, 0, 0, 0).Ticks;

            // ACT
            PtolemyDateTime ptolemyAd = ptolemyBc.AddTicks(ticksInTwoYears);

            // ASSERT
            Assert.IsTrue(ptolemyAd.Ticks > 0);
        }

        [Test]
        public void PtolemyDateTimeTicks_SubtractTicksFromAdToBc_TicksAreNegative()
        {
            // ARRANGE
            PtolemyDateTime ptolemyAd = new PtolemyDateTime(2, 1, 1, 1, 1);
            long ticksInTwoYears = new TimeSpan(365 * 2, 0, 0, 0).Ticks;

            // ACT
            PtolemyDateTime ptolemyBc = ptolemyAd.AddTicks(-ticksInTwoYears);

            // ASSERT
            Assert.IsTrue(ptolemyBc.Ticks < 0);
        }

        [Test]
        public void PtolemyDateTimeTicks_AddAndSubtractTicksFromMidPoint_TicksOfDatesAreSymmetrical()
        {
            // ARRANGE
            PtolemyDateTime midPoint = new PtolemyDateTime(0);
            long ticksToChange = 348952347; // arbitrary number

            // ACT
            PtolemyDateTime ptolemyAd = midPoint.AddTicks(ticksToChange);
            PtolemyDateTime ptolemyBc = midPoint.AddTicks(-ticksToChange);

            // ASSERT
            Assert.IsTrue(ptolemyBc.Ticks == -ptolemyAd.Ticks);
        }

        [Test]
        public void PtolemyDateTimeTicks_SubtractDoubleTicksFromAd_TicksForBcDateAreSymmetrical()
        {
            // ARRANGE
            PtolemyDateTime ptolemyAd = new PtolemyDateTime(2, 1, 1, 1, 1);
            long ticks = ptolemyAd.Ticks;

            // ACT
            PtolemyDateTime ptolemyBc = ptolemyAd.AddTicks(2 * (-ticks));

            // ASSERT
            Assert.IsTrue(ptolemyBc.Ticks == -ptolemyAd.Ticks);
        }

        [Test]
        public void PtolemyDateTimeTicks_AddDoubleTicksToBc_TicksForAdDateAreSymmetrical()
        {
            // ARRANGE
            PtolemyDateTime ptolemyBc = new PtolemyDateTime(-1, 1, 1, 1, 1);
            long ticks = -ptolemyBc.Ticks;

            // ACT
            PtolemyDateTime ptolemyAd = ptolemyBc.AddTicks(2 * ticks);

            // ASSERT
            Assert.IsTrue(ptolemyBc.Ticks == -ptolemyAd.Ticks);
        }
    }
}
