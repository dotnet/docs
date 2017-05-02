Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Controls
Imports System.Collections.Generic
Imports System.Windows.Input
Imports System.Security.Permissions

Namespace Microsoft.Samples.PerFrameAnimations

	Friend Class Particle
		Public Location As Point
		Public Velocity As Vector
		Public LifeTime As Date
		Public DeathTime As Date
		Public StartColor As Color
		Public EndColor As Color
		Public Diameter As Double
	End Class

	Public Class FireworkEffect
		Inherits OverlayRenderDecorator
		Private _particles As New List(Of Particle)()
		Protected _random As New Random()
		Private _bounceOffContainer As Boolean = False
		Private _gravity As New Vector(0.0, 10.0)
		Private _gravitateToMouse As Boolean = False
		Private _gravitateScale As Double = 0.1

		Private _mouseDropsParticles As Boolean = False
		Private _secondsUntilDrop As Double = 0
		Private _lastMousePosition As New Point(0, 0)

		Private _timeTracker As TimeTracker


		#Region "Dependency Properties"
		Public Shared ReadOnly RadiusProperty As DependencyProperty = DependencyProperty.Register("RadiusBase", GetType(Double), GetType(FireworkEffect), New FrameworkPropertyMetadata(15.0))

		Public Shared ReadOnly RadiusVariationProperty As DependencyProperty = DependencyProperty.Register("RadiusVariation", GetType(Double), GetType(FireworkEffect), New FrameworkPropertyMetadata(5.0))

		Public Shared ReadOnly StartColorProperty As DependencyProperty = DependencyProperty.Register("StartColor", GetType(Color), GetType(FireworkEffect), New FrameworkPropertyMetadata(Color.FromArgb(245, 200, 50, 20)))
		Public Shared ReadOnly EndColorProperty As DependencyProperty = DependencyProperty.Register("EndColor", GetType(Color), GetType(FireworkEffect), New FrameworkPropertyMetadata(Color.FromArgb(100, 200, 255, 20)))

		Public Shared ReadOnly StartColorVariationProperty As DependencyProperty = DependencyProperty.Register("StartColorVariation", GetType(Color), GetType(FireworkEffect), New FrameworkPropertyMetadata(Color.FromArgb(10, 55, 50, 20)))

		Public Shared ReadOnly EndColorVariationProperty As DependencyProperty = DependencyProperty.Register("EndColorVariation", GetType(Color), GetType(FireworkEffect), New FrameworkPropertyMetadata(Color.FromArgb(50, 20, 100, 20)))

		Public Shared ReadOnly MouseDropDelayProperty As DependencyProperty = DependencyProperty.Register("MouseDropDelay", GetType(Double), GetType(FireworkEffect), New FrameworkPropertyMetadata(0.1))

		Public Shared ReadOnly MouseDropDelayVariationProperty As DependencyProperty = DependencyProperty.Register("MouseDropDelayVariation", GetType(Double), GetType(FireworkEffect), New FrameworkPropertyMetadata(0.05))

		Public Shared ReadOnly ClickBurstSizeProperty As DependencyProperty = DependencyProperty.Register("ClickBurstSize", GetType(Integer), GetType(FireworkEffect), New FrameworkPropertyMetadata(30))
		#End Region

		#Region "Properties"
		Public Property Radius() As Double
			Get
				Return CDbl(GetValue(RadiusProperty))
			End Get
			Set(ByVal value As Double)

				SetValue(RadiusProperty, value)
			End Set
		End Property

		Public Property RadiusVariation() As Double
			Get
				Return CDbl(GetValue(RadiusVariationProperty))
			End Get
			Set(ByVal value As Double)

				SetValue(RadiusVariationProperty, value)
			End Set
		End Property

		Public Property StartColor() As Color
			Get
				Return CType(GetValue(StartColorProperty), Color)
			End Get
			Set(ByVal value As Color)

				SetValue(StartColorProperty, value)
			End Set
		End Property

		Public Property EndColor() As Color
			Get
				Return CType(GetValue(EndColorProperty), Color)
			End Get
			Set(ByVal value As Color)

				SetValue(EndColorProperty, value)
			End Set
		End Property

		Public Property StartColorVariation() As Color
			Get
				Return CType(GetValue(StartColorVariationProperty), Color)
			End Get
			Set(ByVal value As Color)

				SetValue(StartColorVariationProperty, value)
			End Set
		End Property

		Public Property EndColorVariation() As Color
			Get
				Return CType(GetValue(EndColorVariationProperty), Color)
			End Get
			Set(ByVal value As Color)

				SetValue(EndColorVariationProperty, value)
			End Set
		End Property


		Public Property BounceOffContainer() As Boolean
			Get
				Return _bounceOffContainer
			End Get
			Set(ByVal value As Boolean)
				_bounceOffContainer = value
			End Set
		End Property

		Public Property GravitateToMouse() As Boolean
			Get
				Return _gravitateToMouse
			End Get
			Set(ByVal value As Boolean)
				_gravitateToMouse = value
			End Set
		End Property

		Public Property GravitateScale() As Double
			Get
				Return _gravitateScale
			End Get
			Set(ByVal value As Double)
				_gravitateScale = value
			End Set
		End Property

		Public Property MouseDropsParticles() As Boolean
			Get
				Return _mouseDropsParticles
			End Get
			Set(ByVal value As Boolean)
				_mouseDropsParticles = value
			End Set
		End Property

		Public Property MouseDropDelay() As Double
			Get
				Return CDbl(GetValue(MouseDropDelayProperty))
			End Get
			Set(ByVal value As Double)

				SetValue(MouseDropDelayProperty, value)
			End Set
		End Property

		Public Property MouseDropDelayVariation() As Double
			Get
				Return CDbl(GetValue(MouseDropDelayVariationProperty))
			End Get
			Set(ByVal value As Double)

				SetValue(MouseDropDelayVariationProperty, value)
			End Set
		End Property

		Public Property ClickBurstSize() As Integer
			Get
				Return CInt(Fix(GetValue(ClickBurstSizeProperty)))
			End Get
			Set(ByVal value As Integer)

				SetValue(ClickBurstSizeProperty, value)
			End Set
		End Property
		#End Region


		Public Sub New()
			MyBase.New()

		End Sub

		Protected Overrides Sub OnAttachChild(ByVal child As UIElement)
			AddHandler CompositionTarget.Rendering, AddressOf OnFrameCallback

			AddHandler child.PreviewMouseLeftButtonUp, AddressOf OnMouseLeftButtonUp
			AddHandler child.PreviewMouseMove, AddressOf OnMouseMove

			_timeTracker = New TimeTracker()

		End Sub

		Protected Overrides Sub OnDetachChild(ByVal child As UIElement)
			RemoveHandler CompositionTarget.Rendering, AddressOf OnFrameCallback

			RemoveHandler child.PreviewMouseLeftButtonUp, AddressOf OnMouseLeftButtonUp
			RemoveHandler child.PreviewMouseMove, AddressOf OnMouseMove

			_timeTracker = Nothing
		End Sub

		<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.ControlAppDomain)>
		Protected Sub OnFrameCallback(ByVal sender As Object, ByVal e As EventArgs)
			UpdateParticles(_timeTracker.Update())
		End Sub

		Private Sub UpdateParticles(ByVal deltatime As Double)
			'drop particles from mouse position
			If _mouseDropsParticles AndAlso IsMouseOver Then
				_secondsUntilDrop -= deltatime
				If _secondsUntilDrop < 0.0 Then
					AddRandomBurst(_lastMousePosition - New Vector(Radius / 2.0, Radius / 2.0), 1)
					_secondsUntilDrop = MouseDropDelay + (_random.NextDouble() * 2.0 - 1.0) * MouseDropDelayVariation
				End If
			End If

			If _particles.Count > 0 Then
				InvalidateVisual()
			End If

			'update all particles
			Dim i As Integer = 0
			Do While i < _particles.Count
				'_particles[i]
				Dim p As Particle = _particles(i)

				If _gravitateToMouse Then
					p.Velocity += (_lastMousePosition - p.Location) * _gravitateScale
				Else
					p.Velocity += _gravity
				End If
				p.Location += p.Velocity * deltatime

				If _bounceOffContainer Then
					Dim radius As Double = p.Diameter/2.0
					If p.Location.X - radius < 0.0 Then
						p.Location.X = radius
						p.Velocity.X *= -0.9
					ElseIf p.Location.X > ActualWidth - radius Then
						p.Location.X = ActualWidth - radius
						p.Velocity.X *= -0.9
					End If
					If p.Location.Y - radius < 0.0 Then
						p.Location.Y = radius
						p.Velocity.Y *= -0.9
					ElseIf p.Location.Y > ActualHeight - radius Then
						p.Location.Y = ActualHeight - radius
						p.Velocity.Y *= -0.9
					End If
				End If

				'only increment counter for live particles
				If _timeTracker.ElapsedTime > p.DeathTime Then
					_particles.RemoveAt(i)
				Else
					i += 1
				End If
			Loop

		End Sub

		Protected Overrides Sub OnOverlayRender(ByVal drawingContext As DrawingContext)
			For i As Integer = 0 To _particles.Count - 1
				Dim p As Particle = _particles(i)

				'figure out where in the particles life we are
				Dim particlelife As Double = (_timeTracker.ElapsedTime.Subtract(p.LifeTime)).TotalSeconds / (p.DeathTime.Subtract(p.LifeTime)).TotalSeconds
				Dim currentcolor As Color = Color.Multiply(p.StartColor, CSng(1.0 - particlelife)) + Color.Multiply(p.EndColor, CSng(particlelife))
				Dim brush As Brush = New RadialGradientBrush(currentcolor, Color.FromArgb(0, currentcolor.R,currentcolor.G,currentcolor.B))

				Dim rect As New RectangleGeometry(New Rect(New Point(p.Location.X - p.Diameter / 2.0,p.Location.Y - p.Diameter / 2.0), New Size(p.Diameter,p.Diameter)))
				drawingContext.DrawGeometry(brush, Nothing, rect)
			Next i
		End Sub

        Private Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            _lastMousePosition = e.GetPosition(Me)
        End Sub

		Private Sub OnMouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			AddRandomBurst(e.GetPosition(Me))
		End Sub

		Public Sub AddRandomBurst()

			Dim point As New Point(_random.NextDouble() * ActualWidth, _random.NextDouble() * ActualHeight)
			AddRandomBurst(point, ClickBurstSize)
		End Sub

		Public Sub AddRandomBurst(ByVal location As Point)
			AddRandomBurst(location, ClickBurstSize)
		End Sub

		Public Sub AddRandomBurst(ByVal location As Point, ByVal count As Integer)
			For i As Integer = 0 To count - 1
				Dim p As New Particle()

				Dim radius As Double = Me.Radius + (_random.NextDouble() * 2.0 - 1.0) * RadiusVariation
				Dim lifetime As Double = _random.NextDouble() * 3.0 + 1.0

				p.Location = location
				p.Velocity = New Vector(_random.NextDouble() * 200.0 - 100.0, _random.NextDouble() * -200 + 100.0)
				p.LifeTime = _timeTracker.ElapsedTime
				p.DeathTime = _timeTracker.ElapsedTime + TimeSpan.FromSeconds(lifetime)
				p.Diameter = 2.0 * radius

				Dim startColor As Color = Me.StartColor
				Dim startColorVariation As Color = Me.StartColorVariation
				Dim endColor As Color = Me.EndColor
				Dim endColorVariation As Color = Me.EndColorVariation

				Dim startRandColor As Color = Color.FromScRgb(startColorVariation.ScA * CSng(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScR * CSng(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScG * CSng(_random.NextDouble() * 2.0 - 1.0),startColorVariation.ScB * CSng(_random.NextDouble() * 2.0 - 1.0))
				Dim endRandColor As Color = Color.FromScRgb(endColorVariation.ScA * CSng(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScR * CSng(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScG * CSng(_random.NextDouble() * 2.0 - 1.0), endColorVariation.ScB * CSng(_random.NextDouble() * 2.0 - 1.0))

				p.StartColor = startColor + startRandColor
				p.EndColor = endColor + endRandColor
				_particles.Add(p)
			Next i
		End Sub
	End Class
End Namespace