using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Square(4);
            var c = new Circle(2);

            WriteLine(GeometricUtilities.ComputeArea(s));
            WriteLine(GeometricUtilities.ComputeArea(c));

            WriteLine(GeometricUtilities.ComputeAreaModernIs(s));
            WriteLine(GeometricUtilities.ComputeAreaModernIs(c));

            WriteLine(GeometricUtilities.ComputeArea_Version3(s));
            WriteLine(GeometricUtilities.ComputeArea_Version3(c));
            
        }
    }
}
