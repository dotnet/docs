'---------------------------------------------------------------------------
' <copyright file="Trackball.vb" company="Microsoft">
'    Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'---------------------------------------------------------------------------



Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D


Namespace DemoDev
	Public Class Trackball
		Public Sub New()
			Dim _translate As New Vector3D(0, 0, 0)
			Dim _translateDelta As New Vector3D(0, 0, 0)

			Reset()
		End Sub

		Public Sub Attach(ByVal element As FrameworkElement)
			AddHandler element.MouseMove, AddressOf MouseMoveHandler
			AddHandler element.MouseRightButtonDown, AddressOf MouseDownHandler
			AddHandler element.MouseRightButtonUp, AddressOf MouseUpHandler
			AddHandler element.MouseWheel, AddressOf OnMouseWheel
		End Sub

		Public Sub Detach(ByVal element As FrameworkElement)
			RemoveHandler element.MouseMove, AddressOf MouseMoveHandler
			RemoveHandler element.MouseRightButtonDown, AddressOf MouseDownHandler
			RemoveHandler element.MouseRightButtonUp, AddressOf MouseUpHandler
			RemoveHandler element.MouseWheel, AddressOf OnMouseWheel
		End Sub

		Public Property Slaves() As List(Of Viewport3D)
			Get
				If _slaves Is Nothing Then
					_slaves = New List(Of Viewport3D)()
				End If

				Return _slaves
			End Get
			Set(ByVal value As List(Of Viewport3D))
				_slaves = value
			End Set
		End Property

		Public Property Enabled() As Boolean
			Get
				Return _enabled AndAlso (_slaves IsNot Nothing) AndAlso (_slaves.Count > 0)
			End Get
			Set(ByVal value As Boolean)
				_enabled = value
			End Set
		End Property

		' Updates the matrices of the slaves using the rotation quaternion.
		Private Sub UpdateSlaves(ByVal q As Quaternion, ByVal s As Double, ByVal t As Vector3D)

			If _slaves IsNot Nothing Then
				For Each i As Viewport3D In _slaves
					Dim mv As ModelVisual3D = TryCast(i.Children(0), ModelVisual3D)
					Dim t3dg As Transform3DGroup = TryCast(mv.Transform, Transform3DGroup)

					Dim _GroupScaleTransform As ScaleTransform3D = TryCast(t3dg.Children(0), ScaleTransform3D)
					Dim _GroupRotateTransform As RotateTransform3D = TryCast(t3dg.Children(1), RotateTransform3D)
					Dim _GroupTranslateTransform As TranslateTransform3D = TryCast(t3dg.Children(2), TranslateTransform3D)

					_GroupScaleTransform.ScaleX = s
					_GroupScaleTransform.ScaleY = s
					_GroupScaleTransform.ScaleZ = s
					_GroupRotateTransform.Rotation = New AxisAngleRotation3D(q.Axis, q.Angle)
					_GroupTranslateTransform.OffsetX = t.X
					_GroupTranslateTransform.OffsetY = t.Y
					_GroupTranslateTransform.OffsetZ = t.Z

				Next i
			End If
		End Sub


		Private Sub MouseMoveHandler(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			If Not Enabled Then
				Return
			End If
			e.Handled = True

			Dim el As UIElement = CType(sender, UIElement)

			If el.IsMouseCaptured Then
				Dim delta As Vector = _point - e.MouseDevice.GetPosition(el)
				Dim t As New Vector3D()

				delta /= 2
				Dim q As Quaternion = _rotation

				If _rotating = True Then
					' We can redefine this 2D mouse delta as a 3D mouse delta
					' where "into the screen" is Z
					Dim mouse As New Vector3D(delta.X, -delta.Y, 0)
					Dim axis As Vector3D = Vector3D.CrossProduct(mouse, New Vector3D(0, 0, 1))
					Dim len As Double = axis.Length
					If len < 0.00001 OrElse _scaling Then
						_rotationDelta = New Quaternion(New Vector3D(0, 0, 1), 0)
					Else
						_rotationDelta = New Quaternion(axis, len)
					End If

					q = _rotationDelta * _rotation
				Else
					delta /= 20
					_translateDelta.X = delta.X * -1
					_translateDelta.Y = delta.Y
				End If

				t = _translate + _translateDelta

				UpdateSlaves(q, _scale * _scaleDelta, t)

			End If
		End Sub
'<SnippetUIElementMouseCapture>
		Private Sub MouseDownHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If Not Enabled Then
				Return
			End If
			e.Handled = True


			If Keyboard.IsKeyDown(Key.F1) = True Then
				Reset()
				Return
			End If

			Dim el As UIElement = CType(sender, UIElement)
			_point = e.MouseDevice.GetPosition(el)
			' Initialize the center of rotation to the lookatpoint
			If Not _centered Then
				Dim camera As ProjectionCamera = CType(_slaves(0).Camera, ProjectionCamera)
				_center = camera.LookDirection
				_centered = True
			End If

			_scaling = (e.MiddleButton = MouseButtonState.Pressed)

			If Keyboard.IsKeyDown(Key.Space) = False Then
				_rotating = True
			Else
				_rotating = False
			End If

			el.CaptureMouse()
		End Sub

		Private Sub MouseUpHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If Not _enabled Then
				Return
			End If
			e.Handled = True

			' Stuff the current initial + delta into initial so when we next move we
			' start at the right place.
			If _rotating = True Then
				_rotation = _rotationDelta * _rotation
			Else
				_translate += _translateDelta
				_translateDelta.X = 0
				_translateDelta.Y = 0
			End If

			'_scale = _scaleDelta * _scale
			Dim el As UIElement = CType(sender, UIElement)
			el.ReleaseMouseCapture()
		End Sub
'</SnippetUIElementMouseCapture>
		Private Sub OnMouseWheel(ByVal sender As Object, ByVal e As System.Windows.Input.MouseWheelEventArgs)
			e.Handled = True

			_scaleDelta += CDbl(CDbl(e.Delta) / CDbl(1000))
			Dim q As Quaternion = _rotation

			UpdateSlaves(q, _scale * _scaleDelta, _translate)
		End Sub

		Private Sub MouseDoubleClickHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Reset()
		End Sub

		Private Sub Reset()
			_rotation = New Quaternion (0,0,0,1)
			_scale = 1
			_translate.X = 0
			_translate.Y = 0
			_translate.Z = 0
			_translateDelta.X = 0
			_translateDelta.Y = 0
			_translateDelta.Z = 0

			' Clear delta too, because if reset is called because of a double click then the mouse
			' up handler will also be called and this way it won't do anything.
			_rotationDelta = Quaternion.Identity
			_scaleDelta = 1
			UpdateSlaves(_rotation, _scale, _translate)
		End Sub

		' The state of the trackball
		Private _enabled As Boolean
		Private _center As Vector3D
		Private _centered As Boolean
		Private _scale As Double
		Private _translate As Vector3D
		Private _rotation As Quaternion
		Private _slaves As List(Of Viewport3D)

		' The state of the current drag
		Private _scaling As Boolean
		Private _scaleDelta As Double ' Change to scale because of this drag
		Private _rotationDelta As Quaternion ' Change to rotation because of this drag
		Private _point As System.Windows.Point ' Initial point of drag
		Private _translateDelta As Vector3D
		Private _rotating As Boolean
		Private _translating As Boolean
	End Class
End Namespace

