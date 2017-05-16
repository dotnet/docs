'<SnippetHandleDispatcherUnhandledExceptionCODEBEHIND1>

Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Threading

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_DispatcherUnhandledException(ByVal sender As Object, ByVal e As DispatcherUnhandledExceptionEventArgs)
			' Process unhandled exception
			'</SnippetHandleDispatcherUnhandledExceptionCODEBEHIND1>

			' Prevent snippet weirdness

			'<SnippetHandleDispatcherUnhandledExceptionCODEBEHIND2>
			' Prevent default unhandled exception processing
			e.Handled = True
		End Sub
	End Class
End Namespace
'</SnippetHandleDispatcherUnhandledExceptionCODEBEHIND2>