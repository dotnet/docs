// <Snippet1>
using System.AddIn.Pipeline;

namespace CalcAddInViews 
{
    // <Snippet2>
    // The AddInBaseAttribute identifes this interface as the basis for
    // the add-in view pipeline segment.
    [AddInBase()]
    public interface ICalculator 
    {
    // </Snippet2>
	double Add(double a, double b);
	double Subtract(double a, double b);
	double Multiply(double a, double b);
	double Divide(double a, double b);
    }
}
// </Snippet1>