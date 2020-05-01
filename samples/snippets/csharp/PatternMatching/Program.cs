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
            var s = CreateShape("square");
            var c = CreateShape("circle");

            WriteLine(GeometricUtilities.ComputeArea(s));
            WriteLine(GeometricUtilities.ComputeArea(c));

            WriteLine(GeometricUtilities.ComputeAreaModernIs(s));
            WriteLine(GeometricUtilities.ComputeAreaModernIs(c));

            WriteLine(GeometricUtilities.ComputeArea_Version3(s));
            WriteLine(GeometricUtilities.ComputeArea_Version3(c));

            var what = CreateShape("       ");
            WriteLine(what);

            var wrong = CreateShape("trapezoid");
            WriteLine(wrong);
        }

#region VarCaseExpression
        static object CreateShape(string shapeDescription)
        {
            switch (shapeDescription)
            {
                case "circle":
                    return new Circle(2);

                case "square":
                    return new Square(4);

                case "large-circle":
                    return new Circle(12);

                case var o when (o?.Trim().Length ?? 0) == 0:
                    // white space
                    return null;
                default:
                    return "invalid shape description";
            }
        }
#endregion
    }
}
