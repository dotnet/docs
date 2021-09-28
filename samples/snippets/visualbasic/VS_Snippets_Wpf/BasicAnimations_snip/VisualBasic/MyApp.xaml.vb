Imports System.Windows
Imports System.Windows.Media

Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Application.xaml
	''' </summary>

	Partial Public Class MyApp
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)

			Dim mainWindow As New SampleViewer()
			mainWindow.Show()
		End Sub

	End Class
End Namespace