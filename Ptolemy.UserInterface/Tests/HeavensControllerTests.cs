using System;
using System.Drawing;
using NUnit.Framework;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.Tests
{
    [TestFixture]
    public class HeavensControllerTests
    {
        [Test]
        public void HeavensController_SetEarthCenter_GetEarthCenterIsSame()
        {
            // ARRANGE
            HeavensModel heavensModel = new HeavensModel(new SolarSystem.SolarSystem());
            HeavensController heavensController = new HeavensController(heavensModel);
            Point earthCenterToSet = new Point(x: 22, y: 476);

            // ACT
            heavensController.SetEarthCenter(x: earthCenterToSet.X, y: earthCenterToSet.Y);

            // ASSERT
            Assert.AreEqual(earthCenterToSet, heavensController.GetEarthCenter());
        }

        [Test]
        public void HeavensController_RegisterHeavensChangedEvent_EventIsTriggeredWhenHeavensChange()
        {
            // ARRANGE
            HeavensModel heavensModel = new HeavensModel(new SolarSystem.SolarSystem());
            HeavensController heavensController = new HeavensController(heavensModel);

            // ACT
            heavensController.RegisterHasChangedEvent(() => { throw new Exception(); });

            // ASSERT
            Assert.Catch<Exception>(heavensModel.OnHasChanged);
        }

        [Test]
        public void HeavensController_SetTimeToEpoch_TimeIsEpoch()
        {
            // ARRANGE
            HeavensModel heavensModel = new HeavensModel(new SolarSystem.SolarSystem());
            HeavensController heavensController = new HeavensController(heavensModel);

            // ACT
            heavensController.SetTimeToEpoch();

            // ASSERT
            Assert.AreEqual(PtolemyDateTime.TimeOfEpoch, heavensController.GetCurrentTime());
        }

        [Test]
        public void HeavensController_SetTimeToNow_TimeIsNow()
        {
            // ARRANGE
            HeavensModel heavensModel = new HeavensModel(new SolarSystem.SolarSystem());
            HeavensController heavensController = new HeavensController(heavensModel);

            // ACT
            heavensController.SetTimeToNow();

            // ASSERT
            Assert.AreEqual(PtolemyDateTime.Now, heavensController.GetCurrentTime());
        }
    }
}
