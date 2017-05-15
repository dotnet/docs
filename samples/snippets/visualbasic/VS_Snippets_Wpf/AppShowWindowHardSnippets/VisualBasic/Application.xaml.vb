'<SnippetStartupEventCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System.Windows

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			' Open a window
			Dim window As New MainWindow()
			window.Show()
		End Sub
	End Class
End Namespace
'</SnippetStartupEventCODEBEHIND>