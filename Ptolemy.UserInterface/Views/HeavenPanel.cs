using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.ViewModels;
using Ptolemy.UserInterface.Models;
using Ptolemy.SolarSystem;

namespace Ptolemy.UserInterface.Views
{
    /// <summary>
    /// Panel for drawing the planets and their orbits.
    /// </summary>
    internal class HeavenPanel : Panel
    {
        #region Member Variables
        private readonly HeavensController _heavensController;
        private readonly List<PlanetController> _planetControllers;

        private readonly Pen _blackPen = new Pen(Color.Black, 2);
        #endregion

        #region Constructors
        public HeavenPanel()
        {
            _heavensController = new HeavensController();
            _planetControllers = SelectList.Of<PlanetEnum>().Select(e => new PlanetController(e)).ToList();
            
            // Attach events
            SizeChanged += OnSizeChangedUpdateCenter;
            _heavensController.RegisterHasChangedEvent(this.Invalidate);
        }
        #endregion

        #region Overridden Methods

        private void OnSizeChangedUpdateCenter(object o, EventArgs e)
        {
            _heavensController.SetEarthCenter(x: this.Width / 2, y: this.Height / 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;

            //BufferedGraphics bufferedGraphics = new BufferedGraphicsContext().Allocate(e.Graphics, new Rectangle((int)e.Graphics.ClipBounds.X, (int)e.Graphics.ClipBounds.Y, (int)e.Graphics.ClipBounds.Width, (int)e.Graphics.ClipBounds.Height));

            // Get planet data from the solar system
            List<PlanetViewModel> planets = _planetControllers.Select(p => p.GetPlanetInfo())
                .Where(p => p.ShowAll)
                .ToList();

            // Draw planets on top of orbits on top of axes.
            this.DrawAxes(e.Graphics, planets);
            this.DrawOrbits(e.Graphics, planets);
            this.DrawPlanets(e.Graphics, planets);
        }

        #endregion

        #region Private Helpers

        private void DrawOrbits(Graphics g, IEnumerable<PlanetViewModel> planets)
        {
            foreach (PlanetViewModel planet in planets.Where(p => p.ShowOrbits))
            {
                // Deferent orbit
                this.DrawCircle(g,
                    center: planet.DeferentCenter,
                    radius: planet.RadiusOfDeferent);

                // Epicycle orbit
                this.DrawCircle(g,
                    center: planet.EpicycleCenter,
                    radius: planet.RadiusOfEpicycle);
            }
        }
        private void DrawAxes(Graphics g, IEnumerable<PlanetViewModel> planets)
        {
            foreach (PlanetViewModel planet in planets.Where(p => p.ShowAxes))
            {
                // Earth to deferent center
                this.DrawAxis(g,
                    point1: _heavensController.GetEarthCenter(),
                    point2: planet.HasEquant ? planet.EquantCenter : planet.DeferentCenter);
                // Deferent center to epicycle center
                this.DrawAxis(g,
                    point1: planet.DeferentCenter,
                    point2: planet.EpicycleCenter);
                // Equant center to epicycle center
                if (planet.HasEquant)
                {
                    this.DrawAxis(g,
                        point1: planet.EquantCenter,
                        point2: planet.EpicycleCenter);
                }
                // Epicycle center to planet center
                this.DrawAxis(g,
                    point1: planet.EpicycleCenter,
                    point2: planet.PlanetCenter);
            }
        }
        private void DrawPlanets(Graphics g, IEnumerable<PlanetViewModel> planets)
        {
            foreach (PlanetViewModel planet in planets.Where(p => p.ShowPlanet))
            {
                Pen planetPen = new Pen(planet.PlanetColor);

                g.DrawEllipse(pen: planetPen,
                    x: planet.PlanetCenter.X - (planet.PlanetSize / 2),
                    y: planet.PlanetCenter.X - (planet.PlanetSize / 2),
                    width: planet.PlanetSize,
                    height: planet.PlanetSize);
            }
        }

        private void DrawCircle(Graphics g, Point center, int radius)
        {
            g.DrawEllipse(pen: _blackPen,
                x: center.X - radius,
                y: center.Y - radius,
                width: radius * 2,
                height: radius * 2);
        }
        private void DrawAxis(Graphics g, Point point1, Point point2)
        {
            g.DrawLine(pen: _blackPen, pt1: point1, pt2: point2);
        }
        #endregion
    }
}
