using System;

namespace ca1715
{
    //<snippet1>
    // This code violates the rule.
    public class Short
    {
        public int Int32 { get; set; }
        public Guid Guid { get; set; }

        public void Float(int int32) { }
    }
    //</snippet1>
}
