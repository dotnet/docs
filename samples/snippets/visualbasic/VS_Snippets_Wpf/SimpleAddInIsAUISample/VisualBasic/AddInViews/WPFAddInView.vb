'<SnippetAddInViewCode>

Imports System.AddIn.Pipeline ' AddInBaseAttribute
Imports System.Windows.Controls ' UserControl

Namespace AddInViews
	''' <summary>
	''' Defines the add-in's view of the contract.
	''' </summary>
	<AddInBase>
	Public Class WPFAddInView
		Inherits UserControl
	End Class
End Namespace
'</SnippetAddInViewCode>