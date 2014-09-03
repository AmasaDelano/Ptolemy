using System;
using System.Windows.Forms;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Models;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.ViewModels;

namespace Ptolemy.UserInterface.Views
{
    public partial class MainForm : Form
    {
        #region Member Variables

        private readonly AnimationController _animationController;
        private readonly HeavensController _heavensController;

        #endregion

        #region Constructors
        public MainForm()
        {
            _animationController = new AnimationController();
            _heavensController = new HeavensController();

            InitializeComponent();
        }
        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set up the display options tabs for the planets
            this.SetUpPlanetDisplayTabs();

            // Set up animation controls
            this.SetUpAnimationControls();
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            string buttonText = _animationController.ToggleStart();
            _startButton.Text = buttonText;
        }

        #endregion

        #region Private Helpers

        private void SetUpPlanetDisplayTabs()
        {
            foreach (PlanetEnum planetEnum in SelectList.Of<PlanetEnum>())
            {
                PlanetController planetController = new PlanetController(planetEnum);
                string planetName = planetController.GetPlanetInfo().Name;

                // Create empty tab page
                TabPage planetDisplayTabPage = new TabPage
                {
                    Text = planetName
                };
                // Add custom control to page
                planetDisplayTabPage.Controls.Add(new PlanetDisplayTab(planetController));
                // Add tab page to tab control
                _planetDisplayTabs.TabPages.Add(planetDisplayTabPage);
            }
        }

        private void SetUpAnimationControls()
        {

        }

        #endregion
    }
}