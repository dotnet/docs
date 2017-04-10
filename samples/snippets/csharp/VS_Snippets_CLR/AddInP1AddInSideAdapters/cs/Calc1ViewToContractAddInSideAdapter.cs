// <Snippet1>
using System.AddIn.Pipeline;
using CalcAddInViews;
using CalculatorContracts;

namespace CalcAddInSideAdapters 
{
    // <Snippet2>
    // The AddInAdapterAttribute identifes this class as the add-in-side adapter
    // pipeline segment.
    [AddInAdapter()]
    public class CalculatorViewToContractAddInSideAdapter :
    	ContractBase, ICalc1Contract 
    {
    // </Snippet2>
        private ICalculator _view;

        public CalculatorViewToContractAddInSideAdapter(ICalculator view) 
        {
            _view = view;
        }

        public virtual double Add(double a, double b) 
        {
            return _view.Add(a, b);
        }

        public virtual double Subtract(double a, double b) 
        {
            return _view.Subtract(a, b);
        }

        public virtual double Multiply(double a, double b) 
        {
            return _view.Multiply(a, b);
        }

        public virtual double Divide(double a, double b) 
        {
            return _view.Divide(a, b);
        }
    }
}
// </Snippet1>