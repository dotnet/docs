'<SnippetAddInSideAdapterCode>

Imports System.AddIn.Contract
Imports System.AddIn.Pipeline
Imports System.Windows

Imports AddInViews
Imports Contracts

Namespace AddInSideAdapters
	''' <summary>
	''' Adapts the add-in's view of the contract to the add-in contract
	''' </summary>
	<AddInAdapter>
	Public Class WPFAddIn_ViewToContractAddInSideAdapter
		Inherits ContractBase
		Implements IWPFAddInContract
		Private wpfAddInView As IWPFAddInView

		Public Sub New(ByVal wpfAddInView As IWPFAddInView)
			' Adapt the add-in view of the contract (IWPFAddInView) 
			' to the contract (IWPFAddInContract)
			Me.wpfAddInView = wpfAddInView
		End Sub

        Public Function GetAddInUI() As INativeHandleContract Implements IWPFAddInContract.GetAddInUI
            ' Convert the FrameworkElement from the add-in to an INativeHandleContract 
            ' that will be passed across the isolation boundary to the host application.
            Dim fe As FrameworkElement = Me.wpfAddInView.GetAddInUI()
            Dim inhc As INativeHandleContract = FrameworkElementAdapters.ViewToContractAdapter(fe)
            Return inhc
        End Function
	End Class
End Namespace
'</SnippetAddInSideAdapterCode>