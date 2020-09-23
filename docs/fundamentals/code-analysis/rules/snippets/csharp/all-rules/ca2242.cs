using System;

namespace ca2242
{
    //<snippet1>
    class NaNTests
    {
        static double zero;

        static void Main2242()
        {
            Console.WriteLine(0 / zero == double.NaN);
            Console.WriteLine(0 / zero != double.NaN);
            Console.WriteLine(double.IsNaN(0 / zero));
        }
    }
    //</snippet1>
}
