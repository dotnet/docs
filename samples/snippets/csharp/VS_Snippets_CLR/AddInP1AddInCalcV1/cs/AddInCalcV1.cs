// <Snippet1>
using System.Collections.Generic;
using System.AddIn;
using CalcAddInViews;

namespace CalcAddIns
{
    // The AddInAttribute identifies this pipeline segment as an add-in.
    [AddIn("Calculator AddIn",Version="1.0.0.0")]
    public class AddInCalcV1 : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
// </Snippet1>