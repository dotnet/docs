' <SnippetEmissiveMaterialCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

Namespace SDKSample
	Partial Public Class EmissiveMaterialExample
		Inherits Page
		Public Sub New()

			' Declare scene objects.
			Dim myViewport3D As New Viewport3D()
			Dim myModel3DGroup As New Model3DGroup()
			Dim myGeometryModel As New GeometryModel3D()
			Dim myModelVisual3D As New ModelVisual3D()

			' Defines the camera used to view the 3D object. In order to view the 3D object,
			' the camera must be positioned and pointed such that the object is within view 
			' of the camera.
			Dim myPCamera As New PerspectiveCamera()

			' Specify where in the 3D scene the camera is.
			myPCamera.Position = New Point3D(0, 0, 2)

			' Specify the direction that the camera is pointing.
			myPCamera.LookDirection = New Vector3D(0, 0, -1)

			' Define camera's horizontal field of view in degrees.
			myPCamera.FieldOfView = 60

			' Asign the camera to the viewport
			myViewport3D.Camera = myPCamera

			' Define the lights cast in the scene. Without light, the 3D object cannot 
            ' be seen. Note: to illuminate an object from additional directions, create 
            ' additional lights.
            Dim myDirectionalLight As New DirectionalLight()
			myDirectionalLight.Color = Colors.White
			myDirectionalLight.Direction = New Vector3D(-0.61, -0.5, -0.61)

			myModel3DGroup.Children.Add(myDirectionalLight)

			' The geometry specifes the shape of the 3D plane. In this sample, a flat sheet 
			' is created.
			Dim myMeshGeometry3D As New MeshGeometry3D()

			' Create a collection of normal vectors for the MeshGeometry3D.
			Dim myNormalCollection As New Vector3DCollection()
			myNormalCollection.Add(New Vector3D(0,0,1))
			myNormalCollection.Add(New Vector3D(0,0,1))
			myNormalCollection.Add(New Vector3D(0,0,1))
			myNormalCollection.Add(New Vector3D(0,0,1))
			myNormalCollection.Add(New Vector3D(0,0,1))
			myNormalCollection.Add(New Vector3D(0,0,1))
			myMeshGeometry3D.Normals = myNormalCollection

			' Create a collection of vertex positions for the MeshGeometry3D. 
			Dim myPositionCollection As New Point3DCollection()
			myPositionCollection.Add(New Point3D(-0.5, -0.5, 0.5))
			myPositionCollection.Add(New Point3D(0.5, -0.5, 0.5))
			myPositionCollection.Add(New Point3D(0.5, 0.5, 0.5))
			myPositionCollection.Add(New Point3D(0.5, 0.5, 0.5))
			myPositionCollection.Add(New Point3D(-0.5, 0.5, 0.5))
			myPositionCollection.Add(New Point3D(-0.5, -0.5, 0.5))
			myMeshGeometry3D.Positions = myPositionCollection

			' Create a collection of texture coordinates for the MeshGeometry3D.
			Dim myTextureCoordinatesCollection As New PointCollection()
			myTextureCoordinatesCollection.Add(New Point(0, 0))
			myTextureCoordinatesCollection.Add(New Point(1, 0))
			myTextureCoordinatesCollection.Add(New Point(1, 1))
			myTextureCoordinatesCollection.Add(New Point(1, 1))
			myTextureCoordinatesCollection.Add(New Point(0, 1))
			myTextureCoordinatesCollection.Add(New Point(0, 0))
			myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection

			' Create a collection of triangle indices for the MeshGeometry3D.
			Dim myTriangleIndicesCollection As New Int32Collection()
			myTriangleIndicesCollection.Add(0)
			myTriangleIndicesCollection.Add(1)
			myTriangleIndicesCollection.Add(2)
			myTriangleIndicesCollection.Add(3)
			myTriangleIndicesCollection.Add(4)
			myTriangleIndicesCollection.Add(5)
			myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection

			' Apply the mesh to the geometry model.
			myGeometryModel.Geometry = myMeshGeometry3D
			' <SnippetEmissiveMaterialCodeExampleInline1>
			' The material property of GeometryModel3D specifies the material applied to the 3D object.  
			' In this sample the material applied to the 3D object is made up of two materials layered  
			' on top of each other - a DiffuseMaterial (gradient brush) with an EmissiveMaterial 
			' layered on top (blue SolidColorBrush). The EmmisiveMaterial alters the appearance of  
			' the gradient toward blue.

			' Create a horizontal linear gradient with four stops.   
			Dim myHorizontalGradient As New LinearGradientBrush()
			myHorizontalGradient.StartPoint = New Point(0, 0.5)
			myHorizontalGradient.EndPoint = New Point(1, 0.5)
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Define material that will use the gradient.
			Dim myDiffuseMaterial As New DiffuseMaterial(myHorizontalGradient)

			' Add this gradient to a MaterialGroup.
			Dim myMaterialGroup As New MaterialGroup()
			myMaterialGroup.Children.Add(myDiffuseMaterial)

			' Define an Emissive Material with a blue brush.
			Dim c As New Color()
			c.ScA = 1
			c.ScB = 255
			c.ScR = 0
			c.ScG = 0
			Dim myEmissiveMaterial As New EmissiveMaterial(New SolidColorBrush(c))

			' Add the Emmisive Material to the Material Group.
			myMaterialGroup.Children.Add(myEmissiveMaterial)

			' Add the composite material to the 3D model.
			myGeometryModel.Material = myMaterialGroup
			' </SnippetEmissiveMaterialCodeExampleInline1>
			' Apply a transform to the object. In this sample, a rotation transform is applied,  
			' rendering the 3D object rotated.
			Dim myRotateTransform3D As New RotateTransform3D()
			Dim myAxisAngleRotation3d As New AxisAngleRotation3D()
			myAxisAngleRotation3d.Axis = New Vector3D(0,3,0)
			myAxisAngleRotation3d.Angle = 40
			myRotateTransform3D.Rotation = myAxisAngleRotation3d
			myGeometryModel.Transform = myRotateTransform3D

			' Add the geometry model to the model group.
			myModel3DGroup.Children.Add(myGeometryModel)

			' Add the group of models to the ModelVisual3d.
			myModelVisual3D.Content = myModel3DGroup
			myViewport3D.Children.Add(myModelVisual3D)

			' Apply the viewport to the page so it will be rendered.
			Me.Content = myViewport3D
		End Sub
	End Class
End Namespace
' </SnippetEmissiveMaterialCodeExampleWholePage>