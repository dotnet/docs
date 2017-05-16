'This is a list of commonly used namespaces for a window.

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation

Namespace Blank3DSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		'declare scene objects
		Private modelGroup As New Model3DGroup()
		Private myPCamera As New PerspectiveCamera()
		Private myDirLight As New DirectionalLight()
		Private bMaterial As New DiffuseMaterial()
		Private cubeModel As New GeometryModel3D()
		Private coneModel As New GeometryModel3D()
		Private teapotModel As New GeometryModel3D()
		Private myTransforms As New Transform3DCollection()
		Private myModelVisual3D As New ModelVisual3D()
		Private myViewport As New Viewport3D()

		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			RenderSomeModels()
		End Sub

		Private Sub RenderSomeModels()
			myViewport.Name = "myViewport"
			'Set camera viewpoint and properties.
			myPCamera.FarPlaneDistance = 20
			myPCamera.NearPlaneDistance = 1
			myPCamera.FieldOfView = 45
			myPCamera.Position = New Point3D(-5, 2, 3)
			myPCamera.LookDirection = New Vector3D(5, -2, -3)
			myPCamera.UpDirection = New Vector3D(0, 1, 0)

			'Add light sources to the scene.
			myDirLight.Color = Colors.White
			myDirLight.Direction = New Vector3D(-3, -4, -5)

			teapotModel.Geometry = CType(Application.Current.Resources("myTeapot"), MeshGeometry3D)

			'Define DiffuseMaterial and apply to the mesh geometries.
			Dim teapotMaterial As New DiffuseMaterial(New SolidColorBrush(Colors.Blue))

			'<SnippetAnimate3DRotationCode3DN1>
			'<SnippetAnimate3DRotationCode3DN2>
			'Define a transformation
			Dim myRotateTransform As New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 2, 0), 1))
			'</SnippetAnimate3DRotationCode3DN2>
			'<SnippetAnimate3DRotationCode3DN3>
			'Define an animation for the transformation
			Dim myAnimation As New DoubleAnimation()
			myAnimation.From = 1
			myAnimation.To = 361
			myAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(5000))
			myAnimation.RepeatBehavior = RepeatBehavior.Forever
			'</SnippetAnimate3DRotationCode3DN3>
			'Add animation to the transformation
			myRotateTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, myAnimation)

			'<SnippetAnimate3DRotationCode3DN4>
			'Add transformation to the model
			teapotModel.Transform = myRotateTransform
			'</SnippetAnimate3DRotationCode3DN4>
			'</SnippetAnimate3DRotationCode3DN1>

			teapotModel.Material = teapotMaterial

			'Add the model to the model group collection
			modelGroup.Children.Add(teapotModel)
			modelGroup.Children.Add(myDirLight)
			myViewport.Camera = myPCamera

			myModelVisual3D.Content = modelGroup
			myViewport.Children.Add(myModelVisual3D)

			'add the Viewport3D to the window
			mainWindow.Content = myViewport



		End Sub


	End Class
End Namespace