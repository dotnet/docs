Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.BrushExamples

	' Displays the sample.
	Public Class MyApp
		Inherits Application

		Public Sub New()
			 AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf currentDomain_UnhandledException
		End Sub


		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			CreateAndShowMainWindow()
		End Sub


		Private Sub CreateAndShowMainWindow()
			' Create the application's main window.
			Dim myWindow As New NavigationWindow()

			' Display the sample
			Dim myContent As Page = New SampleViewer()
			myWindow.Navigate(myContent)
			MainWindow = myWindow
			myWindow.Show()
		End Sub

		Private Sub currentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)
			MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())
		End Sub
	End Class

	' Starts the application.
	Friend NotInheritable Class EntryClass
		<System.STAThread()>
		Private Shared Sub Main()

			Dim app As New MyApp()
			app.Run ()
		End Sub
	End Class
End Namespace