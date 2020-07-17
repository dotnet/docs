Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class TypographyCodeSnippets
		Inherits Page
		Private Sub PageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Stub01()
		End Sub

		Public Sub Stub01()
			' <SnippetTypographyCodeSnippet1>
			MyParagraph.FontFamily = New FontFamily("Pescadero")
			MyParagraph.FontSize = 48

			Dim run_1 As New Run("CAPITALS ")
			MyParagraph.Inlines.Add(run_1)

			Dim run_2 As New Run("Capitals ")
			run_2.Typography.Capitals = FontCapitals.SmallCaps
			MyParagraph.Inlines.Add(run_2)

			Dim run_3 As New Run("Capitals")
			run_3.Typography.Capitals = FontCapitals.AllSmallCaps
			MyParagraph.Inlines.Add(run_3)

			MyParagraph.Inlines.Add(New LineBreak())
			' </SnippetTypographyCodeSnippet1>
		End Sub
	End Class
End Namespace
