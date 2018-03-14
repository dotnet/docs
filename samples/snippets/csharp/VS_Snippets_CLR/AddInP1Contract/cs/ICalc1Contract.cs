//<Snippet1>
using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace CalculatorContracts
{
    // <Snippet2>
    // The AddInContractAttribute identifes this pipeline segment as a 
    // contract.
    [AddInContract]
    public interface ICalc1Contract : IContract
    {
    // </Snippet2>
	double Add(double a, double b);
	double Subtract(double a, double b);
	double Multiply(double a, double b);
	double Divide(double a, double b);
    }
}
//</Snippet1>
