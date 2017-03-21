Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Private Shared _mesh As String = ""
		Private Enum KeyMode
			Camera
			PointLight
		End Enum
		Private currKeyMode As KeyMode = KeyMode.Camera
		Private myLights As New MyLights()
		Private objModel As Model3D = Nothing
		Private modelGroup As New Model3DGroup()
		Private modelsVisual As New ModelVisual3D()

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnWindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			CBObjects.SelectedIndex = 0
			myViewport3D.Focus()
		End Sub

		Private Sub OnListBoxChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim fieldOfView() As Double = {50.0, 50.0, 2.0, 75.0, 75.0, 75.0, 20.0 }

			If myViewport3D Is Nothing Then
				Return
			End If

			Dim cbi As ComboBoxItem = CType((CType(sender, ComboBox)).SelectedItem, ComboBoxItem)
			_mesh = cbi.Content.ToString()
			LoadMesh(fieldOfView((CType(sender, ComboBox)).SelectedIndex))
			myViewport3D.Focus()
		End Sub

		' Add or remove an ambient light from the 3D viewport.
		Private Sub OnAmbientLightChange(ByVal sender As Object, ByVal e As EventArgs)
			If checkBoxAmbientLight.IsChecked = True Then
				myLights.ShowAmbientLight(True, modelGroup)
			Else
				myLights.ShowAmbientLight(False, modelGroup)
			End If

			myViewport3D.Focus()
		End Sub

		' Add or remove a directional light from the 3D viewport.
		Private Sub OnDirectionalLightOneChange(ByVal sender As Object, ByVal e As EventArgs)
			If checkBoxDirLightOne.IsChecked = True Then
				myLights.ShowDirLight(0, True, modelGroup)
			Else
				myLights.ShowDirLight(0, False, modelGroup)
			End If

			myViewport3D.Focus()
		End Sub

		' Add or remove a directional light from the 3D viewport.
		Private Sub OnDirectionalLightTwoChange(ByVal sender As Object, ByVal e As EventArgs)
			If checkBoxDirLightTwo.IsChecked = True Then
				myLights.ShowDirLight(1, True, modelGroup)
			Else
				myLights.ShowDirLight(1, False, modelGroup)
			End If

			myViewport3D.Focus()
		End Sub

		' Add or remove a point light from the 3D viewport.
		Private Sub OnPointLight(ByVal sender As Object, ByVal e As EventArgs)
			If checkBoxPointLight.IsChecked = True Then
				currKeyMode = KeyMode.PointLight
				rbPosition2.IsChecked = True
				myLights.ShowPointLight(1, True, modelGroup)
				xyzPointLight.Foreground = System.Windows.Media.Brushes.Black
				xyzPointLight.Content = "x: " & myLights.PointLightPosition.X & "  y: " & myLights.PointLightPosition.Y & "  z: " & myLights.PointLightPosition.Z
			Else
				currKeyMode = KeyMode.Camera
				rbPosition1.IsChecked = True
				myLights.ShowPointLight(1, False, modelGroup)
				xyzPointLight.Foreground = System.Windows.Media.Brushes.LightGray
			End If

			myViewport3D.Focus()
		End Sub

		'<SnippetShow3DLights3DN8>
		Private Sub OnAttenuationChecked(ByVal sender As Object, ByVal e As EventArgs)
			Dim rb As RadioButton = CType(sender, RadioButton)

			If rb.Name = "rbAttenuation1" Then
				myLights.PointLightConstantAttenuation = 3.0
				myLights.PointLightLinearAttenuation = 0.0
				myLights.PointLightQuadraticAttenuation = 0.0
			End If

			If rb.Name = "rbAttenuation2" Then
				myLights.PointLightConstantAttenuation = 0.0
				myLights.PointLightLinearAttenuation = 0.5
				myLights.PointLightQuadraticAttenuation = 0.0
			End If

			If rb.Name = "rbAttenuation3" Then
				myLights.PointLightConstantAttenuation = 0.0
				myLights.PointLightLinearAttenuation = 0.0
				myLights.PointLightQuadraticAttenuation = 0.5
			End If

			If myViewport3D IsNot Nothing Then
				myViewport3D.Focus()
			End If
		End Sub
		'</SnippetShow3DLights3DN8>
		Private Sub OnPositionChecked(ByVal sender As Object, ByVal e As EventArgs)
			Dim rb As RadioButton = CType(sender, RadioButton)

			If rb.Name = "rbPosition1" Then
				currKeyMode = KeyMode.Camera
			End If

			If rb.Name = "rbPosition2" Then
				currKeyMode = KeyMode.PointLight
			End If

			If myViewport3D IsNot Nothing Then
				myViewport3D.Focus()
			End If
		End Sub

		Private Sub OnRange(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim pointLightRange As Double = myLights.PointLightRange

			Try
				pointLightRange = System.Convert.ToDouble(textboxRange.Text)
			Catch
				Return
			End Try

			myLights.PointLightRange = pointLightRange
		End Sub

		Private Sub LoadMesh(ByVal fieldOfView As Double)
			If (myViewport3D IsNot Nothing) AndAlso (modelGroup.Children.Count > 0) Then
				myViewport3D.Children.Remove(modelsVisual)
				modelGroup.Children.Clear()
			End If

			CType(myViewport3D.Camera, PerspectiveCamera).FieldOfView = fieldOfView

			' Define the material for the model.
			Dim brush As New SolidColorBrush(Colors.Cyan)
			Dim colorMaterial As New DiffuseMaterial(brush)

			' Load the mesh for the model.
			Dim objMesh As MeshGeometry3D = CType(Application.Current.Resources(_mesh), MeshGeometry3D)
			objModel = New GeometryModel3D(objMesh, colorMaterial)

			' Define the projection camera and add to the model.
			SetProjectionCamera(myViewport3D, modelGroup)

			modelGroup.Children.Add(objModel)

			' Add ambient light to the model group.
			If checkBoxAmbientLight.IsChecked = True Then
				myLights.ShowAmbientLight(True, modelGroup)
			End If

			' Add directional lights to the model group.
			If checkBoxDirLightOne.IsChecked = True Then
				myLights.ShowDirLight(0, True, modelGroup)
			End If
			If checkBoxDirLightTwo.IsChecked = True Then
				myLights.ShowDirLight(1, True, modelGroup)
			End If

			' Add the model group data to the viewport.
			modelsVisual.Content = modelGroup
			myViewport3D.Children.Add(modelsVisual)

			checkBoxPointLight.IsChecked = False
			xyzPointLight.Foreground = System.Windows.Media.Brushes.LightGray
			currKeyMode = KeyMode.Camera
			rbPosition1.IsChecked = True
		End Sub

		Public Sub SetProjectionCamera(ByVal myViewport3D As Viewport3D, ByVal modelGroup As Model3DGroup)
			Const CameraDistance As Double = 80 ' distance from camera to origin
			Const CameraLatitude As Double = Math.PI / 2 ' angle from +ve y axis to camera (i.e. latitude)
			Const CameraLongitude As Double = Math.PI ' angle from -ve z axis to camera (i.e. longitude)
			Dim x As Double = CameraDistance * -Math.Sin(CameraLongitude) * Math.Sin(CameraLatitude)
			Dim y As Double = CameraDistance * Math.Cos(CameraLatitude)
			Dim z As Double = CameraDistance * -Math.Cos(CameraLongitude) * Math.Sin(CameraLatitude)

			Dim projCamera As ProjectionCamera = TryCast(myViewport3D.Camera.Clone(), ProjectionCamera)
			projCamera.Position = New Point3D(x, y, z)
			myViewport3D.Camera = projCamera

			Dim pan As New TranslateTransform3D(New Vector3D(0, 0, 0))
			modelGroup.Transform = pan
		End Sub

	End Class
End Namespace