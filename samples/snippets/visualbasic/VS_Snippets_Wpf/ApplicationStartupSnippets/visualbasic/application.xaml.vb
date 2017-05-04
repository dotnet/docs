'<SnippetStartupCODEBEHIND1>
'<SnippetHandleStartupCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System.Windows

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			' Application is running
			'</SnippetStartupCODEBEHIND1>
			' Process command line args
			Dim startMinimized As Boolean = False
			Dim i As Integer = 0
			Do While i <> e.Args.Length
				If e.Args(i) = "/StartMinimized" Then
					startMinimized = True
				End If
				i += 1
			Loop

			' Create main application window, starting minimized if specified
			Dim mainWindow As New MainWindow()
			If startMinimized Then
				mainWindow.WindowState = WindowState.Minimized
			End If
			mainWindow.Show()
			'<SnippetStartupCODEBEHIND2>
		End Sub
	End Class
End Namespace
'</SnippetStartupCODEBEHIND2>
'</SnippetHandleStartupCODEBEHIND>