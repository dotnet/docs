Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Threading
Imports System.Configuration
Imports System.Globalization

Namespace ProgBar
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application
		Private Sub On_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.InitializeComponent()
			mainWindow.Show()

		End Sub

	End Class
End Namespace