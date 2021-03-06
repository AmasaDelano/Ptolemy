﻿using Ptolemy.UserInterface.Enums;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.Controllers
{
    internal class AnimationController
    {
        #region Member Variables

        private readonly AnimationModel _animationModel;

        #endregion

        #region Constructors

        public AnimationController()
        {
            _animationModel = ModelFactory.GetAnimationModel();
        }

        public AnimationController(AnimationModel animationModel)
        {
            _animationModel = animationModel;
        }

        #endregion

        #region Public Interface

        internal ViewModels.AnimationSpeedViewModel GetAnimationSpeedInfo()
        {
            return new ViewModels.AnimationSpeedViewModel(_animationModel);
        }

        public void SetRealTimeUnit(TimeUnits timeUnit)
        {
            _animationModel.SetRealTimeUnit(timeUnit);
        }

        public void SetRealTimeSteps(int timeStep)
        {
            _animationModel.SetRealTimeSteps(timeStep);
        }

        public void SetSimulatedTimeUnit(TimeUnits timeUnit)
        {
            _animationModel.SetSimulatedTimeUnit(timeUnit);
        }

        public void SetSimulatedTimeSteps(int timeStep)
        {
            _animationModel.SetSimulatedTimeSteps(timeStep);
        }

        internal string ToggleStart()
        {
            if (!_animationModel.IsRunning)
            {
                _animationModel.Start();
                return "Stop";
            }
            else
            {
                _animationModel.Pause();
                return "Start";
            }
        }

        #endregion
    }
}
