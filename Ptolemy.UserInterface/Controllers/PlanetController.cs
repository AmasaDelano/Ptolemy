using System.Drawing;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.Models;
using Ptolemy.UserInterface.ViewModels;

namespace Ptolemy.UserInterface.Controllers
{
    internal class PlanetController
    {
        #region Member Variables

        private readonly PlanetModel _planetModel;

        #endregion

        #region Constructors

        public PlanetController(PlanetEnum planetEnum)
        {
            _planetModel = ModelFactory.GetPlanetModel(planetEnum);
        }

        public PlanetController(PlanetModel planetModel)
        {
            _planetModel = planetModel;
        }

        #endregion

        #region Public Interface

        public PlanetViewModel GetPlanetInfo()
        {
            return new PlanetViewModel(_planetModel);
        }

        public void SetShowAll(bool showAll)
        {
            _planetModel.SetShowAll(showAll);
        }

        public void SetShowOrbits(bool showOrbits)
        {
            _planetModel.SetShowOrbits(showOrbits);
        }

        public void SetShowAxes(bool showAxes)
        {
            _planetModel.SetShowAxes(showAxes);
        }

        public void SetShowPlanet(bool showPlanet)
        {
            _planetModel.SetShowPlanet(showPlanet);
        }

        public void SetZoom(double zoom)
        {
            _planetModel.SetZoom(zoom / 100);
        }

        public void SetPlanetSize(double planetSize)
        {
            _planetModel.SetPlanetSize(planetSize);
        }

        public void SetPlanetColor(Color planetColor)
        {
            _planetModel.SetPlanetColor(planetColor);
        }

        #endregion
    }
}
