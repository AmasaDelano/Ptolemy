using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Models;

namespace Ptolemy.UserInterface.Tests
{
    [TestClass]
    public class PlanetControllerTests
    {
        [TestMethod]
        public void PlanetController_SetColor_GetColorIsSameColor()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.Venus);
            PlanetController planetController = new PlanetController(planetModel);
            Color colorToSet = Color.Tomato;

            // ACT
            planetController.SetPlanetColor(colorToSet);

            // ASSERT
            Assert.AreEqual(colorToSet, planetController.GetPlanetInfo().PlanetColor);
        }

        [TestMethod]
        public void PlanetController_SetZoom_GetZoomIsSameZoom()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.SunDeferent);
            PlanetController planetController = new PlanetController(planetModel);
            const double zoomToSet = 3;

            // ACT
            planetController.SetZoom(zoomToSet);

            // ASSERT
            Assert.AreEqual(zoomToSet, planetController.GetPlanetInfo().Zoom);
        }

        [TestMethod]
        public void PlanetController_SetPlanetSize_GetPlanetSizeIsSamePlanetSize()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.Jupiter);
            PlanetController planetController = new PlanetController(planetModel);
            const double sizeToSet = 1;

            // ACT
            planetController.SetPlanetSize(sizeToSet);

            // ASSERT
            Assert.AreEqual(sizeToSet, planetController.GetPlanetInfo().PlanetSize);
        }

        [TestMethod]
        public void PlanetController_SetShowAll_GetShowAllIsSameShowAll()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.Saturn);
            PlanetController planetController = new PlanetController(planetModel);
            const bool showAllToSet = true;

            // ACT
            planetController.SetShowAll(showAllToSet);

            // ASSERT
            Assert.AreEqual(showAllToSet, planetController.GetPlanetInfo().ShowAll);
        }

        [TestMethod]
        public void PlanetController_SetShowOrbits_GetShowOrbitsIsSameShowOrbits()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.SunEpicycle);
            PlanetController planetController = new PlanetController(planetModel);
            const bool showOrbitsToSet = true;

            // ACT
            planetController.SetShowOrbits(showOrbitsToSet);

            // ASSERT
            Assert.AreEqual(showOrbitsToSet, planetController.GetPlanetInfo().ShowOrbits);
        }

        [TestMethod]
        public void PlanetController_SetShowAxes_GetShowAxesIsSameShowAxes()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.Mars);
            PlanetController planetController = new PlanetController(planetModel);
            const bool showAxesToSet = true;

            // ACT
            planetController.SetShowAxes(showAxesToSet);

            // ASSERT
            Assert.AreEqual(showAxesToSet, planetController.GetPlanetInfo().ShowAxes);
        }

        [TestMethod]
        public void PlanetController_SetShowPlanet_GetShowPlanetIsSameShowShowPlanet()
        {
            // ARRANGE
            PlanetModel planetModel = new PlanetModel(new SolarSystem.SolarSystem(), PlanetTypes.Venus);
            PlanetController planetController = new PlanetController(planetModel);
            const bool showPlanetToSet = true;

            // ACT
            planetController.SetShowPlanet(showPlanetToSet);

            // ASSERT
            Assert.AreEqual(showPlanetToSet, planetController.GetPlanetInfo().ShowPlanet);
        }
    }
}
