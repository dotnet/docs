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
		Inherits WPFAddInHostView
        Private wpfAddInContract As IWPFAddInContract
		Private wpfAddInContractHandle As ContractHandle

        Public Sub New(ByVal wpfAddInContract As IWPFAddInContract)
            ' Adapt the contract (IWPFAddInContract) to the host application's
            ' view of the contract (WPFAddInHostView)
            Me.wpfAddInContract = wpfAddInContract

            ' Prevent the reference to the contract from being released while the
            ' host application uses the add-in
            Me.wpfAddInContractHandle = New ContractHandle(wpfAddInContract)

            ' Convert the INativeHandleContract for the add-in UI that was passed 
            ' from the add-in side of the isolation boundary to a FrameworkElement
            Dim aqn As String = GetType(INativeHandleContract).AssemblyQualifiedName
            Dim inhc As INativeHandleContract = CType(wpfAddInContract.QueryContract(aqn), INativeHandleContract)
            Dim fe As FrameworkElement = CType(FrameworkElementAdapters.ContractToViewAdapter(inhc), FrameworkElement)

            ' Add FrameworkElement (which displays the UI provided by the add-in) as
            ' content of the view (a UserControl)
            Me.Content = fe
        End Sub
    End Class
End Namespace
'</SnippetHostSideAdapterCode>