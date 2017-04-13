Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace TreeViewDataBinding
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application

		Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()

			AddHandler DispatcherUnhandledException, AddressOf app_DispatcherUnhandledException
		End Sub

		Private Sub app_DispatcherUnhandledException(ByVal sender As Object, ByVal e As System.Windows.Threading.DispatcherUnhandledExceptionEventArgs)
			MessageBox.Show(e.Exception.Message)
		End Sub



	End Class
End Namespace