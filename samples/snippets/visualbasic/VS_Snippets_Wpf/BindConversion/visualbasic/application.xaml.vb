Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace SDKSample
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>

	Partial Public Class App
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
	  mainWindow.InitializeComponent()
			mainWindow.Show()
		End Sub
	End Class
End Namespace