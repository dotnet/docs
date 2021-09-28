'<SnippetHostSideAdapterCode>

Imports System.AddIn.Contract
Imports System.AddIn.Pipeline
Imports System.Windows

Imports Contracts
Imports HostViews

Namespace HostSideAdapters
	''' <summary>
	''' Adapts the add-in contract to the host's view of the add-in
	''' </summary>
	<HostAdapter>
	Public Class WPFAddIn_ContractToViewHostSideAdapter
        Implements IWPFAddInHostView
		Private wpfAddInContract As IWPFAddInContract
		Private wpfAddInContractHandle As ContractHandle

		Public Sub New(ByVal wpfAddInContract As IWPFAddInContract)
			' Adapt the contract (IWPFAddInContract) to the host application's
			' view of the contract (IWPFAddInHostView)
			Me.wpfAddInContract = wpfAddInContract

			' Prevent the reference to the contract from being released while the
			' host application uses the add-in
			Me.wpfAddInContractHandle = New ContractHandle(wpfAddInContract)
		End Sub

        Public Function GetAddInUI() As FrameworkElement Implements IWPFAddInHostView.GetAddInUI
            ' Convert the INativeHandleContract that was passed from the add-in side
            ' of the isolation boundary to a FrameworkElement
            Dim inhc As INativeHandleContract = Me.wpfAddInContract.GetAddInUI()
            Dim fe As FrameworkElement = FrameworkElementAdapters.ContractToViewAdapter(inhc)
            Return fe
        End Function
	End Class
End Namespace
'</SnippetHostSideAdapterCode>