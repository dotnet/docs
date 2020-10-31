using System;

namespace ca1027
{
    //<snippet1>
    // Violates rule: MarkEnumsWithFlags.
    public enum DaysEnumNeedsFlags
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        All = Monday | Tuesday | Wednesday | Thursday | Friday
    }

    // Violates rule: DoNotMarkEnumsWithFlags.
    [FlagsAttribute]
    public enum ColorEnumShouldNotHaveFlag
    {
        None = 0,
        Red = 1,
        Orange = 3,
        Yellow = 4
    }
    //</snippet1>
}
