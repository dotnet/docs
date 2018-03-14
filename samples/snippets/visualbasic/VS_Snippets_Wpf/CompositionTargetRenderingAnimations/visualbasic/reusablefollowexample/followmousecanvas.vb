Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media

Namespace Microsoft.Samples.PerFrameAnimations


	Partial Public Class FollowMouseCanvas
		Inherits Canvas
		Private _velocity As New Vector(0, 0)
		Private _parentLastMousePosition As New Point(0, 0)
		Private _parentCanvas As Canvas = Nothing
		Private _lastRender As TimeSpan


		Public Sub New()
			MyBase.New()
			_lastRender = TimeSpan.FromTicks(Date.Now.Ticks)
			AddHandler CompositionTarget.Rendering, AddressOf UpdatePosition
		End Sub

		Private Sub UpdatePosition(ByVal sender As Object, ByVal e As EventArgs)

			Dim renderingArgs As RenderingEventArgs = CType(e, RenderingEventArgs)

			Dim deltaTime As Double = (renderingArgs.RenderingTime - _lastRender).TotalSeconds
			_lastRender = renderingArgs.RenderingTime

			If _parentCanvas Is Nothing Then
				_parentCanvas = TryCast(VisualTreeHelper.GetParent(Me), Canvas)
				If _parentCanvas Is Nothing Then
					'parent isnt canvas so just abort trying to follow mouse
					RemoveHandler CompositionTarget.Rendering, AddressOf UpdatePosition
				Else
					'parent is canvas, so track mouse position and time
					AddHandler _parentCanvas.PreviewMouseMove, AddressOf UpdateLastMousePosition

				End If
			End If


			'get location
			Dim location As New Point(Canvas.GetLeft(Me), Canvas.GetTop(Me))

			'check for NaN's and replace with 0,0
			If Double.IsNaN(location.X) OrElse Double.IsNaN(location.Y) Then
				location = New Point(0, 0)
			End If

			'find vector toward mouse location
			Dim toMouse As Vector = _parentLastMousePosition - location

			'add a force toward the mouse to the rectangles velocity
			Dim followForce As Double = 1.0
			_velocity += toMouse * followForce

			'dampen the velocity to add stability
			Dim drag As Double = 0.95
			_velocity *= drag

			'update the new location from the velocity
			location += _velocity * deltaTime

			'set new position
			Canvas.SetLeft(Me, location.X)
			Canvas.SetTop(Me, location.Y)
		End Sub

		Private Sub UpdateLastMousePosition(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			If _parentCanvas Is Nothing Then
				Return
			End If

			_parentLastMousePosition = e.GetPosition(_parentCanvas)
		End Sub
	End Class
End Namespace