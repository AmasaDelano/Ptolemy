using System.Windows;

namespace Ptolemy.SolarSystem
{
    public sealed class PlanetPositionData
    {
        public Point DeferentCenter { get; internal set; }
        public Point EquantCenter { get; internal set; }
        public Point EpicycleCenter { get; internal set; }
        public Point PlanetCenter { get; internal set; }

        public double RadiusOfDeferent { get; internal set; }
        public double RadiusOfEpicycle { get; internal set; }
        public bool HasEquant { get; internal set; }
    }
}
