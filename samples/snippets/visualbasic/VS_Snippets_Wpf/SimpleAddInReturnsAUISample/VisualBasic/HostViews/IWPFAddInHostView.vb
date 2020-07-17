'<SnippetHostViewCode>

Imports System.Windows

Namespace HostViews
	''' <summary>
	''' Defines the host's view of the add-in
	''' </summary>
	Public Interface IWPFAddInHostView
		' The view returns as a class that directly or indirectly derives from 
		' FrameworkElement and can subsequently be displayed by the host 
		' application by embedding it as content or sub-content of a UI that is 
		' implemented by the host application.
		Function GetAddInUI() As FrameworkElement
	End Interface
End Namespace
'</SnippetHostViewCode>