Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration
Imports System.Windows.Media
Imports System.Windows.Input

Namespace PointCollectionSample
	''' <summary>
	''' Interaction logic for MyApp.xaml
	''' </summary>

	Partial Public Class MyApp
		Inherits Application

		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()


		End Sub

	End Class
End Namespace