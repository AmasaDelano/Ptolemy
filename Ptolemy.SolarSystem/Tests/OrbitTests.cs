using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Ptolemy.SolarSystem.Tests
{
    [TestClass]
    public class OrbitTests
    {
        [TestMethod]
        public void OrbitGetPosition_DirectionIsUpAndTimeIsEpoch_PositionIsAboveCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 0,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue((int)position.X == (int)center.X && position.Y > center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsDownAndTimeIsEpoch_PositionIsBelowCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 180,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue((int)position.X == (int)center.X && position.Y < center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsLeftAndTimeIsEpoch_PositionIsToLeftOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 270,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X < center.X && (int)position.Y == (int)center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsRightAndTimeIsEpoch_PositionIsToRightOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 90,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X > center.X && (int)position.Y == (int)center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsUpLeftAndTimeIsEpoch_PositionIsAboveAndToLeftOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 270 + 45,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X < center.X && position.Y > center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsUpRightAndTimeIsEpoch_PositionIsAboveAndToRightOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 45,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X > center.X && position.Y > center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsDownLeftAndTimeIsEpoch_PositionIsBelowAndToLeftOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 180 + 45,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X < center.X && position.Y < center.Y);
        }

        [TestMethod]
        public void OrbitGetPosition_DirectionIsDownRightAndTimeIsEpoch_PositionIsBelowAndToRightOfCenter()
        {
            // ARRANGE
            Orbit orbit = new Orbit(
                directionAtEpoch: 90 + 45,
                radius: 100,
                rotationsOfOrbitPerPeriod: 1,
                rotationsOfMeanSunPerPeriod: 1);
            Point center = new Point(0.0, 0.0);

            // ACT
            Point position = orbit.GetPosition(PtolemyDateTime.TimeOfEpoch);

            // ASSERT
            Assert.IsTrue(position.X > center.X && position.Y < center.Y);
        }
    }
}
