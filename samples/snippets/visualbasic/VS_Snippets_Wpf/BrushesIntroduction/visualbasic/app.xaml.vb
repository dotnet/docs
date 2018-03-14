Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Namespace BrushesIntroduction

	''' <summary>
	''' Defines the application.
	''' </summary>
	Partial Public Class app
		Inherits Application

		Public Sub New()

		End Sub

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			Dim myWindow As New Window()
			myWindow.Content = New SampleViewer()
			myWindow.Show()
		End Sub


	End Class
End Namespace