Imports System.Collections
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Markup
Imports System.Windows.Media

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnClick1(ByVal sender As Object, ByVal e As RoutedEventArgs)
			TestCodeSnippet8()
			TestAPIs()
		End Sub

		Public Sub TestCodeSnippet1()
			'<Snippet100>
			' Return the font family collection for the selected directory location.
			Dim fontFamilies As System.Collections.Generic.ICollection(Of FontFamily) = Fonts.GetFontFamilies("C:/MyFonts")

			' Enumerate through the font family collection.
			For Each fontFamily As FontFamily In fontFamilies
				' Separate the URI directory source info from the font family name.
				Dim familyName() As String = fontFamily.Source.Split("#"c)

				' Add the font family name to the fonts combo box.
				comboBoxFonts.Items.Add(familyName(familyName.Length - 1))
			Next fontFamily

			comboBoxFonts.SelectedIndex = 0
			'</Snippet100>
		End Sub

		Public Sub TestCodeSnippet2()
			'<Snippet101>
			' Return the font family collection for the selected URI location.
			Dim fontFamilies As System.Collections.Generic.ICollection(Of FontFamily) = Fonts.GetFontFamilies("file:///C:\Windows\Fonts\#Georgia")

			' Enumerate through the font family collection.
			For Each fontFamily As FontFamily In fontFamilies
				' Separate the URI directory source info from the font family name.
				Dim familyName() As String = fontFamily.Source.Split("#"c)

				' Add the font family name to the fonts combo box.
				comboBoxFonts.Items.Add(familyName(familyName.Length - 1))
			Next fontFamily

			comboBoxFonts.SelectedIndex = 0
			'</Snippet101>
		End Sub

		Public Sub TestCodeSnippet3()
			'<Snippet102>
			' Return the typeface collection for the fonts in the selected URI location.
			Dim typefaces As System.Collections.Generic.ICollection(Of Typeface) = Fonts.GetTypefaces("file:///C:\Windows\Fonts\#Georgia")

			' Enumerate the typefaces in the collection.
			For Each face As Typeface In typefaces
				' Separate the URI directory source info from the font family name.
				Dim familyName() As String = face.FontFamily.Source.Split("#"c)

				' Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName(familyName.Length - 1) & " " & face.Weight.ToString & " " & face.Style.ToString)
			Next face

			comboBoxTypeface.SelectedIndex = 0
			'</Snippet102>
		End Sub

		Public Sub TestCodeSnippet4()
			'<Snippet103>
			' Return the font family using an implied reference for a font in the default system font directory.
			Dim fontFamily1 As New FontFamily("Arial Narrow")

			' Return the font family using a directory reference for the font name.
			Dim fontFamily2 As New FontFamily("C:/MyFonts/#Pericles Light")

			' Return the font family using a URI reference for the font name.
			Dim fontFamily3 As New FontFamily("file:///C:\Windows\Fonts\#Palatino Linotype")
			'</Snippet103>

			' Return the collection of typefaces for the font family.
			Dim typefaces As System.Collections.Generic.ICollection(Of Typeface) = fontFamily1.GetTypefaces()

			' Enumerate the typefaces in the collection.
			For Each face As Typeface In typefaces
				' Separate the URI directory source info from the font family name.
				Dim familyName() As String = face.FontFamily.Source.Split("#"c)

				' Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName(familyName.Length - 1) & " " & face.Weight.ToString & " " & face.Style.ToString)
			Next face

			comboBoxTypeface.SelectedIndex = 0
		End Sub

		Public Sub TestCodeSnippet5()
			'<Snippet104>
			' Return the font family for the selected font name.
			Dim fontFamily As New FontFamily("Palatino Linotype")

			' Return the collection of typefaces for the font family.
			Dim typefaces As System.Collections.Generic.ICollection(Of Typeface) = fontFamily.GetTypefaces()
			'</Snippet104>

			' Enumerate the typefaces in the collection.
			For Each face As Typeface In typefaces
				' Separate the URI directory source info from the font family name.
				Dim familyName() As String = face.FontFamily.Source.Split("#"c)

				' Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName(familyName.Length - 1) & " " & face.Weight.ToString & " " & face.Style.ToString)
			Next face

			comboBoxTypeface.SelectedIndex = 0
		End Sub

		Public Sub TestCodeSnippet6()
			'<Snippet105>
			' Return the typeface for the selected font family name.
			Dim typeface1 As New Typeface("Verdana")

			' Return the typeface for the selected font family name and font values.
			Dim typeface2 As New Typeface(New FontFamily("file:///C:\MyFonts\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed)

			' Return the typeface for the selected font family name, font values, and fallback font family name.
			Dim typeface3 As New Typeface(New FontFamily("file:///C:\MyFonts\#Pericles"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed, New FontFamily("Arial"))
			'</Snippet105>

			TextBlock1.FontFamily = typeface3.FontFamily
		End Sub

		Public Sub TestCodeSnippet7()
			' Return the font family for the selected font name.
			Dim fontFamily As New FontFamily("Arial")

			'<Snippet106>
			' Return the dictionary for the font family names.
			Dim dictionary As LanguageSpecificStringDictionary = fontFamily.FamilyNames

			' Return the current culture info.
			Dim cultureInfo As CultureInfo = CultureInfo.CurrentCulture

			' Determine whether the dictionary contains the current culture info.
			'if (dictionary.ContainsKey())
			'{
				' Font family contains the family name for the current culture info.
			'}
			'</Snippet106>
			'else
			'{
			'}
		End Sub

		Public Sub TestCodeSnippet8()
			'<Snippet107>
			' Return the font family for the selected font name.
			Dim fontFamily As New FontFamily("Arial Narrow")

			' Return the family typeface collection for the font family.
			Dim familyTypefaceCollection As FamilyTypefaceCollection = fontFamily.FamilyTypefaces

			' Enumerate the family typefaces in the collection.
			For Each typeface As FamilyTypeface In familyTypefaceCollection
				' Add the typeface style values to the styles combo box.
				comboBoxStyles.Items.Add(typeface.Style)
			Next typeface

			comboBoxStyles.SelectedIndex = 0
			'</Snippet107>
		End Sub

		Public Sub TestCodeSnippet9()
			' Return the typeface for the selected font family name and font values.
			Dim typeface As New Typeface(New FontFamily("file:///C:\MyFonts\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed)

			'<Snippet108>
			' Get the font stretch value for the typeface.
			Dim fontStretch As FontStretch = typeface.Stretch

			If fontStretch = FontStretches.Condensed Then
				' Perform action based on condensed stretch value.
			End If
			'</Snippet108>
		End Sub

		Public Sub TestCodeSnippet10()
			' Return the typeface for the selected font family name and font values.
			Dim typeface As New Typeface(New FontFamily("file:///C:\MyFonts\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed)

			'<Snippet109>
			' Get the font style value for the typeface.
			Dim fontStyle As FontStyle = typeface.Style

			If fontStyle = FontStyles.Italic Then
				' Perform action based on italic style value.
			End If
			'</Snippet109>
		End Sub

		Public Sub TestCodeSnippet11()
			' Return the typeface for the selected font family name and font values.
			Dim typeface As New Typeface(New FontFamily("file:///C:\MyFonts\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed)

			'<Snippet110>
			' Get the font weight value for the typeface.
			Dim fontWeight As FontWeight = typeface.Weight

			If fontWeight = FontWeights.ExtraBold Then
				' Perform action based on extra bold weight value.
			End If
			'</Snippet110>
		End Sub

		Public Sub TestCodeSnippet12()
			'<SnippetFontSnippet11>
			' Return the typefaces for the selected font family name and font values.
			Dim typeface1 As New Typeface(New FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal)
			Dim typeface2 As New Typeface(New FontFamily("Arial"), FontStyles.Normal, FontWeights.UltraBold, FontStretches.Normal)

			If FontWeight.Compare(typeface1.Weight, typeface2.Weight) < 0 Then
				' Code execution follows this path because
				' the FontWeight of typeface1 (Normal) is less than of typeface2 (UltraBold).
			End If
			'</SnippetFontSnippet11>
		End Sub

		Public Sub TestAPIs()
			' Return the font family for the selected font name.
			Dim fontFamily As New FontFamily("Arial")
			Dim fontFamilyNameless As New FontFamily()

			Dim toString As String = fontFamily.ToString()
			Dim source As String = fontFamily.Source
			Dim toStringNameless As String = fontFamilyNameless.ToString()
		End Sub
	End Class
End Namespace
