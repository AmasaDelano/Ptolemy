using System;
using System.Windows.Forms;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Views;

namespace Ptolemy.UserInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
