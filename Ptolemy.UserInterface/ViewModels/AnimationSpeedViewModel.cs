using Ptolemy.UserInterface.Enums;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class AnimationSpeedViewModel
    {
        #region Member Variables

        private AnimationModel _animationModel;

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

        internal TimeUnit RealTimeUnit
        {
            get { return _animationModel.GetRealTimeUnit(); }
        }

        internal TimeUnit SimulatedTimeUnit
        {
            get { return _animationModel.GetSimulatedTimeUnit(); }
        }

        #endregion
    }
}
