'<SnippetPageWithNonDefaultConstructorCODEBEHIND>

Namespace SDKSample
	Partial Public Class PageWithNonDefaultConstructor
		Inherits Page
		Public Sub New(ByVal message As String)
			InitializeComponent()

			Me.Content = message
		End Sub
	End Class
End Namespace
'</SnippetPageWithNonDefaultConstructorCODEBEHIND>