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

	Public Class MagnitismCanvas
		Inherits Canvas
		#Region "Private Members"

		Private _timeTracker As TimeTracker
		Private _childrenVelocities As New Dictionary(Of UIElement, Vector)()
		Private _borderforce As Double = 1000.0
		Private _childforce As Double = 200.0
		Private _drag As Double = 0.9

		#End Region

		#Region "Properties"
		Public Property BorderForce() As Double
			Get
				Return _borderforce
			End Get
			Set(ByVal value As Double)
				_borderforce = value
			End Set
		End Property
		Public Property ChildForce() As Double
			Get
				Return _childforce
			End Get
			Set(ByVal value As Double)
				_childforce = value
			End Set
		End Property
		Public Property Drag() As Double
			Get
				Return _drag
			End Get
			Set(ByVal value As Double)
				_drag = value
			End Set
		End Property
		#End Region

		<SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlAppDomain)>
		Public Sub New()
			MyBase.New()
			' suppress movement in the visual studio designer.
			If System.Diagnostics.Process.GetCurrentProcess().ProcessName <> "devenv" Then
				AddHandler CompositionTarget.Rendering, AddressOf UpdateChildren
			End If
			_timeTracker = New TimeTracker()
		End Sub

		Private Sub UpdateChildren(ByVal sender As Object, ByVal e As EventArgs)
			'update time delta
			_timeTracker.Update()

			For Each child As UIElement In LogicalTreeHelper.GetChildren(Me)
				Dim velocity As Vector
				If _childrenVelocities.ContainsKey(child) Then
					'get the velocity that we previously stored
					velocity = _childrenVelocities(child)
				Else
					'setup the initial velocity randomly
					velocity = New Vector(0, 0)
				End If

				'compute velocity dampening
				velocity = velocity * _drag

				Dim truePosition As Point = GetTruePosition(child)
				Dim childRect As New Rect(truePosition, child.RenderSize)


				'accumulate forces
				Dim forces As New Vector(0, 0)

				'add wall repulsion
				forces.X += _borderforce / Math.Max(1, childRect.Left)
				forces.X -= _borderforce / Math.Max(1, Me.RenderSize.Width - childRect.Right)
				forces.Y += _borderforce / Math.Max(1, childRect.Top)
				forces.Y -= _borderforce / Math.Max(1, Me.RenderSize.Height - childRect.Bottom)

				'each other child pushes away based on the square distance
				For Each otherchild As UIElement In LogicalTreeHelper.GetChildren(Me)
					'dont push against itself
					If otherchild Is child Then
						Continue For
					End If

					Dim otherchildtruePosition As Point = GetTruePosition(otherchild)
					Dim otherchildRect As New Rect(otherchildtruePosition, otherchild.RenderSize)

					'make sure rects aren't the same
					If otherchildRect = childRect Then
						Continue For
					End If

					'ignore children with a size of 0,0
					If otherchildRect.Width = 0 AndAlso otherchildRect.Height = 0 OrElse childRect.Width = 0 AndAlso childRect.Height = 0 Then
						Continue For
					End If

					'vector from current other child to current child
					Dim toChild As Vector
					Dim length As Double
					'are they overlapping?  if so, distance is 0
					If AreRectsOverlapping(childRect, otherchildRect) Then
						toChild = New Vector(0, 0)
					Else
						toChild = VectorBetweenRects(childRect, otherchildRect)
					End If

					length = toChild.Length
					If length < 1 Then
						length = 1
						Dim childCenter As Point = GetCenter(childRect)
						Dim otherchildCenter As Point = GetCenter(otherchildRect)
						'compute toChild from the center of both rects
						toChild = childCenter - otherchildCenter
					End If

					Dim childpush As Double = _childforce / length

					toChild.Normalize()
					forces += toChild * childpush
				Next otherchild

				'add forces to velocity and store it for next iteration
				velocity += forces
				_childrenVelocities(child) = velocity

				'move the object based on it's velocity
				SetTruePosition(child, truePosition + _timeTracker.DeltaSeconds * velocity)
			Next child
		End Sub

		Private Function AreRectsOverlapping(ByVal r1 As Rect, ByVal r2 As Rect) As Boolean
			If r1.Bottom < r2.Top Then
				Return False
			End If
			If r1.Top > r2.Bottom Then
				Return False
			End If

			If r1.Right < r2.Left Then
				Return False
			End If
			If r1.Left > r2.Right Then
				Return False
			End If

			Return True
		End Function

		Private Function IntersectInsideRect(ByVal r As Rect, ByVal raystart As Point, ByVal raydir As Vector) As Point
			Dim xtop As Double = raystart.X + raydir.X * (r.Top - raystart.Y) / raydir.Y
			Dim xbottom As Double = raystart.X + raydir.X * (r.Bottom - raystart.Y) / raydir.Y
			Dim yleft As Double = raystart.Y + raydir.Y * (r.Left - raystart.X) / raydir.X
			Dim yright As Double = raystart.Y + raydir.Y * (r.Right - raystart.X) / raydir.X
			Dim top As New Point(xtop, r.Top)
			Dim bottom As New Point(xbottom, r.Bottom)
			Dim left As New Point(r.Left, yleft)
			Dim right As New Point(r.Right, yright)
			Dim tv As Vector = raystart - top
			Dim bv As Vector = raystart - bottom
			Dim lv As Vector = raystart - left
			Dim rv As Vector = raystart - right
			'classify ray direction
			If raydir.Y < 0 Then
				If raydir.X < 0 Then 'top left

					If tv.LengthSquared < lv.LengthSquared Then
						Return top
					Else
						Return left
					End If
				Else 'top right
					If tv.LengthSquared < rv.LengthSquared Then
						Return top
					Else
						Return right
					End If
				End If
			Else
				If raydir.X < 0 Then 'bottom left
					If bv.LengthSquared < lv.LengthSquared Then
						Return bottom
					Else
						Return left
					End If
				Else 'bottom right
					If bv.LengthSquared < rv.LengthSquared Then
						Return bottom
					Else
						Return right
					End If
				End If
			End If
		End Function

		Private Function VectorBetweenRects(ByVal r1 As Rect, ByVal r2 As Rect) As Vector
			'find the edge points and use these to measure the distance
			Dim r1Center As Point = GetCenter(r1)
			Dim r2Center As Point = GetCenter(r2)
			Dim between As Vector = (r1Center - r2Center)
			between.Normalize()
			Dim edge1 As Point = IntersectInsideRect(r1, r1Center, -between)
			Dim edge2 As Point = IntersectInsideRect(r2, r2Center, between)
			Return edge1 - edge2
		End Function

		Private Function GetRenderTransformOffset(ByVal e As UIElement) As Point
			'make sure they object's render transform is a translation
			Dim renderTranslation As TranslateTransform = TryCast(e.RenderTransform, TranslateTransform)
			If renderTranslation Is Nothing Then
				renderTranslation = New TranslateTransform(0, 0)
				e.RenderTransform = renderTranslation
			End If

			Return New Point(renderTranslation.X, renderTranslation.Y)
		End Function

		Private Sub SetRenderTransformOffset(ByVal e As UIElement, ByVal offset As Point)
			'make sure they object's render transform is a translation
			Dim renderTranslation As TranslateTransform = TryCast(e.RenderTransform, TranslateTransform)
			If renderTranslation Is Nothing Then
				renderTranslation = New TranslateTransform(0, 0)
				e.RenderTransform = renderTranslation
			End If

			'set new offset
			renderTranslation.X = offset.X
			renderTranslation.Y = offset.Y
		End Sub

		Private Function GetTruePosition(ByVal e As UIElement) As Point
			Dim renderTranslation As Point = GetRenderTransformOffset(e)
			Return New Point(Canvas.GetLeft(e) + renderTranslation.X, Canvas.GetTop(e) + renderTranslation.Y)
		End Function

		Private Sub SetTruePosition(ByVal e As UIElement, ByVal p As Point)
			Dim canvasOffset As New Vector(Canvas.GetLeft(e), Canvas.GetTop(e))
			Dim renderTranslation As Point = p - canvasOffset

			SetRenderTransformOffset(e, renderTranslation)
		End Sub

		Private Function GetCenter(ByVal r As Rect) As Point
			Return New Point((r.Left + r.Right) / 2.0, (r.Top + r.Bottom) / 2.0)
		End Function

	End Class

End Namespace
