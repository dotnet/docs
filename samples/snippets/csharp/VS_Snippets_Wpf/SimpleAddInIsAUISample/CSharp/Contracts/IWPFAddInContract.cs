//<SnippetContractCode>
using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Contracts
{
    /// <summary>
    /// Defines the services that an add-in will provide to a host application.
    /// In this case, the add-in is a UI.
    /// </summary>
    [AddInContract]
    public interface IWPFAddInContract : INativeHandleContract {}
}
//</SnippetContractCode>