Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class FontFamilySnippets
		Inherits Page
		Private Sub FontFamilySnippetsLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Fonts5()
		End Sub

		Public Sub FamilyStub1()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontFallbackSnippet1>
			myTextBlock.FontFamily = New FontFamily("Comic Sans MS, Verdana")
			' </SnippetFontFallbackSnippet1>
		End Sub

		Public Sub FamilyStub2()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontFallbackSnippet2>
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/"), "./resources/#Pericles Light, Verdana")
			' </SnippetFontFallbackSnippet2>
		End Sub

		Public Sub FamilyStub3()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontFallbackSnippet3>
			myTextBlock.FontFamily = New FontFamily("Comic Sans MS")
			' </SnippetFontFallbackSnippet3>
		End Sub

		Public Sub Fonts1()
			' <SnippetFontsSnippet1>
			For Each fontFamily As FontFamily In Fonts.GetFontFamilies("file:///D:/MyFonts/")
				' Perform action.
			Next fontFamily
			' </SnippetFontsSnippet1>

		End Sub

		Public Sub Fonts2()
			' <SnippetFontsSnippet2>
			For Each fontFamily As FontFamily In Fonts.GetFontFamilies(New Uri("pack://application:,,,/"))
				' Perform action.
			Next fontFamily
			' </SnippetFontsSnippet2>
		End Sub

		Public Sub Fonts3()
			' <SnippetFontsSnippet3>
			For Each fontFamily As FontFamily In Fonts.GetFontFamilies(New Uri("pack://application:,,,/"), "./resources/")
				' Perform action.
			Next fontFamily
			' </SnippetFontsSnippet3>
		End Sub

		Public Sub Fonts4()
			' <SnippetFontsSnippet4>
			For Each typeface As Typeface In Fonts.GetTypefaces("D:/MyFonts/")
				' Perform action.
			Next typeface
			' </SnippetFontsSnippet4>

		End Sub

		Public Sub Fonts5()
			' <SnippetFontsSnippet5>
			For Each typeface As Typeface In Fonts.GetTypefaces("file:///D:/MyFonts/")
				' Perform action.
			Next typeface
			' </SnippetFontsSnippet5>

		End Sub

		Public Sub Fonts6()
			' <SnippetFontsSnippet6>
			For Each typeface As Typeface In Fonts.GetTypefaces(New Uri("pack://application:,,,/"))
				' Perform action.
			Next typeface
			' </SnippetFontsSnippet6>
		End Sub

		Public Sub Fonts7()
			' <SnippetFontsSnippet7>
			For Each typeface As Typeface In Fonts.GetTypefaces(New Uri("pack://application:,,,/"), "./resources/")
				' Perform action.
			Next typeface
			' </SnippetFontsSnippet7>
		End Sub
	End Class
End Namespace
