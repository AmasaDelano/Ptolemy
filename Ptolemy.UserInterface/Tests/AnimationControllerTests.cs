using NUnit.Framework;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.Tests
{
    [TestFixture]
    public class AnimationControllerTests
    {
        [Test]
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

        [Test]
        public void AnimationController_SetRealTimeUnits_GetRealTimeUnitsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const TimeUnits realTimeUnit = TimeUnits.Day;

            // ACT
            animationController.SetRealTimeUnit(realTimeUnit);

            // ASSERT
            Assert.AreEqual(realTimeUnit, animationController.GetAnimationSpeedInfo().RealTimeUnit);
        }

        [Test]
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

        [Test]
        public void AnimationController_SetSimulatedTimeUnits_GetSimulatedTimeUnitsIsSame()
        {
            // ARRANGE
            AnimationController animationController = new AnimationController();
            const TimeUnits simulatedTimeUnit = TimeUnits.Week;

            // ACT
            animationController.SetSimulatedTimeUnit(simulatedTimeUnit);

            // ASSERT
            Assert.AreEqual(simulatedTimeUnit, animationController.GetAnimationSpeedInfo().SimulatedTimeUnit);
        }
    }
}
