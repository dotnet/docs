Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Markup

Namespace SDKSample
	Partial Public Class FontMapSnippets
		Inherits Page
		Private Sub FontMapPageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Stub1()
			Stub2()
			Stub3()
			Stub4()
			Stub5()
			Stub6()
		End Sub

		Public Sub Stub1()
			' <SnippetFontMapSnippet1>
			Dim fontFamilyMap As New FontFamilyMap()
			' </SnippetFontMapSnippet1>
			fontFamilyMap.Target = "Tahoma, Verdana"
		End Sub

		Public Sub Stub2()
			Dim fontFamilyMap As New FontFamilyMap()

			' <SnippetFontMapSnippet2>
			fontFamilyMap.Scale = 1.1
			' </SnippetFontMapSnippet2>
		End Sub

		Public Sub Stub3()
			Dim fontFamilyMap As New FontFamilyMap()

			' <SnippetFontMapSnippet3>
			fontFamilyMap.Target = "Tahoma, Verdana"
			' </SnippetFontMapSnippet3>
		End Sub

		Public Sub Stub4()
			Dim fontFamilyMap As New FontFamilyMap()
			Dim [unicode] As String = fontFamilyMap.Unicode

			' <SnippetFontMapSnippet4>
			Try
				fontFamilyMap.Unicode = "00e0-00ef, 0100-01ff"
			Catch ex As FormatException
				' Handle exception
			End Try
			' </SnippetFontMapSnippet4>
		End Sub

		Public Sub Stub5()
			Dim fontFamilyMap As New FontFamilyMap()

			' <SnippetFontMapSnippet5>
			fontFamilyMap.Language = XmlLanguage.GetLanguage("en-uk")
			' </SnippetFontMapSnippet5>
		End Sub

		Public Sub Stub6()
			' <SnippetFontMapSnippet6>
			' Create a new FontFamily object.
			Dim fontFamily As New FontFamily()

			' Create the FontFamilyMap.
			Dim fontFamilyMap As New FontFamilyMap()
			fontFamilyMap.Target = "Comic Sans MS"
			fontFamilyMap.Language = XmlLanguage.GetLanguage("en-us")
			fontFamilyMap.Unicode = "00e0-00ef"

			' Add the FontFamilyMap to the FontFamily's collection.
			fontFamily.FamilyMaps.Add(fontFamilyMap)
			' </SnippetFontMapSnippet6>
		End Sub
	End Class
End Namespace
