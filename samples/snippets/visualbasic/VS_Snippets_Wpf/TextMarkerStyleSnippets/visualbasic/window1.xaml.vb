Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		 Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 SetMarkerStyle01()
		 End Sub

		' Use the default font values for the strikethrough text decoration.
		Private Sub SetMarkerStyle01()
			' <SnippetTextMarkerStyleSnippet1>
			Dim list As New List()
			list.MarkerStyle = TextMarkerStyle.Box
			' </SnippetTextMarkerStyleSnippet1>
		End Sub

	End Class
End Namespace