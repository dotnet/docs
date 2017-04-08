// <Snippet1>
using System.AddIn.Pipeline;
using CalcHVAs;
using CalculatorContracts;

namespace CalcHostSideAdapters 
{
    // <Snippet2>
    // The HostAdapterAttribute identifes this class as the host-side adapter
    // pipeline segment.
    [HostAdapterAttribute()]
    public class CalculatorContractToViewHostSideAdapter : ICalculator 
    {
    // </Snippet2>
        private ICalc1Contract _contract;
        private System.AddIn.Pipeline.ContractHandle _handle;

        public CalculatorContractToViewHostSideAdapter(ICalc1Contract contract) 
        {
            _contract = contract;
            _handle = new ContractHandle(contract);
        }

        public double Add(double a, double b) 
        {
            return _contract.Add(a, b);
        }

        public double Subtract(double a, double b) 
        {
            return _contract.Subtract(a, b);
        }

        public double Multiply(double a, double b) 
        {
            return _contract.Multiply(a, b);
        }

        public double Divide(double a, double b) 
        {
            return _contract.Divide(a, b);
        }
    }
}
// </Snippet1>