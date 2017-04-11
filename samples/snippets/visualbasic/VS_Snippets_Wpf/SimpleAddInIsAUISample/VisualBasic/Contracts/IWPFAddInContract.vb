'<SnippetContractCode>

Imports System.AddIn.Contract ' INativeHandleContract
Imports System.AddIn.Pipeline ' AddInContractAttribute

Namespace Contracts
	''' <summary>
	''' Defines the services that an add-in will provide to a host application.
	''' In this case, the add-in is a UI.
	''' </summary>
	<AddInContract>
	Public Interface IWPFAddInContract
        Inherits INativeHandleContract
        Inherits IContract
	End Interface
End Namespace
'</SnippetContractCode>