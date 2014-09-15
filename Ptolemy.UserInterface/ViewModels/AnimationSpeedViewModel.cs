using Ptolemy.UserInterface.Enums;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class AnimationSpeedViewModel
    {
        #region Member Variables

        private readonly AnimationModel _animationModel;

        #endregion

        #region Constructors

        internal AnimationSpeedViewModel(AnimationModel animationModel)
        {
            _animationModel = animationModel;
        }

        #endregion

        #region Public Interface

        internal int RealTimeSteps
        {
            get { return _animationModel.GetRealTimeSteps(); }
        }

        internal int SimulatedTimeSteps
        {
            get { return _animationModel.GetSimulatedTimeSteps(); }
        }

        internal TimeUnits RealTimeUnit
        {
            get { return _animationModel.GetRealTimeUnit(); }
        }

        internal TimeUnits SimulatedTimeUnit
        {
            get { return _animationModel.GetSimulatedTimeUnit(); }
        }

        #endregion
    }
}
