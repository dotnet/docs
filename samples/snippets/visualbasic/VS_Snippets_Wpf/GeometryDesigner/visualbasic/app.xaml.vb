Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace SampleApp
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application

		Public Sub New()

		End Sub


		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Title = "Geometry Designer"
			mainWindow.Width = 800
			mainWindow.Height = 600
			mainWindow.Show()
		End Sub



	End Class
End Namespace