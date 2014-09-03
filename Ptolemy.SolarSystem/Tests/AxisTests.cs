using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Ptolemy.SolarSystem.Tests
{
    [TestClass]
    public class AxisTests
    {
        [TestMethod]
        public void AxisGetDirection_DirectionIsSet_DirectionReturnedIsCorrect()
        {
            // ARRANGE
            double originalDirection = 17.0;
            Axis axis = new Axis(direction: originalDirection, distance: 0);

            // ACT
            double direction = axis.GetDirection();

            // ASSERT
            Assert.AreEqual(originalDirection, direction);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsUp_EndPointIsAboveOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 0, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y > origin.Y && (int)endPoint.X == (int)origin.X);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsDown_EndPointIsBelowOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 180, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y < origin.Y && (int)endPoint.X == (int)origin.X);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsLeft_EndPointIsToLeftOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 270, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.X < origin.X && (int)endPoint.Y == (int)origin.Y);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsRight_EndPointIsToRightOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 90, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.X > origin.X && (int)endPoint.Y == (int)origin.Y);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsUpLeft_EndPointIsAboveAndToLeftOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 270 + 45, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y > origin.Y && endPoint.X < origin.X);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsUpRight_EndPointIsAboveAndToRightOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 45, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y > origin.Y && endPoint.X > origin.X);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsDownLeft_EndPointIsBelowAndToLeftOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 180 + 45, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y < origin.Y && endPoint.X < origin.X);
        }

        [TestMethod]
        public void AxisGetEndPoint_DirectionIsDownRight_EndPointIsBelowAndToRightOfOrigin()
        {
            // ARRANGE
            Axis axis = new Axis(direction: 90 + 45, distance: 1);
            Point origin = new Point(x: 0, y: 0);

            // ACT
            Point endPoint = axis.GetEndPointFromOrigin(origin);

            // ASSERT
            Assert.IsTrue(endPoint.Y < origin.Y && endPoint.X > origin.X);
        }
    }
}
