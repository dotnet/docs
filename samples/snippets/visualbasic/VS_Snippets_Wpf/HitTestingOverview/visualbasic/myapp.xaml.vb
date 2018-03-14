Namespace SDKSample
	''' <summary>
	''' Interaction logic for Application.xaml
	''' </summary>

	Partial Public Class MyApp
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.InitializeComponent()
			mainWindow.Show()
		End Sub
	End Class
End Namespace