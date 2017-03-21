Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Media3D

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Private ReadOnly stepAngle As Double = 5.0
		Private ReadOnly stepDistance As Double = 0.5
		Private ReadOnly minDistance As Double = 24.0
		Private ReadOnly maxDistance As Double = 90.0
		Private spaceLinesChangeVector As New Vector3D(0.0, 0.0, 0.0)

		' Set focus to viewport when the left mouse button is clicked.
		Private Sub ViewportMouseHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
		   myViewport3D.Focus()
		End Sub

		' Determine whether the camera or point light handles the pressed key.
		Private Sub ViewportKeyHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
			If currKeyMode = KeyMode.Camera Then
				KeyDownHandlerForCamera(sender, e)
			End If

			If currKeyMode = KeyMode.PointLight Then
				KeyDownHandlerForPointLight(sender, e)
			End If
		End Sub

		' Process keys for moving the camera position.
		Private Sub KeyDownHandlerForCamera(ByVal sender As Object, ByVal e As KeyEventArgs)
			Dim currentDistance, newDistance As Double
			Dim rotationAxis As Vector3D
			Dim rotationTransform As RotateTransform3D
			Dim camera As PerspectiveCamera = CType(myViewport3D.Camera, PerspectiveCamera)

			Select Case e.Key
				Case Key.Up
					rotationAxis = Vector3D.CrossProduct(CType(camera.Position, Vector3D), camera.UpDirection)
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, stepAngle))

					camera.Position = rotationTransform.Transform(camera.Position)
					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True

				Case Key.Down
					rotationAxis = Vector3D.CrossProduct(CType(camera.Position, Vector3D), camera.UpDirection)
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, -stepAngle))

					camera.Position = rotationTransform.Transform(camera.Position)
					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True

				Case Key.Left
					rotationAxis = camera.UpDirection
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, -stepAngle))

					camera.Position = rotationTransform.Transform(camera.Position)
					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True

				Case Key.Right
					rotationAxis = camera.UpDirection
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, stepAngle))

					camera.Position = rotationTransform.Transform(camera.Position)
					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True

				Case Key.OemPlus, Key.Add
					currentDistance = (CType(camera.Position, Vector3D)).Length
					newDistance = currentDistance - stepDistance

					If newDistance > minDistance Then
						Dim scale As Double = newDistance / currentDistance
						camera.Position *= New ScaleTransform3D(New Vector3D(scale, scale, scale)).Value
					End If

					e.Handled = True

				Case Key.OemMinus, Key.Subtract
					currentDistance = (CType(camera.Position, Vector3D)).Length
					newDistance = currentDistance + stepDistance

					If newDistance < maxDistance Then
						Dim scale As Double = newDistance / currentDistance
						camera.Position *= New ScaleTransform3D(New Vector3D(scale, scale, scale)).Value
					End If

					e.Handled = True

				Case Key.OemComma
					rotationAxis = CType(camera.Position, Vector3D)
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, stepAngle))

					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True

				Case Key.OemPeriod
					rotationAxis = CType(camera.Position, Vector3D)
					rotationTransform = New RotateTransform3D(New AxisAngleRotation3D(rotationAxis, -stepAngle))

					camera.UpDirection = rotationTransform.Transform(camera.UpDirection)

					e.Handled = True
			End Select
		End Sub

		' Process keys for moving the point light position.
		Private Sub KeyDownHandlerForPointLight(ByVal sender As Object, ByVal e As KeyEventArgs)
			Dim pointLightVector As New Vector3D(0.0, 0.0, 0.0)

			Select Case e.Key
				Case Key.Up
					spaceLinesChangeVector.Y += 1
					pointLightVector.Y = 1
					e.Handled = True

				Case Key.Down
					spaceLinesChangeVector.Y -= 1
					pointLightVector.Y = -1
					e.Handled = True

				Case Key.Left
					spaceLinesChangeVector.X -= 1
					pointLightVector.X = -1
					e.Handled = True

				Case Key.Right
					spaceLinesChangeVector.X += 1
					pointLightVector.X = 1
					e.Handled = True

				Case Key.OemPlus, Key.Add
					spaceLinesChangeVector.Z -= 1
					pointLightVector.Z = -1
					e.Handled = True

				Case Key.OemMinus, Key.Subtract
					spaceLinesChangeVector.Z += 1
					pointLightVector.Z = 1
					e.Handled = True
			End Select

			If e.Handled = True Then
				' Transform point light.
				myLights.TransformPointLight(pointLightVector, spaceLinesChangeVector)

				xyzPointLight.Content = "x: " & myLights.PointLightPosition.X & "  y: " & myLights.PointLightPosition.Y & "  z: " & myLights.PointLightPosition.Z
			End If
		End Sub
	End Class
End Namespace
