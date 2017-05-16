Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Controls
Imports System.Collections.Generic
Imports System.Windows.Input

Namespace Microsoft.Samples.PerFrameAnimations

	Public Class SonicEffect
		Inherits OverlayRenderDecorator
		#Region "Private Members"

		Private _timeTracker As TimeTracker
		Private _ringCount As Integer = 5
		Private _ringDelayInSeconds As Double = 0.1
		Private _ringRadius As Double = 7.0
		Private _ringThickness As Double = 5.0
		Private _ringColor As Color = Color.FromArgb(128, 128, 128, 128)
		Private _clickPosition As Point
		Private _lowerRing, _upperRing As Integer

		#End Region

		#Region "Properties"
		Public Property RingCount() As Integer
			Get
				Return _ringCount
			End Get
			Set(ByVal value As Integer)
				_ringCount = CInt(Fix(value))
			End Set
		End Property

		Public Property RingDelay() As TimeSpan
			Get
				Return TimeSpan.FromSeconds(_ringDelayInSeconds)
			End Get
			Set(ByVal value As TimeSpan)
				_ringDelayInSeconds = (CType(value, TimeSpan)).TotalSeconds
			End Set
		End Property

		Public Property RingRadius() As Double
			Get
				Return _ringRadius
			End Get
			Set(ByVal value As Double)
				_ringRadius = CDbl(value)
			End Set
		End Property

		Public Property RingThickness() As Double
			Get
				Return _ringThickness
			End Get
			Set(ByVal value As Double)
				_ringThickness = CDbl(value)
			End Set
		End Property

		Public Property RingColor() As Color
			Get
				Return _ringColor
			End Get
			Set(ByVal value As Color)
				_ringColor = CType(value, Color)
			End Set
		End Property
		#End Region

		Public Sub New()
		End Sub

		Protected Overrides Sub OnAttachChild(ByVal child As UIElement)
			 AddHandler child.PreviewMouseLeftButtonUp, AddressOf OnMouseLeftButtonUp
		End Sub

		Protected Overrides Sub OnDetachChild(ByVal child As UIElement)
			RemoveHandler CompositionTarget.Rendering, AddressOf OnFrameCallback

			RemoveHandler child.PreviewMouseLeftButtonUp, AddressOf OnMouseLeftButtonUp
			_timeTracker = Nothing
		End Sub


		Private Sub OnMouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If _timeTracker IsNot Nothing Then
				RemoveHandler _timeTracker.TimerFired, AddressOf OnTimerFired
				_timeTracker = Nothing
			End If

			AddHandler CompositionTarget.Rendering, AddressOf OnFrameCallback
			_timeTracker = New TimeTracker()
			_timeTracker.TimerInterval = _ringDelayInSeconds
			AddHandler _timeTracker.TimerFired, AddressOf OnTimerFired
			_upperRing = 0
			_lowerRing = _upperRing
			_clickPosition = e.GetPosition(Me)
		End Sub

		Private Sub OnFrameCallback(ByVal sender As Object, ByVal e As EventArgs)
			If _timeTracker IsNot Nothing Then
				_timeTracker.Update()
				InvalidateVisual()
			End If
		End Sub

		Private Sub OnTimerFired(ByVal sender As Object, ByVal e As EventArgs)
			If _upperRing < _ringCount Then
				_upperRing += 1
			Else
				_lowerRing += 1
				If _lowerRing >= _upperRing Then
					RemoveHandler _timeTracker.TimerFired, AddressOf OnTimerFired
					_timeTracker = Nothing
					RemoveHandler CompositionTarget.Rendering, AddressOf OnFrameCallback
				End If
			End If

		End Sub

		Protected Overrides Sub OnOverlayRender(ByVal dc As DrawingContext)
			If _timeTracker IsNot Nothing Then
				For i As Integer = _lowerRing To _upperRing - 1
					Dim radius As Double = _ringRadius * (i + 1)
					dc.DrawEllipse(Brushes.Transparent, New Pen(New SolidColorBrush(_ringColor), _ringThickness), _clickPosition, radius, radius)
				Next i
			End If
		End Sub
	End Class
End Namespace