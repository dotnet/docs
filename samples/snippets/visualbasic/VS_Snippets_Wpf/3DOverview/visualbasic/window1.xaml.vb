Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes


Namespace create_cube
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
		'<Snippet3DOverview3DN18>
		'some scene objects
		Private myViewport As New Viewport3D()
		'</Snippet3DOverview3DN18>
		Private side1 As New GeometryModel3D()
		Private side2 As New GeometryModel3D()
		Private side3 As New GeometryModel3D()
		Private side4 As New GeometryModel3D()
		Private side5 As New GeometryModel3D()
		Private side6 As New GeometryModel3D()
		Private myPCamera As New PerspectiveCamera()
		Private myDLight As New DirectionalLight()
		Private myAmbLight As New AmbientLight()
		Private myMaterials As New MaterialGroup()
		Private cube1TransformGroup As New Transform3DGroup()
		Private cube2TransformGroup As New Transform3DGroup()
		Private cube3TransformGroup As New Transform3DGroup()
		Private allModelsTransformGroup As New Transform3DGroup()
		Private allModels As New Model3DGroup()
		Private cubeModel_1 As New Model3DGroup()
		Private cubeModel_2 As New Model3DGroup()
		Private cubeModel_3 As New Model3DGroup()
		'<Snippet3DOverview3DN6>
		Private side1Plane As New MeshGeometry3D()
		'</Snippet3DOverview3DN6>
		Private side2Plane As New MeshGeometry3D()
		Private side3Plane As New MeshGeometry3D()
		Private side4Plane As New MeshGeometry3D()
		Private side5Plane As New MeshGeometry3D()
		Private side6Plane As New MeshGeometry3D()
		Private side1Material As New DiffuseMaterial()
		Private side2Material As New DiffuseMaterial()
		Private side3Material As New DiffuseMaterial()
		Private side4Material As New DiffuseMaterial()
		Private side5Material As New DiffuseMaterial()
		Private side6Material As New DiffuseMaterial()


		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			DrawMeshes()
			DrawSomeModels()
		End Sub

		Private Sub DrawSomeModels()
			myViewport.Name = "myViewport"
			Dim myModelVisual As New ModelVisual3D()

			'Define lights and cameras
			myPCamera.FarPlaneDistance = 20
			myPCamera.NearPlaneDistance = 0
			myPCamera.FieldOfView = 50
			myPCamera.Position = New Point3D(-5, 2, 3)
			myPCamera.LookDirection = New Vector3D(5, -2, -3)
			myPCamera.UpDirection = New Vector3D(0, 1, 0)

			myDLight.Color = Colors.White
			myDLight.Direction = New Vector3D(-3, -4, -5)

			myAmbLight.Color = Colors.White

			'set Geometry property of MeshGeometry3D
			side2.Geometry = side2Plane
			side6.Geometry = side6Plane
			side1.Geometry = side1Plane
			side3.Geometry = side3Plane
			side4.Geometry = side4Plane
			side5.Geometry = side5Plane

			'create translations
			'<Snippet3DOverview3DN19>
			Dim cube2Translation As New TranslateTransform3D(New Vector3D(2, 0, 0))
			'</Snippet3DOverview3DN19>
			Dim cube3Translation As New TranslateTransform3D(New Vector3D(4, 0, 0))
			'<Snippet3DOverview3DN1>
			'Define a rotation
			Dim myRotateTransform As New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 1, 0), 1))
			'</Snippet3DOverview3DN1>
			'<Snippet3DOverview3DN2>
			'Define an animation for the rotation
			Dim myAnimation As New DoubleAnimation()
			myAnimation.From = 1
			myAnimation.To = 361
			myAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(5000))
			myAnimation.RepeatBehavior = RepeatBehavior.Forever
			'</Snippet3DOverview3DN2>

			'Define another animation
			'<Snippet3DOverview3DN3>
			Dim myVectorAnimation As New Vector3DAnimation(New Vector3D(-1, -1, -1), New Duration(TimeSpan.FromMilliseconds(5000)))
			myVectorAnimation.RepeatBehavior = RepeatBehavior.Forever
			'</Snippet3DOverview3DN3>


			myRotateTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, myAnimation)
			'<Snippet3DOverview3DN4>
			myRotateTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AxisProperty, myVectorAnimation)
			'</Snippet3DOverview3DN4>
			'<Snippet3DOverview3DN5>
			'Add transformation to the model
			cube1TransformGroup.Children.Add(myRotateTransform)
			'</Snippet3DOverview3DN5>

			cube2TransformGroup.Children.Add(myRotateTransform)
			cube2TransformGroup.Children.Add(cube2Translation)

			cube3TransformGroup.Children.Add(myRotateTransform)
			cube3TransformGroup.Children.Add(cube3Translation)

			allModelsTransformGroup.Children.Add(myRotateTransform)

			cubeModel_1.Children.Add(side1)
			cubeModel_1.Children.Add(side2)
			cubeModel_1.Children.Add(side3)
			cubeModel_1.Children.Add(side4)
			cubeModel_1.Children.Add(side5)
			cubeModel_1.Children.Add(side6)
			cubeModel_1.Transform = cube1TransformGroup

			cubeModel_2.Children.Add(side1)
			cubeModel_2.Children.Add(side2)
			cubeModel_2.Children.Add(side3)
			cubeModel_2.Children.Add(side4)
			cubeModel_2.Children.Add(side5)
			cubeModel_2.Children.Add(side6)
			cubeModel_2.Transform = cube2TransformGroup

			cubeModel_3.Children.Add(side1)
			cubeModel_3.Children.Add(side2)
			cubeModel_3.Children.Add(side3)
			cubeModel_3.Children.Add(side4)
			cubeModel_3.Children.Add(side5)
			cubeModel_3.Children.Add(side6)
			cubeModel_3.Transform = cube3TransformGroup

			allModels.Transform = allModelsTransformGroup
			allModels.Children.Add(cubeModel_3)
			allModels.Children.Add(cubeModel_2)
			allModels.Children.Add(cubeModel_1)

			allModels.Children.Add(myAmbLight)

			myViewport.Camera = myPCamera
			myModelVisual.Content = allModels
			myViewport.Children.Add(myModelVisual)

			mainWindow.Content = myViewport
		End Sub

		Private Sub DrawMeshes()
			'side1-------------------------------------------------
			'<Snippet3DOverview3DN7>
			side1Plane.Positions.Add(New Point3D(-0.5, -0.5, -0.5))
			side1Plane.Positions.Add(New Point3D(-0.5, 0.5, -0.5))
			side1Plane.Positions.Add(New Point3D(0.5, 0.5, -0.5))
			side1Plane.Positions.Add(New Point3D(0.5, 0.5, -0.5))
			side1Plane.Positions.Add(New Point3D(0.5, -0.5, -0.5))
			side1Plane.Positions.Add(New Point3D(-0.5, -0.5, -0.5))

			side1Plane.TriangleIndices.Add(0)
			side1Plane.TriangleIndices.Add(1)
			side1Plane.TriangleIndices.Add(2)
			side1Plane.TriangleIndices.Add(3)
			side1Plane.TriangleIndices.Add(4)
			side1Plane.TriangleIndices.Add(5)

			side1Plane.Normals.Add(New Vector3D(0, 0, -1))
			side1Plane.Normals.Add(New Vector3D(0, 0, -1))
			side1Plane.Normals.Add(New Vector3D(0, 0, -1))
			side1Plane.Normals.Add(New Vector3D(0, 0, -1))
			side1Plane.Normals.Add(New Vector3D(0, 0, -1))
			side1Plane.Normals.Add(New Vector3D(0, 0, -1))

			side1Plane.TextureCoordinates.Add(New Point(1, 0))
			side1Plane.TextureCoordinates.Add(New Point(1, 1))
			side1Plane.TextureCoordinates.Add(New Point(0, 1))
			side1Plane.TextureCoordinates.Add(New Point(0, 1))
			side1Plane.TextureCoordinates.Add(New Point(0, 0))
			side1Plane.TextureCoordinates.Add(New Point(1, 0))
			'</Snippet3DOverview3DN7>

			'side2-------------------------------------------------
			side2Plane.Positions.Add(New Point3D(-0.5, -0.5, 0.5))
			side2Plane.Positions.Add(New Point3D(0.5, -0.5, 0.5))
			side2Plane.Positions.Add(New Point3D(0.5, 0.5, 0.5))
			side2Plane.Positions.Add(New Point3D(0.5, 0.5, 0.5))
			side2Plane.Positions.Add(New Point3D(-0.5, 0.5, 0.5))
			side2Plane.Positions.Add(New Point3D(-0.5, -0.5, 0.5))

			side2Plane.TriangleIndices.Add(0)
			side2Plane.TriangleIndices.Add(1)
			side2Plane.TriangleIndices.Add(2)
			side2Plane.TriangleIndices.Add(3)
			side2Plane.TriangleIndices.Add(4)
			side2Plane.TriangleIndices.Add(5)

			side2Plane.Normals.Add(New Vector3D(0, 0, 1))
			side2Plane.Normals.Add(New Vector3D(0, 0, 1))
			side2Plane.Normals.Add(New Vector3D(0, 0, 1))
			side2Plane.Normals.Add(New Vector3D(0, 0, 1))
			side2Plane.Normals.Add(New Vector3D(0, 0, 1))
			side2Plane.Normals.Add(New Vector3D(0, 0, 1))

			side2Plane.TextureCoordinates.Add(New Point(0, 0))
			side2Plane.TextureCoordinates.Add(New Point(1, 0))
			side2Plane.TextureCoordinates.Add(New Point(1, 1))
			side2Plane.TextureCoordinates.Add(New Point(1, 1))
			side2Plane.TextureCoordinates.Add(New Point(0, 1))
			side2Plane.TextureCoordinates.Add(New Point(0, 0))

			'side3-------------------------------------------------
			side3Plane.Positions.Add(New Point3D(-0.5, -0.5, -0.5))
			side3Plane.Positions.Add(New Point3D(0.5, -0.5, -0.5))
			side3Plane.Positions.Add(New Point3D(0.5, -0.5, 0.5))
			side3Plane.Positions.Add(New Point3D(0.5, -0.5, 0.5))
			side3Plane.Positions.Add(New Point3D(-0.5, -0.5, 0.5))
			side3Plane.Positions.Add(New Point3D(-0.5, -0.5, -0.5))

			side3Plane.TriangleIndices.Add(0)
			side3Plane.TriangleIndices.Add(1)
			side3Plane.TriangleIndices.Add(2)
			side3Plane.TriangleIndices.Add(3)
			side3Plane.TriangleIndices.Add(4)
			side3Plane.TriangleIndices.Add(5)

			side3Plane.Normals.Add(New Vector3D(0, -1, 0))
			side3Plane.Normals.Add(New Vector3D(0, -1, 0))
			side3Plane.Normals.Add(New Vector3D(0, -1, 0))
			side3Plane.Normals.Add(New Vector3D(0, -1, 0))
			side3Plane.Normals.Add(New Vector3D(0, -1, 0))
			side3Plane.Normals.Add(New Vector3D(0, -1, 0))

			side3Plane.TextureCoordinates.Add(New Point(0, 0))
			side3Plane.TextureCoordinates.Add(New Point(1, 0))
			side3Plane.TextureCoordinates.Add(New Point(1, 1))
			side3Plane.TextureCoordinates.Add(New Point(1, 1))
			side3Plane.TextureCoordinates.Add(New Point(0, 1))
			side3Plane.TextureCoordinates.Add(New Point(0, 0))

			'side4-------------------------------------------------
			side4Plane.Positions.Add(New Point3D(0.5, -0.5, -0.5))
			side4Plane.Positions.Add(New Point3D(0.5, 0.5, -0.5))
			side4Plane.Positions.Add(New Point3D(0.5, 0.5, 0.5))
			side4Plane.Positions.Add(New Point3D(0.5, 0.5, 0.5))
			side4Plane.Positions.Add(New Point3D(0.5, -0.5, 0.5))
			side4Plane.Positions.Add(New Point3D(0.5, -0.5, -0.5))

			side4Plane.TriangleIndices.Add(0)
			side4Plane.TriangleIndices.Add(1)
			side4Plane.TriangleIndices.Add(2)
			side4Plane.TriangleIndices.Add(3)
			side4Plane.TriangleIndices.Add(4)
			side4Plane.TriangleIndices.Add(5)

			side4Plane.Normals.Add(New Vector3D(1, 0, 0))
			side4Plane.Normals.Add(New Vector3D(1, 0, 0))
			side4Plane.Normals.Add(New Vector3D(1, 0, 0))
			side4Plane.Normals.Add(New Vector3D(1, 0, 0))
			side4Plane.Normals.Add(New Vector3D(1, 0, 0))
			side4Plane.Normals.Add(New Vector3D(1, 0, 0))

			side4Plane.TextureCoordinates.Add(New Point(1, 0))
			side4Plane.TextureCoordinates.Add(New Point(1, 1))
			side4Plane.TextureCoordinates.Add(New Point(0, 1))
			side4Plane.TextureCoordinates.Add(New Point(0, 1))
			side4Plane.TextureCoordinates.Add(New Point(0, 0))
			side4Plane.TextureCoordinates.Add(New Point(1, 0))

			'side5-------------------------------------------------
			side5Plane.Positions.Add(New Point3D(0.5, 0.5, -0.5))
			side5Plane.Positions.Add(New Point3D(-0.5, 0.5, -0.5))
			side5Plane.Positions.Add(New Point3D(-0.5, 0.5, 0.5))
			side5Plane.Positions.Add(New Point3D(-0.5, 0.5, 0.5))
			side5Plane.Positions.Add(New Point3D(0.5, 0.5, 0.5))
			side5Plane.Positions.Add(New Point3D(0.5, 0.5, -0.5))

			side5Plane.TriangleIndices.Add(0)
			side5Plane.TriangleIndices.Add(1)
			side5Plane.TriangleIndices.Add(2)
			side5Plane.TriangleIndices.Add(3)
			side5Plane.TriangleIndices.Add(4)
			side5Plane.TriangleIndices.Add(5)

			side5Plane.Normals.Add(New Vector3D(0, 1, 0))
			side5Plane.Normals.Add(New Vector3D(0, 1, 0))
			side5Plane.Normals.Add(New Vector3D(0, 1, 0))
			side5Plane.Normals.Add(New Vector3D(0, 1, 0))
			side5Plane.Normals.Add(New Vector3D(0, 1, 0))
			side5Plane.Normals.Add(New Vector3D(0, 1, 0))

			side5Plane.TextureCoordinates.Add(New Point(1, 1))
			side5Plane.TextureCoordinates.Add(New Point(0, 1))
			side5Plane.TextureCoordinates.Add(New Point(0, 0))
			side5Plane.TextureCoordinates.Add(New Point(0, 0))
			side5Plane.TextureCoordinates.Add(New Point(1, 0))
			side5Plane.TextureCoordinates.Add(New Point(1, 1))

			'side6-------------------------------------------------
			side6Plane.Positions.Add(New Point3D(-0.5, 0.5, -0.5))
			side6Plane.Positions.Add(New Point3D(-0.5, -0.5, -0.5))
			side6Plane.Positions.Add(New Point3D(-0.5, -0.5, 0.5))
			side6Plane.Positions.Add(New Point3D(-0.5, -0.5, 0.5))
			side6Plane.Positions.Add(New Point3D(-0.5, 0.5, 0.5))
			side6Plane.Positions.Add(New Point3D(-0.5, 0.5, -0.5))

			side6Plane.TriangleIndices.Add(0)
			side6Plane.TriangleIndices.Add(1)
			side6Plane.TriangleIndices.Add(2)
			side6Plane.TriangleIndices.Add(3)
			side6Plane.TriangleIndices.Add(4)
			side6Plane.TriangleIndices.Add(5)

			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))
			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))
			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))
			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))
			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))
			side6Plane.Normals.Add(New Vector3D(-1, 0, 0))

			side6Plane.TextureCoordinates.Add(New Point(0, 1))
			side6Plane.TextureCoordinates.Add(New Point(0, 0))
			side6Plane.TextureCoordinates.Add(New Point(1, 0))
			side6Plane.TextureCoordinates.Add(New Point(1, 0))
			side6Plane.TextureCoordinates.Add(New Point(1, 1))
			side6Plane.TextureCoordinates.Add(New Point(0, 1))


			'Set Brush property for the Material applied to each face
			Dim side2Material As New DiffuseMaterial(CType(Application.Current.Resources("yellowBrush"), Brush))
			Dim side6Material As New DiffuseMaterial(CType(Application.Current.Resources("orangeBrush"), Brush))


			Dim side1Material As New DiffuseMaterial(CType(Application.Current.Resources("blueBrush"), Brush))
			Dim side3Material As New DiffuseMaterial(CType(Application.Current.Resources("redBrush"), Brush))
			Dim side4Material As New DiffuseMaterial(CType(Application.Current.Resources("cyanBrush"), Brush))
			'<Snippet3DOverview3DN8>
			Dim side5Material As New DiffuseMaterial(CType(Application.Current.Resources("patternBrush"), Brush))
			'</Snippet3DOverview3DN8>


			side2.Material = side2Material
			side6.Material = side6Material
			side1.Material = side1Material
			side3.Material = side3Material
			side4.Material = side4Material
			side5.Material = side5Material


		End Sub

	End Class
End Namespace