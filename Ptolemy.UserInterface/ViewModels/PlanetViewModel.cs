using System.Drawing;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class PlanetViewModel
    {
        #region Member Variables

        private readonly PlanetModel _planetModel;
        private readonly PlanetDrawingData _planetPositionData;

        #endregion

        #region Constructors

        public PlanetViewModel(PlanetModel planetModel)
        {
            _planetModel = planetModel;
            _planetPositionData = planetModel.GetPosition();
        }
        #endregion

        #region Public Interface

        public string Name
        {
            get { return _planetModel.GetName(); }
        }

        public bool ShowAll
        {
            get { return _planetModel.GetShowAll(); }
        }

        public bool ShowOrbits
        {
            get { return _planetModel.GetShowOrbits(); }
        }

        public bool ShowAxes
        {
            get { return _planetModel.GetShowAxes(); }
        }

        public bool ShowPlanet
        {
            get { return _planetModel.GetShowPlanet(); }
        }

        public int Zoom
        {
            get { return (int)_planetModel.GetZoom(); }
        }

        public int PlanetSize
        {
            get { return (int)_planetModel.GetPlanetSize(); }
        }

        public Color PlanetColor
        {
            get { return _planetModel.GetPlanetColor(); }
        }

        public bool HasEquant
        {
            get { return _planetPositionData.HasEquant; }
        }

        public Point DeferentCenter
        {
            get { return _planetPositionData.DeferentCenter; }
        }

        public Point EquantCenter
        {
            get { return _planetPositionData.EquantCenter; }
        }

        public Point EpicycleCenter
        {
            get { return _planetPositionData.EpicycleCenter; }
        }

        public Point PlanetCenter
        {
            get { return _planetPositionData.PlanetCenter; }
        }

        public int RadiusOfDeferent
        {
            get { return (int)_planetPositionData.RadiusOfDeferent; }
        }

        public int RadiusOfEpicycle
        {
            get { return (int)_planetPositionData.RadiusOfEpicycle; }
        }

        #endregion
    }
}
