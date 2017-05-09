Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class Attributes
		Inherits Page
		Private Sub PageLoaded(ByVal o As Object, ByVal e As EventArgs)
			Snippet2()
			Snippet3()
			Snippet7()
		End Sub

		Public Sub Snippet2()
			' <!-- <SnippetAttributesSnippet2> -->
			' Retreive the localization attributes from the button.
			Dim attributes As String = Localization.GetAttributes(buttonLocalized)
			' <!-- </SnippetAttributesSnippet2> -->
		End Sub

		Public Sub Snippet3()
			' <!-- <SnippetAttributesSnippet3> -->
			' Set the localization attributes for the button.
			Dim attributes As String = "$Content(Text Readable Modifiable) FontFamily(Font Readable Unmodifiable)"
			Localization.SetAttributes(buttonLocalized, attributes)
			' <!-- </SnippetAttributesSnippet3> -->

			Dim attributesSet As String = Localization.GetAttributes(buttonLocalized)
		End Sub

		Public Sub Snippet7()
			' <!-- <SnippetAttributesSnippet7> -->
			' Get the value of the Localization.AttributesProperty dependency property.
			Dim attributes As String = CStr(buttonLocalized.GetValue(Localization.AttributesProperty))

			' Set the value of the Localization.AttributesProperty dependency property.
			Dim newAttributes As String = "$Content(Button Unreadable Unmodifiable) FontFamily(Font Unreadable Unmodifiable)"
			buttonLocalized.SetValue(Localization.AttributesProperty, newAttributes)
			' <!-- </SnippetAttributesSnippet7> -->

			Dim attributesSet As String = Localization.GetAttributes(buttonLocalized)
		End Sub
	End Class
End Namespace