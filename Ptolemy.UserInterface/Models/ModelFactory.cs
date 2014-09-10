using System.Collections.Generic;
using Ptolemy.SolarSystem;

namespace Ptolemy.UserInterface.Models
{
    internal static class ModelFactory
    {
        #region Class Variables
        private static AnimationModel _animationModel;
        private static HeavensModel _heavensModel;
        private static SolarSystem.SolarSystem _solarSystem;
        private static readonly Dictionary<PlanetEnum, PlanetModel> PlanetModels = new Dictionary<PlanetEnum, PlanetModel>();
        #endregion

        #region Public Interface
        public static AnimationModel GetAnimationModel()
        {
            if (_animationModel == null)
            {
                _animationModel = new AnimationModel(ModelFactory.GetSolarSystem());
            }

            return _animationModel;
        }

        public static HeavensModel GetHeavensModel()
        {
            if (_heavensModel == null)
            {
                _heavensModel = new HeavensModel(ModelFactory.GetSolarSystem());
            }

            return _heavensModel;
        }

        public static PlanetModel GetPlanetModel(PlanetEnum planetEnum)
        {
            if (PlanetModels.ContainsKey(planetEnum) && PlanetModels[planetEnum] != null)
            {
                return PlanetModels[planetEnum];
            }

            PlanetModel planetModel = new PlanetModel(ModelFactory.GetSolarSystem(), planetEnum);
            PlanetModels[planetEnum] = planetModel;

            return planetModel;
        }
        #endregion

        #region Private Helpers
        private static SolarSystem.SolarSystem GetSolarSystem()
        {
            if (_solarSystem == null)
            {
                _solarSystem = new SolarSystem.SolarSystem();
            }

            return _solarSystem;
        }
        #endregion
    }
}
