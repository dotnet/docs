Imports System.Xml
Imports System.Configuration

Namespace HOWTOWindowManagementSnippets
	'<SnippetFirstWindowUsingCodeCODEBEHIND>
	Partial Public Class App
		Inherits Application
		Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim window As New MainWindow()
			window.Show()
		End Sub
	End Class
	'</SnippetFirstWindowUsingCodeCODEBEHIND>
End Namespace