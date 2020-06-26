Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class FontStyleSnippets
		Inherits Page
		Private Sub PageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' <SnippetFontStyleSnippet2>
			Dim fontStyle As FontStyle = FontStyles.Normal
			' </SnippetFontStyleSnippet2>

			Stub2()
		End Sub

		Public Sub Stub1()
			' <SnippetFontStyleSnippet3>
			Dim fontStyle As FontStyle = FontStyles.Italic
			' </SnippetFontStyleSnippet3>
		End Sub

		Public Sub Stub2()
			' <SnippetFontStyleSnippet4>
			Dim fontStyle As FontStyle = FontStyles.Oblique
			' </SnippetFontStyleSnippet4>
		End Sub
	End Class
End Namespace
