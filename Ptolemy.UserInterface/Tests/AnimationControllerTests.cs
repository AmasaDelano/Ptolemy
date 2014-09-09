using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.Tests
{
    [TestClass]
    public class AnimationControllerTests
    {
        [TestMethod]
        public void AnimationController_SetRealTimeSteps_GetRealTimeStepsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const int realTimeSteps = 17;

            // ACT
            animationController.SetRealTimeSteps(realTimeSteps);

            // ASSERT
            Assert.AreEqual(realTimeSteps, animationController.GetAnimationSpeedInfo().RealTimeSteps);
        }

        [TestMethod]
        public void AnimationController_SetRealTimeUnits_GetRealTimeUnitsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const TimeUnit realTimeUnit = TimeUnit.Day;

            // ACT
            animationController.SetRealTimeUnit(realTimeUnit);

            // ASSERT
            Assert.AreEqual(realTimeUnit, animationController.GetAnimationSpeedInfo().RealTimeUnit);
        }

        [TestMethod]
        public void AnimationController_SetSimulatedTimeSteps_GetSimulatedTimeStepsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const int simulatedTimeSteps = 277;

            // ACT
            animationController.SetSimulatedTimeSteps(simulatedTimeSteps);

            // ASSERT
            Assert.AreEqual(simulatedTimeSteps, animationController.GetAnimationSpeedInfo().SimulatedTimeSteps);
        }

        [TestMethod]
        public void AnimationController_SetSimulatedTimeUnits_GetSimulatedTimeUnitsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const TimeUnit simulatedTimeUnit = TimeUnit.Week;

            // ACT
            animationController.SetSimulatedTimeUnit(simulatedTimeUnit);

            // ASSERT
            Assert.AreEqual(simulatedTimeUnit, animationController.GetAnimationSpeedInfo().SimulatedTimeUnit);
        }
    }
}
