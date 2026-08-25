namespace WarningWaves;

public class WaveTen
{
    // <RefFieldNeverAssigned>
    ref struct Container
    {
        // CS9265: Field 'value' is never ref-assigned to,
        // and will always have its default value (null reference)
        public ref int value;
    }
    // </RefFieldNeverAssigned>
}
