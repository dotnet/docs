'<SnippetContractCode>

Imports System.AddIn.Contract ' IContract, INativeHandleContract
Imports System.AddIn.Pipeline ' AddInContractAttribute

Namespace Contracts
	''' <summary>
	''' Defines the services that an add-in will provide to a host application
	''' </summary>
	<AddInContract>
	Public Interface IWPFAddInContract
		Inherits IContract
		' Return a UI to the host application
		Function GetAddInUI() As INativeHandleContract
	End Interface
End Namespace
'</SnippetContractCode>