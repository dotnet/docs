//<SnippetContractCode>
using System.AddIn.Contract; // INativeHandleContract
using System.AddIn.Pipeline; // AddInContractAttribute

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