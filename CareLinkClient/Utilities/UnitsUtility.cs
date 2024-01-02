using UnitsNet.Units;
using UnitsNet;

namespace CareLinkClient.Utilities;

public static class UnitsUtility
{
    /// <summary>
    /// Source: https://webbook.nist.gov/cgi/cbook.cgi?ID=C50997&Type=THZ-IR-SPEC&Index=0
    /// </summary>
    public static MolarMass GlucoseMolecularWeight { get; } = new (180.1559, MolarMassUnit.GramPerMole);
}
