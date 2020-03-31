'This is a list of commonly used namespaces for a window.

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

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
		'<SnippetBasic3D3DN11>
		Private myDirLight As New DirectionalLight()
		'</SnippetBasic3D3DN11>
		Private teapotModel As New GeometryModel3D()
		Private myTransforms As New Transform3DCollection()
		Private myViewport As New Viewport3D()

		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)

			'Set camera viewpoint and properties.
			myPCamera.FarPlaneDistance = 20
			myPCamera.NearPlaneDistance = 1
			myPCamera.FieldOfView = 45
			myPCamera.Position = New Point3D(-5, 2, 3)
			myPCamera.LookDirection = New Vector3D(5, -2, -3)
			myPCamera.UpDirection = New Vector3D(0, 1, 0)

			'Add light sources to the scene.
			'<SnippetBasic3D3DN12>
			myDirLight.Color = Colors.White
			myDirLight.Direction = New Vector3D(-3, -4, -5)
			'</SnippetBasic3D3DN12>

			'<SnippetBasic3D3DN1>
			teapotModel.Geometry = CType(Application.Current.Resources("myTeapot"), MeshGeometry3D)
			'</SnippetBasic3D3DN1>

			'Define material and apply to the mesh geometries.
			Dim teapotMaterial As New DiffuseMaterial(New SolidColorBrush(Colors.Blue))

			teapotModel.Material = teapotMaterial

			'Add 3D model and lights to the collection; add the collection to the visual.

			modelGroup.Children.Add(teapotModel)
			'<SnippetBasic3D3DN13>
			modelGroup.Children.Add(myDirLight)
			'</SnippetBasic3D3DN13>

			Dim modelsVisual As New ModelVisual3D()
			modelsVisual.Content = modelGroup

			'Add the visual and camera to the Viewport3D.
			myViewport.Camera = myPCamera
			myViewport.Children.Add(modelsVisual)

			mainWindow.Content = myViewport

		End Sub
	End Class
End Namespace