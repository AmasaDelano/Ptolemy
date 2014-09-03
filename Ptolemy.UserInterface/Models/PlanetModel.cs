using System.Drawing;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.ViewModels;

namespace Ptolemy.UserInterface.Models
{
    internal class PlanetModel
    {
        #region Member Variables
        
        private readonly SolarSystem.SolarSystem _solarSystem;
        private readonly PlanetEnum _planetEnum;
        private readonly HeavensModel _heavensModel;

        private bool _showAll = true;
        private bool _showOrbits = true;
        private bool _showAxes = true;
        private bool _showPlanet = true;
        private double _zoom = 1.0;
        private double _planetSize;
        private Color _planetColor;

        #endregion

        #region Constructors

        public PlanetModel(SolarSystem.SolarSystem solarSystem, PlanetEnum planetEnum)
        {
            _solarSystem = solarSystem;
            _planetEnum = planetEnum;

            _heavensModel = ModelFactory.GetHeavensModel();
        }
        #endregion

        #region Public Interface

        public void SetShowAll(bool showAll)
        {
            _showAll = showAll;
            _heavensModel.OnHasChanged();
        }

        public bool GetShowAll()
        {
            return _showAll;
        }

        public void SetShowOrbits(bool showOrbits)
        {
            _showOrbits = showOrbits;
            _heavensModel.OnHasChanged();
        }

        public bool GetShowOrbits()
        {
            return _showOrbits;
        }

        public void SetShowAxes(bool showAxes)
        {
            _showAxes = showAxes;
            _heavensModel.OnHasChanged();
        }

        public bool GetShowAxes()
        {
            return _showAxes;
        }

        public void SetShowPlanet(bool showPlanet)
        {
            _showPlanet = showPlanet;
            _heavensModel.OnHasChanged();
        }

        public bool GetShowPlanet()
        {
            return _showPlanet;
        }

        public void SetZoom(double zoom)
        {
            _zoom = zoom;
            _heavensModel.OnHasChanged();
        }

        public double GetZoom()
        {
            return _zoom;
        }

        public void SetPlanetSize(double planetSize)
        {
            _planetSize = planetSize;
            _heavensModel.OnHasChanged();
        }

        public double GetPlanetSize()
        {
            return _planetSize;
        }

        public void SetPlanetColor(Color planetColor)
        {
            _planetColor = planetColor;
            _heavensModel.OnHasChanged();
        }

        public Color GetPlanetColor()
        {
            return _planetColor;
        }

        public string GetName()
        {
            return _planetEnum.ToString();
        }

        /// <summary>
        /// Gets position data with translated earth center, planet zoom, overall zoom, and Aries direction all accounted for.
        /// </summary>
        /// <returns></returns>
        public PlanetDrawingData GetPosition()
        {
            // Get raw data
            PlanetPositionData rawData = _solarSystem.GetPlanetPositionData(_planetEnum);

            // Assign raw data to manipulatable variables
            System.Windows.Point deferentCenter = rawData.DeferentCenter;
            System.Windows.Point equantCenter = rawData.EquantCenter;
            System.Windows.Point epicycleCenter = rawData.EpicycleCenter;
            System.Windows.Point planetCenter = rawData.PlanetCenter;
            double radiusOfDeferent = rawData.RadiusOfDeferent;
            double radiusOfEpicycle = rawData.RadiusOfEpicycle;

            // Account for planet and overall zoom
            deferentCenter = this.ZoomPoint(deferentCenter);
            equantCenter = this.ZoomPoint(equantCenter);
            epicycleCenter = this.ZoomPoint(epicycleCenter);
            planetCenter = this.ZoomPoint(planetCenter);
            radiusOfDeferent = radiusOfDeferent * CombinedZoom;
            radiusOfEpicycle = radiusOfEpicycle * CombinedZoom;

            // Translate, accounting for earth center
            deferentCenter = this.AddEarthCenter(deferentCenter);
            equantCenter = this.AddEarthCenter(equantCenter);
            epicycleCenter = this.AddEarthCenter(epicycleCenter);
            planetCenter = this.AddEarthCenter(planetCenter);

            // Round off all values and package them up into drawable properties in a DTO
            return new PlanetDrawingData
            {
                DeferentCenter = this.RoundPoint(deferentCenter),
                EquantCenter = this.RoundPoint(equantCenter),
                EpicycleCenter = this.RoundPoint(epicycleCenter),
                PlanetCenter = this.RoundPoint(planetCenter),
                HasEquant = rawData.HasEquant,
                RadiusOfDeferent = (int) radiusOfDeferent,
                RadiusOfEpicycle = (int) radiusOfEpicycle
            };
        }
        #endregion

        #region Private Helpers

        private double CombinedZoom
        {
            get { return _zoom * _heavensModel.GetZoom();  }
        }

        private System.Windows.Point AddEarthCenter(System.Windows.Point point)
        {
            System.Drawing.Point earthCenter = _heavensModel.GetEarthCenter();
            return new System.Windows.Point(x: earthCenter.X + point.X, y: earthCenter.Y + point.Y);
        }

        private System.Windows.Point ZoomPoint(System.Windows.Point point)
        {
            return new System.Windows.Point(x: point.X * CombinedZoom, y: point.Y * CombinedZoom);
        }

        private System.Drawing.Point RoundPoint(System.Windows.Point point)
        {
            return new System.Drawing.Point(x: (int) point.X, y: (int) point.Y);
        }

        #endregion
    }
}
