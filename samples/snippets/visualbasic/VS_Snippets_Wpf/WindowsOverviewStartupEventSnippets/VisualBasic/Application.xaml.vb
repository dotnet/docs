'<SnippetAppCODEBEHIND>

Imports System.Windows

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub app_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			' Create a window
			Dim window As New MarkupAndCodeBehindWindow()

			' Open a window
			window.Show()
		End Sub
	End Class
End Namespace
'</SnippetAppCODEBEHIND>