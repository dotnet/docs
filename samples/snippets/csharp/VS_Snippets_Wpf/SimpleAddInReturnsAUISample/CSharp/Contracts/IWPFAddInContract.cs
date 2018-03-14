//<SnippetContractCode>
using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Contracts
{
    /// <summary>
    /// Defines the services that an add-in will provide to a host application
    /// </summary>
    [AddInContract]
    public interface IWPFAddInContract : IContract
    {
        // Return a UI to the host application
        INativeHandleContract GetAddInUI();
    }
}
//</SnippetContractCode>