Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.Animation.AnimatePathShapeSample

	' Displays the sample.
	Public Class app
		Inherits Application

		Public Sub New()

		End Sub


		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			CreateAndShowMainWindow()
		End Sub


		Private Sub CreateAndShowMainWindow()
			' Create the application's main window.
			Dim myWindow As New NavigationWindow()

			' Display the sample
			Dim myContent As Page = New AnimationTargetValuesExample()
			myWindow.Navigate(myContent)
			MainWindow = myWindow
			myWindow.Show()
		End Sub
	End Class

	' Starts the application.
	Friend NotInheritable Class EntryClass
        <System.STAThread()>
        Public Shared Sub Main()

            Dim app As New app()
            app.Run()
        End Sub
	End Class
End Namespace
