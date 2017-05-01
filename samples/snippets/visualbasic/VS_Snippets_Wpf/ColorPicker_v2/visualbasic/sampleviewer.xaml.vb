Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.CustomControls
	''' <summary>
	''' Interaction logic for SampleViewer.xaml
	''' </summary>

	Partial Public Class SampleViewer
		Inherits Page
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub pageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			w = New ColorPickerDialog()
			w.Owner = Application.Current.MainWindow
		End Sub

		Private w As ColorPickerDialog

		Private Sub buttonClicked(ByVal sender As Object, ByVal e As RoutedEventArgs)

			w.StartingColor = Colors.Blue
			MessageBox.Show(w.ShowDialog().ToString())


		End Sub


	End Class
End Namespace