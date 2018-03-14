Imports System.Windows.Media.Animation
Imports System.Windows.Media.Media3D


Namespace MatrixTransform3DView
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		'Set globals
        Private end_Matrix3D As New Matrix3D()
		Private rotationMatrix3D As New Matrix3D()
		Private qrotationMatrix3D As New Matrix3D()
		Private myMatrixTransform3D As New MatrixTransform3D()
		Private myRotateTransform3D As New RotateTransform3D()
		Private myAxisAngleRotation3D As New AxisAngleRotation3D()
		Private endQuaternion As New Quaternion()
		Private myQuaternionRotation3D As New QuaternionRotation3D()
		Private myTranslateTransform3D As New TranslateTransform3D()
		Private myprocTransformGroup As New Transform3DGroup()


		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub UpdateMatrix(ByVal sender As Object, ByVal e As EventArgs)
			'<SnippetMatrixTransform3DView3DN1>
			Try
				Dim setM11 As Double = Convert.ToDouble(M11Text.Text)
				Dim setM21 As Double = Convert.ToDouble(M21Text.Text)
				Dim setM31 As Double = Convert.ToDouble(M31Text.Text)
				Dim setOffsetX As Double = Convert.ToDouble(OffsetXText.Text)

				Dim setM12 As Double = Convert.ToDouble(M12Text.Text)
				Dim setM22 As Double = Convert.ToDouble(M22Text.Text)
				Dim setM32 As Double = Convert.ToDouble(M32Text.Text)
				Dim setOffsetY As Double = Convert.ToDouble(OffsetYText.Text)

				Dim setM13 As Double = Convert.ToDouble(M13Text.Text)
				Dim setM23 As Double = Convert.ToDouble(M23Text.Text)
				Dim setM33 As Double = Convert.ToDouble(M33Text.Text)
				Dim setOffsetZ As Double = Convert.ToDouble(OffsetZText.Text)

				Dim setM14 As Double = Convert.ToDouble(M14Text.Text)
				Dim setM24 As Double = Convert.ToDouble(M24Text.Text)
				Dim setM34 As Double = Convert.ToDouble(M34Text.Text)
				Dim setM44 As Double = Convert.ToDouble(M44Text.Text)

                end_Matrix3D = New Matrix3D(setM11, setM12, setM13, setM14, setM21, setM22, setM23, setM24, setM31, setM32, setM33, setM34, setOffsetX, setOffsetY, setOffsetZ, setM44)

                myMatrixTransform3D.Matrix = end_Matrix3D
		Catch
			MessageBox.Show("Set Matrix3D values or rotation values before transforming")
		End Try

			'</SnippetMatrixTransform3DView3DN1>
			'might want to clear the transformgroup before adding more children
			myprocTransformGroup.Children.Clear()
			myprocTransformGroup.Children.Add(myMatrixTransform3D)
			topModelVisual3D.Transform = myprocTransformGroup

		End Sub

		Private Sub UpdateRotation(ByVal sender As Object, ByVal e As EventArgs)
			'Clear prior values
			'find a cleaner way to do this--loop?
			QuaternionWText.Clear()
			QuaternionXText.Clear()
			QuaternionYText.Clear()
			QuaternionZText.Clear()

			M11Text.Clear()
			M21Text.Clear()
			M31Text.Clear()
			OffsetXText.Clear()
			M12Text.Clear()
			M22Text.Clear()
			M32Text.Clear()
			OffsetYText.Clear()
			M13Text.Clear()
			M23Text.Clear()
			M33Text.Clear()
			OffsetZText.Clear()
			M14Text.Clear()
			M24Text.Clear()
			M34Text.Clear()
			M44Text.Clear()

			'<SnippetMatrixTransform3DView3DN2>

			Dim axisX As Double = Convert.ToDouble(RotationAxisXText.Text)
			Dim axisY As Double = Convert.ToDouble(RotationAxisYText.Text)
			Dim axisZ As Double = Convert.ToDouble(RotationAxisZText.Text)
			Dim angle As Double = Convert.ToDouble(RotationAngleText.Text)

			Dim axis As New Vector3D(axisX, axisY, axisZ)

			Try
				myAxisAngleRotation3D = New AxisAngleRotation3D(axis, angle)
			Catch
				MessageBox.Show("Set non-null values for the axis Vector3D.")
			End Try

			myRotateTransform3D.Rotation = myAxisAngleRotation3D

			'</SnippetMatrixTransform3DView3DN2>


			'update matrix display
			'<SnippetMatrixTransform3DView3DN13>
			rotationMatrix3D = myRotateTransform3D.Value
			M11Text.Text = rotationMatrix3D.M11.ToString()
			'</SnippetMatrixTransform3DView3DN13>
			M21Text.Text = rotationMatrix3D.M21.ToString()
			M31Text.Text = rotationMatrix3D.M31.ToString()
			OffsetXText.Text = rotationMatrix3D.OffsetX.ToString()
			M12Text.Text = rotationMatrix3D.M12.ToString()
			M22Text.Text = rotationMatrix3D.M22.ToString()
			M32Text.Text = rotationMatrix3D.M32.ToString()
			OffsetYText.Text = rotationMatrix3D.OffsetY.ToString()
			M13Text.Text = rotationMatrix3D.M13.ToString()
			M23Text.Text = rotationMatrix3D.M23.ToString()
			M33Text.Text = rotationMatrix3D.M33.ToString()
			OffsetZText.Text = rotationMatrix3D.OffsetZ.ToString()
			M14Text.Text = rotationMatrix3D.M14.ToString()
			M24Text.Text = rotationMatrix3D.M24.ToString()
			M34Text.Text = rotationMatrix3D.M34.ToString()
			M44Text.Text = rotationMatrix3D.M44.ToString()

			myprocTransformGroup.Children.Clear()
			myprocTransformGroup.Children.Add(myRotateTransform3D)
			topModelVisual3D.Transform = myprocTransformGroup

			'<SnippetMatrixTransform3DView3DN3>
			'convert to quaternion and update display
			Try
				Dim tempQuaternion As New Quaternion(axis, angle)
				QuaternionWText.Text = tempQuaternion.W.ToString()
				QuaternionXText.Text = tempQuaternion.X.ToString()
				QuaternionYText.Text = tempQuaternion.Y.ToString()
				QuaternionZText.Text = tempQuaternion.Z.ToString()
			Catch
				MessageBox.Show("Set non-null values for the axis Vector3D.")
			End Try
			'</SnippetMatrixTransform3DView3DN3>
		End Sub

		Private Sub UpdateQuaternionRotation3D(ByVal sender As Object, ByVal e As EventArgs)
			'Clear prior values
			'find a cleaner way to do this--loop?
			RotationAxisXText.Clear()
			RotationAxisYText.Clear()
			RotationAxisZText.Clear()
			RotationAngleText.Clear()

			M11Text.Clear()
			M21Text.Clear()
			M31Text.Clear()
			OffsetXText.Clear()
			M12Text.Clear()
			M22Text.Clear()
			M32Text.Clear()
			OffsetYText.Clear()
			M13Text.Clear()
			M23Text.Clear()
			M33Text.Clear()
			OffsetZText.Clear()
			M14Text.Clear()
			M24Text.Clear()
			M34Text.Clear()
			M44Text.Clear()

			'<SnippetMatrixTransform3DView3DN4>
			'Read new settings
			Try
				Dim WValue As Double = Convert.ToDouble(QuaternionWText.Text)
				Dim XValue As Double = Convert.ToDouble(QuaternionXText.Text)
				Dim YValue As Double = Convert.ToDouble(QuaternionYText.Text)
				Dim ZValue As Double = Convert.ToDouble(QuaternionZText.Text)

				endQuaternion = New Quaternion(XValue, YValue, ZValue, WValue)
			Catch
				MessageBox.Show("Set non-null values for the quaternion.")
			End Try

			myQuaternionRotation3D = New QuaternionRotation3D(endQuaternion)
			myRotateTransform3D.Rotation = myQuaternionRotation3D

			'update matrix display
			qrotationMatrix3D = myRotateTransform3D.Value
			'</SnippetMatrixTransform3DView3DN4>

			M11Text.Text = qrotationMatrix3D.M11.ToString()
			M21Text.Text = qrotationMatrix3D.M21.ToString()
			M31Text.Text = qrotationMatrix3D.M31.ToString()
			OffsetXText.Text = qrotationMatrix3D.OffsetX.ToString()
			M12Text.Text = qrotationMatrix3D.M12.ToString()
			M22Text.Text = qrotationMatrix3D.M22.ToString()
			M32Text.Text = qrotationMatrix3D.M32.ToString()
			OffsetYText.Text = qrotationMatrix3D.OffsetY.ToString()
			M13Text.Text = qrotationMatrix3D.M13.ToString()
			M23Text.Text = qrotationMatrix3D.M23.ToString()
			M33Text.Text = qrotationMatrix3D.M33.ToString()
			OffsetZText.Text = qrotationMatrix3D.OffsetZ.ToString()
			M14Text.Text = qrotationMatrix3D.M14.ToString()
			M24Text.Text = qrotationMatrix3D.M24.ToString()
			M34Text.Text = qrotationMatrix3D.M34.ToString()
			M44Text.Text = qrotationMatrix3D.M44.ToString()

			'apply transform
			myprocTransformGroup.Children.Clear()
			myprocTransformGroup.Children.Add(myRotateTransform3D)
			topModelVisual3D.Transform = myprocTransformGroup

			'convert to axis/angle and display results
			RotationAxisXText.Text = endQuaternion.Axis.X.ToString()
			RotationAxisYText.Text = endQuaternion.Axis.X.ToString()
			RotationAxisZText.Text = endQuaternion.Axis.X.ToString()
			RotationAngleText.Text = endQuaternion.Angle.ToString()
		End Sub

		Private Sub UpdateTranslation(ByVal sender As Object, ByVal e As EventArgs)

			Dim OffsetXValue As Double = Convert.ToDouble(TranslateOffsetXText.Text)
			Dim OffsetYValue As Double = Convert.ToDouble(TranslateOffsetYText.Text)
			Dim OffsetZValue As Double = Convert.ToDouble(TranslateOffsetZText.Text)
			Dim convertVector3D As New Vector3D(OffsetXValue, OffsetYValue, OffsetZValue)
			myTranslateTransform3D = New TranslateTransform3D(OffsetXValue, OffsetYValue, OffsetZValue)

			If addTranslationCheck.IsChecked = False Then
				myprocTransformGroup.Children.Clear()
				myprocTransformGroup.Children.Add(myTranslateTransform3D)
				topModelVisual3D.Transform = myprocTransformGroup
			End If
			If addTranslationCheck.IsChecked = True Then
				myprocTransformGroup.Children.Add(myTranslateTransform3D)
				topModelVisual3D.Transform = myprocTransformGroup
			End If

			Dim tempMatrix3D As Matrix3D = myprocTransformGroup.Value
			M11Text.Text = tempMatrix3D.M11.ToString()
			M21Text.Text = tempMatrix3D.M21.ToString()
			M31Text.Text = tempMatrix3D.M31.ToString()
			OffsetXText.Text = tempMatrix3D.OffsetX.ToString()
			M12Text.Text = tempMatrix3D.M12.ToString()
			M22Text.Text = tempMatrix3D.M22.ToString()
			M32Text.Text = tempMatrix3D.M32.ToString()
			OffsetYText.Text = tempMatrix3D.OffsetY.ToString()
			M13Text.Text = tempMatrix3D.M13.ToString()
			M23Text.Text = tempMatrix3D.M23.ToString()
			M33Text.Text = tempMatrix3D.M33.ToString()
			OffsetZText.Text = tempMatrix3D.OffsetZ.ToString()
			M14Text.Text = tempMatrix3D.M14.ToString()
			M24Text.Text = tempMatrix3D.M24.ToString()
			M34Text.Text = tempMatrix3D.M34.ToString()
			M44Text.Text = tempMatrix3D.M44.ToString()
		End Sub

		'<SnippetMatrixTransform3DView3DN11>
		Private Sub SetMatrixCamera(ByVal sender As Object, ByVal e As EventArgs)
			'Define matrices for ViewMatrix and ProjectionMatrix properties.
			Dim vmatrix As New Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)
			Dim pmatrix As New Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)

			Dim mCamera As New MatrixCamera(vmatrix, pmatrix)
			myViewport.Camera = mCamera
		End Sub
		'</SnippetMatrixTransform3DView3DN11>
	End Class
End Namespace