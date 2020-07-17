
'
' This sample demonstrates how to animate the position of a Geometry using
' a PointAnimation.
'


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
		

		Protected Overrides Sub OnStartup (ByVal e As StartupEventArgs)
		
			MyBase.OnStartup(e)
			CreateAndShowMainWindow()
		End Sub


		Private Sub CreateAndShowMainWindow ()

			' Create the application's main window.
			Dim myWindow As New NavigationWindow()
			
			' Display the sample
			Dim myContent As New PathElementAnimationExample()
			myWindow.Navigate(myContent)
			MainWindow = myWindow
			myWindow.Show()
		End Sub
	
	End Class
	
	
	' Starts the application.
	NotInheritable Public Class EntryClass
	
		
		Shared Sub Main()
		
			
			Dim app As New app ()
			app.Run ()
		End Sub
	End Class
End Namespace
