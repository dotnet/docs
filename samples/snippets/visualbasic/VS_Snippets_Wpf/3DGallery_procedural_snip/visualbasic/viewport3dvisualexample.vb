' <SnippetViewport3DVisualExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

Namespace SDKSample
	Public Class Viewport3dVisualExample
		Inherits Page
		Public Sub New()
			' Instantiate the host visual that hosts the 3D object.
			Dim vh As New MyVisualHost()
			Dim mainPanel As New StackPanel()

			' Add the drawing (3D object) to the page.
			mainPanel.Children.Add(vh)
			Me.Content = mainPanel
		End Sub
	End Class

	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyVisualHost
		Inherits FrameworkElement
		' Create a collection of child visual objects.
		Private _children As VisualCollection

		Public Sub New()
			_children = New VisualCollection(Me)

			' Add the DrawingVisual that represents the 3D object to the collection.
			_children.Add(Create3DVisualObject())
		End Sub

		' Create a DrawingVisual that contains a 3D object.
		Private Function Create3DVisualObject() As DrawingVisual

			' Declare scene objects.

			' The Viewport3DVisual is used instead of the Viewport3D object because this 3D
			' object is drawn directly to the WPF visual layer. Using Viepwor3dVisual can provide 
			' performance benefits over using Viewport3D although it does not support many of the 
			' features that Viewport3D does.
			Dim myViewport3D As New Viewport3DVisual()
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
			myNormalCollection.Add(New Vector3D(0, 0, 1))
			myNormalCollection.Add(New Vector3D(0, 0, 1))
			myNormalCollection.Add(New Vector3D(0, 0, 1))
			myNormalCollection.Add(New Vector3D(0, 0, 1))
			myNormalCollection.Add(New Vector3D(0, 0, 1))
			myNormalCollection.Add(New Vector3D(0, 0, 1))
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

			' The material specifies the material applied to the 3D object. In this sample a  
			' linear gradient covers the surface of the 3D object.

			' Create a horizontal linear gradient with four stops.   
			Dim myHorizontalGradient As New LinearGradientBrush()
			myHorizontalGradient.StartPoint = New Point(0, 0.5)
			myHorizontalGradient.EndPoint = New Point(1, 0.5)
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Define material and apply to the mesh geometries.
			Dim myMaterial As New DiffuseMaterial(myHorizontalGradient)
			myGeometryModel.Material = myMaterial

			' Apply a transform to the object. In this sample, a rotation transform is applied,  
			' rendering the 3D object rotated.
			Dim myRotateTransform3D As New RotateTransform3D()
			Dim myAxisAngleRotation3d As New AxisAngleRotation3D()
			myAxisAngleRotation3d.Axis = New Vector3D(0, 3, 0)
			myAxisAngleRotation3d.Angle = 40
			myRotateTransform3D.Rotation = myAxisAngleRotation3d
			myGeometryModel.Transform = myRotateTransform3D

			' Add the geometry model to the model group.
			myModel3DGroup.Children.Add(myGeometryModel)

			' Add the group of models to the ModelVisual3d.
			myModelVisual3D.Content = myModel3DGroup

			' Create a rectangle to view the 3D object in.
			Dim myRectangle As New Rect()
			myRectangle.Location = New Point(10, 5)
			myRectangle.Size = New Size(900, 900)

			myViewport3D.Children.Add(myModelVisual3D)
			myViewport3D.Viewport = myRectangle

			Dim dv As New DrawingVisual()
			dv.Children.Add(myViewport3D)
			Return dv
		End Function

		' Provide a required override for the VisualChildCount property.
		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return _children.Count
			End Get
		End Property

		' Provide a required override for the GetVisualChild method.
		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			If index < 0 OrElse index > _children.Count Then
				Throw New ArgumentOutOfRangeException()
			End If

			Return CType(_children(index), Visual)
		End Function

		' Provide a required override for the MeasureOverride method.
		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.MeasureOverride(availableSize)
		End Function

		' Provide a required override for the ArrangeOverride method.
		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.ArrangeOverride(finalSize)
		End Function

	End Class
End Namespace
' </SnippetViewport3DVisualExampleWholePage>