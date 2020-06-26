Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class HomePage
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub shutdownButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Application.Current.Shutdown()
		End Sub
	End Class
End Namespace