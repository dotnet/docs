using System;

namespace ca2217
{
    //<snippet1>
    // Violates this rule    
    [FlagsAttribute]
    public enum Color
    {
        None = 0,
        Red = 1,
        Orange = 3,
        Yellow = 4
    }
    //</snippet1>

    //<snippet2>
    [FlagsAttribute]
    public enum Days
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        All = Monday | Tuesday | Wednesday | Thursday | Friday
    }
    //</snippet2>
}
