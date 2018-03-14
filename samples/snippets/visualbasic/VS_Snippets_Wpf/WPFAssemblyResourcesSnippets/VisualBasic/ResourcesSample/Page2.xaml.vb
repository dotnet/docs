Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace ResourcesSample
	''' <summary>
	''' Interaction logic for Page2.xaml
	''' </summary>

	Partial Public Class Page2
		Inherits Page
		Public Sub New()
            InitializeComponent()
		End Sub

		Private Sub a(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("asdf")
		End Sub
	End Class
End Namespace