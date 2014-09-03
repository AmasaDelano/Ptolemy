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

            //_primeMover.SetRealSeconds(1);
            //_primeMover.SetSimulatedSeconds(60 * 60 * 24 * 10);

            //_primeMover.Start();
        }

        #endregion

        #region Public Interface

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

        internal void RegisterTimeAdvanced(System.Action action)
        {
            _animationModel.TimeAdvanced += action;
        }

        #endregion
    }
}
