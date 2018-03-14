Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace Microsoft.Samples.Animation.AnimatedTransformations

	Partial Public Class app
		Inherits Application

		Public Sub New()
			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
		End Sub

		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim myWindow As New Window()
			myWindow.Content = New AnimatedHeightExample()
			MainWindow = myWindow
			myWindow.Show()
		End Sub

		Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
			MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())
		End Sub
	End Class

End Namespace