Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class Comments
		Inherits Page
		Private Sub PageLoaded(ByVal o As Object, ByVal e As EventArgs)
			Snippet5()
			Snippet6()
			Snippet8()
		End Sub

		Public Sub Snippet5()
			' <!-- <SnippetAttributesSnippet5> -->
			' Retreive the localization comments from the text block.
			Dim comments As String = Localization.GetComments(textBlockLocalized)
			' <!-- </SnippetAttributesSnippet5> -->
		End Sub

		Public Sub Snippet6()
			' <!-- <SnippetAttributesSnippet6> -->
			' Set the localization comments for the text block.
			Dim comments As String = "$Content(Copyright info) FontSize(Logo point size)"
			Localization.SetComments(textBlockLocalized, comments)
			' <!-- </SnippetAttributesSnippet6> -->

			Dim commentsSet As String = Localization.GetComments(textBlockLocalized)
		End Sub

		Public Sub Snippet8()
			' <!-- <SnippetAttributesSnippet8> -->
			' Get the value of the Localization.CommentsProperty dependency property.
			Dim comments As String = CStr(textBlockLocalized.GetValue(Localization.CommentsProperty))

			' Set the value of the Localization.CommentsProperty dependency property.
			Dim newComments As String = "$Content(Trademark) FontSize(Trademark font size)"
			textBlockLocalized.SetValue(Localization.CommentsProperty, newComments)
			' <!-- </SnippetAttributesSnippet8> -->

			Dim commentsSet As String = Localization.GetComments(textBlockLocalized)
		End Sub
	End Class
End Namespace