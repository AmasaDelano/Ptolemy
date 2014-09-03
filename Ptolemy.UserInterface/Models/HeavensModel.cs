using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Ptolemy.SolarSystem;

namespace Ptolemy.UserInterface.Models
{
    internal class HeavensModel
    {
        #region Member Variables

        private Point _earthCenter;
        private double _zoom = 1.0;

        #endregion

        #region Constructors

        internal HeavensModel()
        {
        }
        #endregion

        #region Public Interface

        internal event System.Action HasChanged;

        internal void OnHasChanged()
        {
            if (HasChanged != null)
            {
                HasChanged();
            }
        }

        internal void SetEarthCenter(Point earthCenter)
        {
            _earthCenter.X = earthCenter.X;
            _earthCenter.Y = earthCenter.Y;
        }

        internal Point GetEarthCenter()
        {
            return _earthCenter;
        }

        internal void SetZoom(double zoom)
        {
            _zoom = zoom;
            this.OnHasChanged();
        }

        internal double GetZoom()
        {
            return _zoom;
        }

        #endregion
    }
}
