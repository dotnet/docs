Imports System.Windows
Imports System.Windows.Threading

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_DispatcherUnhandledException(ByVal sender As Object, ByVal e As DispatcherUnhandledExceptionEventArgs)
			' Process unhandled exception

			' Prevent default unhandled exception processing
			e.Handled = True
		End Sub
	End Class
End Namespace
