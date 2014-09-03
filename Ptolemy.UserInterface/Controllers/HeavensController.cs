using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Ptolemy.UserInterface.Models;
using Ptolemy.SolarSystem;

namespace Ptolemy.UserInterface.Controllers
{
    internal class HeavensController
    {
        #region Member Variables

        private readonly HeavensModel _heavensModel;

        #endregion

        #region Constructors
        public HeavensController()
        {
            _heavensModel = ModelFactory.GetHeavensModel();
        }
        #endregion

        #region Public Interface
        internal void SetEarthCenter(int x, int y)
        {
            _heavensModel.SetEarthCenter(new Point(x: x, y: y));
        }

        internal Point GetEarthCenter()
        {
            return _heavensModel.GetEarthCenter();
        }

        internal void RegisterHasChangedEvent(System.Action action)
        {
            _heavensModel.HasChanged += action;
        }
        #endregion
    }
}
