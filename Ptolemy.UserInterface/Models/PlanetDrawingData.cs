using System.Drawing;

namespace Ptolemy.UserInterface.Models
{
    internal class PlanetDrawingData
    {
        internal Point DeferentCenter { get; set; }
        internal Point EquantCenter { get; set; }
        internal Point EpicycleCenter { get; set; }
        internal Point PlanetCenter { get; set; }

        internal double RadiusOfDeferent { get; set; }
        internal double RadiusOfEpicycle { get; set; }
        internal bool HasEquant { get; set; }
    }
}
