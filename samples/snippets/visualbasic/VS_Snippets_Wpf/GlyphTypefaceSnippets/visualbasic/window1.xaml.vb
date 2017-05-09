Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Media

Namespace WindowsApplication1
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			Stub01()
			Stub02()
			Stub03()
		End Sub

		Public Sub Stub01()
			' <SnippetGlyphTypefaceSnippet1>
			' Create a glyph typeface by referencing the Kootenay OpenType font.
			Dim glyphTypeface As New GlyphTypeface(New Uri("file:///C:\WINDOWS\Fonts\Kooten.ttf"))
			' </SnippetGlyphTypefaceSnippet1>
		End Sub


		Public Sub Stub02()
			' <SnippetGlyphTypefaceSnippet2>
			' Create a glyph typeface by referencing the Verdana font.
			Dim glyphTypeface As New GlyphTypeface(New Uri("file:///C:\WINDOWS\Fonts\verdana.ttf"))

			' Retrieve the advance heights for the glyphs in the Verdana font.
			Dim dictionary As IDictionary(Of UShort, Double) = glyphTypeface.AdvanceHeights
			For Each kvp As KeyValuePair(Of UShort, Double) In dictionary
				' Retrieve the key/value pair information.
			Next kvp
			' </SnippetGlyphTypefaceSnippet2>
		End Sub

		Public Sub Stub03()
			' <SnippetGlyphTypefaceSnippet3>
			' Create a glyph typeface by referencing the Pericles OpenType font.
			Dim glyphTypeface As New GlyphTypeface(New Uri("file:///C:\WINDOWS\Fonts\Peric.ttf"))

			' Retrieve the copyright information for the Pericles OpenType font.
			Dim dictionary As IDictionary(Of CultureInfo, String) = glyphTypeface.Copyrights
			For Each kvp As KeyValuePair(Of CultureInfo, String) In dictionary
				' Retrieve the key/value pair information.
			Next kvp
			' </SnippetGlyphTypefaceSnippet3>
		End Sub
	End Class
End Namespace