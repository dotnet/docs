Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.PerFrameAnimations
	''' <summary>
	''' Interaction logic for FollowExample.xaml
	''' </summary>

	Partial Public Class FollowExample
		Inherits Page
		Private _rectangleVelocity As New Vector(0,0)
		Private _lastMousePosition As New Point(0, 0)

        Public Sub New()
            MyBase.New()
            InitializeComponent()

            AddHandler CompositionTarget.Rendering, AddressOf UpdateRectangle
            AddHandler Me.PreviewMouseMove, AddressOf UpdateLastMousePosition
        End Sub

		Private Sub UpdateRectangle(ByVal sender As Object, ByVal e As EventArgs)
			Dim location As New Point(Canvas.GetLeft(followRectangle), Canvas.GetTop(followRectangle))

			'find vector toward mouse location
			Dim toMouse As Vector = _lastMousePosition - location

			'add a force toward the mouse to the rectangles velocity
			Dim followForce As Double = 0.01
			_rectangleVelocity += toMouse * followForce

			'dampen the velocity to add stability
			Dim drag As Double = 0.8
			_rectangleVelocity *= drag

			'update the new location from the velocity
			location += _rectangleVelocity

			'set new position
			Canvas.SetLeft(followRectangle, location.X)
			Canvas.SetTop(followRectangle, location.Y)
		End Sub

		Private Sub UpdateLastMousePosition(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			_lastMousePosition = e.GetPosition(containerCanvas)
		End Sub
	End Class
End Namespace