Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.IO

Namespace Microsoft.Samples.CustomControls

	' Displays the sample.
	Partial Public Class MyApp
		Inherits Application

		Public Sub New()

			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf currentDomain_UnhandledException
		End Sub


		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)

			Dim w As New Window()
			w.Content = New SampleViewer()
			w.Show()

			MyBase.OnStartup(e)
		End Sub



		Private Sub currentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
			MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())

			Dim s As New StreamWriter("error.txt")
			s.Write(args.ExceptionObject.ToString())
			s.Flush()
			s.Close()

		End Sub
	End Class

End Namespace