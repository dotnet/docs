namespace pattern_matching_warnings;

public class Switch
{
    // <SwitchNotAllPossibleValues>
    // CS8509.cs
    enum EnumValues
    {
        Value1, Value2, Value3
    }

    void Method(EnumValues enumValues)
    {
        var result = enumValues switch
        {
            EnumValues.Value1 => 1,
            EnumValues.Value2 => 2,
        };
    }
    // </SwitchNotAllPossibleValues>
}
