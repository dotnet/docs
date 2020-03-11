Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class Page1
		Inherits Page
		' <SnippetPerformanceSnippet15>
		' Display the underline on only the MouseEnter event.
		Private Overloads Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
			myHyperlink.TextDecorations = TextDecorations.Underline
		End Sub

		' Remove the underline on the MouseLeave event.
		Private Overloads Sub OnMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			myHyperlink.TextDecorations = Nothing
		End Sub
		' </SnippetPerformanceSnippet15>
	End Class
End Namespace