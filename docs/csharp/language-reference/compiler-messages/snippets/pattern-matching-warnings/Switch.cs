namespace firstExample
{

    public class Switch
    {
        // <SwitchNotAllPossibleValues>
        // CS8509.cs
        enum EnumValues
        {
            Value1,
            Value2,
            Value3
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

        public static void RedundantPattern()
        {
            object? o = null;
            // <RedundantPattern>
            _ = o is not null or 42; // warning: pattern "42" is redundant
            _ = o is not int or string; // warning: pattern "string" is redundant
            // </RedundantPattern>
        }
    }
}

namespace secondExample
{
    public class Switch
    {
        // <SwitchAllPossibleValues>
        enum EnumValues
        {
            Value1,
            Value2,
            Value3
        }

        void Method(EnumValues enumValues)
        {
            var result = enumValues switch
            {
                EnumValues.Value1 => 1,
                EnumValues.Value2 => 2,
                EnumValues.Value3 => 3,
                _ => throw new ArgumentException("Input isn't a valid enum value", nameof(enumValues)),
                };
        }
        // </SwitchAllPossibleValues>
    }
}
