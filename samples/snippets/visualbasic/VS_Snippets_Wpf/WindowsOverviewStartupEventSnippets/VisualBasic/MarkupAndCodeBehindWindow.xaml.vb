Imports System.Windows

Namespace SDKSample
	Partial Public Class MarkupAndCodeBehindWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("Button was clicked.")
		End Sub
	End Class
End Namespace