using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    /// <summary>
    /// The main program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
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
