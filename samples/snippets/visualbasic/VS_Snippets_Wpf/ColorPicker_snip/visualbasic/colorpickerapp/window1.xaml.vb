Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Diagnostics


Namespace ColorPickerApp
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub changeColor(ByVal sender As Object, ByVal e As RoutedEventArgs)
			colorPicker.Color = Colors.Blue
		End Sub

		Private Sub getColor(ByVal sender As Object, ByVal e As RoutedEventArgs)
			textBlockCurrentColor.Text = MaincolorPicker.Color.ToString()
		End Sub
		'<SnippetOnColorChangedSnip>
		Private Sub OnColorChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))
			colorPickerValue.Text = e.NewValue.ToString()
		End Sub
		'</SnippetOnColorChangedSnip>

	End Class
End Namespace