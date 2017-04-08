Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Data
Imports System.Xml
Imports System.Configuration

Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards

	Partial Public Class MyApp
		Inherits Application

		Public Sub New()

			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
		End Sub

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			Dim myWindow As New Window()
			myWindow.Content = New SampleViewer()
			MainWindow = myWindow
			myWindow.Show()
		End Sub



		Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
			MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())
		End Sub

	End Class
End Namespace