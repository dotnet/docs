Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace AdornersMiscCode
  ''' <summary>
  ''' Interaction logic for MyApp.xaml
  ''' </summary>

  Partial Public Class MyApp
	  Inherits Application

	Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
	  Dim mainWindow As New Window1()
	  mainWindow.Show()
	End Sub

  End Class
End Namespace