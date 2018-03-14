Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Windows
Imports System.Windows.Data
Imports System.Configuration
Imports System.Windows.Media
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Reflection
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Threading
Imports System.IO
Imports DemoDev

Namespace Ribbon

	Partial Public Class Page1
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArgs)
			' setup trackball for moving the model around
			_trackball = New Trackball()
			_trackball.Attach(Me)
			_trackball.Slaves.Add(myViewport3D)
			_trackball.Enabled = True

		End Sub

		#Region "Events"
'<SnippetFEBeginStoryboard>
		Private Sub OnImage1Animate(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim s As Storyboard

			s = CType(Me.FindResource("RotateStoryboard"), Storyboard)
			Me.BeginStoryboard(s)
		End Sub
'</SnippetFEBeginStoryboard>
		#End Region

		#Region "Globals"

		Private _trackball As Trackball

		#End Region
	End Class


End Namespace



