// <Snippet1>
using System.AddIn.Pipeline;
using CalcHVAs;
using CalculatorContracts;

namespace CalcHostSideAdapters {
    
    
[HostAdapter]
public class CalculatorContractToViewHostAdapter : Calculator {

// <Snippet2>        
    private CalculatorContracts.ICalc2Contract _contract;

    private System.AddIn.Pipeline.ContractHandle _handle;

    public CalculatorContractToViewHostAdapter(ICalc2Contract contract) {
        _contract = contract;
        _handle = new System.AddIn.Pipeline.ContractHandle(contract);
    }
// </Snippet2>


    public override string Operations
    {
        get 
        { 
            return _contract.GetAvailableOperations(); 
        }
    }

    public override double Operate(string operation, double a, double b)
    {
        return _contract.Operate(operation, a, b);
    }
 }
}
// </Snippet1>