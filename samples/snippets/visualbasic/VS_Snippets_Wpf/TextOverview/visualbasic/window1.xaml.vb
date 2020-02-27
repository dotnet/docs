Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace Windows.Samples.WinFX
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		' Handle to Click event for the button.
		Private Sub OnDisplayTextClick(ByVal sender As Object, ByVal e As EventArgs)
			FillFontComboBox(comboBoxFonts)
		End Sub

		'<Snippet100>
		Public Sub FillFontComboBox(ByVal comboBoxFonts As ComboBox)
			' Enumerate the current set of system fonts,
			' and fill the combo box with the names of the fonts.
			For Each fontFamily As FontFamily In Fonts.SystemFontFamilies
				' FontFamily.Source contains the font family name.
				comboBoxFonts.Items.Add(fontFamily.Source)
			Next fontFamily

			comboBoxFonts.SelectedIndex = 0
		End Sub
		'</Snippet100>
	End Class
End Namespace
