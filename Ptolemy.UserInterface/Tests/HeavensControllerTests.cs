using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.Tests
{
    [TestClass]
    public class HeavensControllerTests
    {
        [TestMethod]
        public void HeavensController_SetEarthCenter_GetEarthCenterIsSame()
        {
            // ARRANGE
            HeavensController heavensController = new HeavensController(new HeavensModel());
            Point earthCenterToSet = new Point(x: 22, y: 476);

            // ACT
            heavensController.SetEarthCenter(x: earthCenterToSet.X, y: earthCenterToSet.Y);

            // ASSERT
            Assert.AreEqual(earthCenterToSet, heavensController.GetEarthCenter());
        }

        [TestMethod]
        public void HeavensController_RegisterHeavensChangedEvent_EventIsTriggeredWhenHeavensChange()
        {
            // ARRANGE
            HeavensModel heavensModel = new HeavensModel();
            HeavensController heavensController = new HeavensController(heavensModel);

            // ACT
            heavensController.RegisterHasChangedEvent(() => { throw new Exception(); });

            // ASSERT
            try
            {
                heavensModel.OnHasChanged();
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
