'<SnippetAddInViewCode>

Imports System.AddIn.Pipeline
Imports System.Windows

Namespace AddInViews
	''' <summary>
	''' Defines the add-in's view of the contract
	''' </summary>
	<AddInBase>
	Public Interface IWPFAddInView
		' The add-in's implementation of this method will return
		' a UI type that directly or indirectly derives from 
		' FrameworkElement.
		Function GetAddInUI() As FrameworkElement
	End Interface
End Namespace
'</SnippetAddInViewCode>