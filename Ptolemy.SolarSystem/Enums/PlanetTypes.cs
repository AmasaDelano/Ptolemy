using System.ComponentModel;

namespace Ptolemy.SolarSystem
{
    public enum PlanetTypes
    {
        [Description("Sun (Deferent)")]
        SunDeferent = 1,
        [Description("Sun (Epicycle)")]
        SunEpicycle = 2,
        Venus = 3,
        Mars = 4,
        Jupiter = 5,
        Saturn = 6
    }
}
