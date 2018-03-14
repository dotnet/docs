Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.IO

Namespace Microsoft.Samples.PerFrameAnimations

	' Displays the sample.
	Partial Public Class app
		Inherits Application

		Public Sub New()

		End Sub


		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)

			Dim w As New Window()
			w.Content = New SampleViewer()
			w.Show()

			MyBase.OnStartup(e)
		End Sub




	End Class

End Namespace