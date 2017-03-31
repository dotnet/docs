Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Media3D


Namespace Shapes
	'<SnippetSphere>
	Public Class Sphere
		Inherits UIElement3D
		' <SnippetSummary>
		' OnUpdateModel is called in response to InvalidateModel and provides
		' a place to set the Visual3DModel property.
		' 
		' Setting Visual3DModel does not provide parenting information, which
		' is needed for data binding, styling, and other features. Similarly, creating render data
		' in 2-D does not provide the connections either.
		' 
		' To get around this, we create a Model dependency property which
		' sets this value.  The Model DP then causes the correct connections to occur
		' and the above features to work correctly.
		' 
		' In this update model we retessellate the sphere based on the current
		' dependency property values, and then set it as the model.  The brush
		' color is blue by default, but the code can easily be updated to let
		' this be set by the user.
		' </SnippetSummary>

		'<SnippetOnUpdateModel>
		Protected Overrides Sub OnUpdateModel()
			Dim model As New GeometryModel3D()

			model.Geometry = Tessellate(ThetaDiv, PhiDiv, Radius)
			model.Material = New DiffuseMaterial(System.Windows.Media.Brushes.Blue)

			Me.Model = model
		End Sub
		'</SnippetOnUpdateModel>

		'<SnippetModelProperty>
		' The Model property for the sphere
		Private Shared ReadOnly ModelProperty As DependencyProperty = DependencyProperty.Register("Model", GetType(Model3D), GetType(Sphere), New PropertyMetadata(AddressOf ModelPropertyChanged))

		Private Shared Sub ModelPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim s As Sphere = CType(d, Sphere)
			s.Visual3DModel = s.Model
		End Sub

		Private Property Model() As Model3D
			Get
				Return CType(GetValue(ModelProperty), Model3D)
			End Get

			Set(ByVal value As Model3D)
				SetValue(ModelProperty, value)
			End Set
		End Property
		'</SnippetModelProperty>

		'<SnippetThetaProperty>
		' The number of divisions to make in the theta direction on the sphere
		Public Shared ReadOnly ThetaDivProperty As DependencyProperty = DependencyProperty.Register("ThetaDiv", GetType(Integer), GetType(Sphere), New PropertyMetadata(15, AddressOf ThetaDivPropertyChanged))

		Private Shared Sub ThetaDivPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim s As Sphere = CType(d, Sphere)
			s.InvalidateModel()
		End Sub

		Public Property ThetaDiv() As Integer
			Get
                Return CInt(GetValue(ThetaDivProperty))
			End Get

			Set(ByVal value As Integer)
				SetValue(ThetaDivProperty, value)
			End Set
		End Property
		'</SnippetThetaProperty>

		'<SnippetPhiProperty>
		' The number of divisions to make in the phi direction on the sphere
		Public Shared ReadOnly PhiDivProperty As DependencyProperty = DependencyProperty.Register("PhiDiv", GetType(Integer), GetType(Sphere), New PropertyMetadata(15, AddressOf PhiDivPropertyChanged))

		Private Shared Sub PhiDivPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim s As Sphere = CType(d, Sphere)
			s.InvalidateModel()
		End Sub

		Public Property PhiDiv() As Integer
			Get
                Return CInt(GetValue(PhiDivProperty))
			End Get

			Set(ByVal value As Integer)
				SetValue(PhiDivProperty, value)
			End Set
		End Property
		'</SnippetPhiProperty>

		'<SnippetRadius>
		' The radius of the sphere
		Public Shared ReadOnly RadiusProperty As DependencyProperty = DependencyProperty.Register("Radius", GetType(Double), GetType(Sphere), New PropertyMetadata(1.0, AddressOf RadiusPropertyChanged))

		Private Shared Sub RadiusPropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim s As Sphere = CType(d, Sphere)
			s.InvalidateModel()
		End Sub

		Public Property Radius() As Double
			Get
				Return CDbl(GetValue(RadiusProperty))
			End Get

			Set(ByVal value As Double)
				SetValue(RadiusProperty, value)
			End Set
		End Property
		'</SnippetRadius>

		'<SnippetPrivateMethods>
		' Private helper methods
		Private Shared Function GetPosition(ByVal theta As Double, ByVal phi As Double, ByVal radius As Double) As Point3D
			Dim x As Double = radius * Math.Sin(theta) * Math.Sin(phi)
			Dim y As Double = radius * Math.Cos(phi)
			Dim z As Double = radius * Math.Cos(theta) * Math.Sin(phi)

			Return New Point3D(x, y, z)
		End Function

		Private Shared Function GetNormal(ByVal theta As Double, ByVal phi As Double) As Vector3D
			Return CType(GetPosition(theta, phi, 1.0), Vector3D)
		End Function

		Private Shared Function DegToRad(ByVal degrees As Double) As Double
			Return (degrees / 180.0) * Math.PI
		End Function

		Private Shared Function GetTextureCoordinate(ByVal theta As Double, ByVal phi As Double) As System.Windows.Point
			Dim p As New System.Windows.Point(theta / (2 * Math.PI), phi / (Math.PI))

			Return p
		End Function
		'</SnippetPrivateMethods>

		'<SnippetTessellate>
		' Tesselates the sphere and returns a MeshGeometry3D representing the 
		' tessellation based on the given parameters
		Friend Shared Function Tessellate(ByVal tDiv As Integer, ByVal pDiv As Integer, ByVal radius As Double) As MeshGeometry3D
			Dim dt As Double = DegToRad(360.0) / tDiv
			Dim dp As Double = DegToRad(180.0) / pDiv

			Dim mesh As New MeshGeometry3D()

			For pi As Integer = 0 To pDiv
				Dim phi As Double = pi * dp

				For ti As Integer = 0 To tDiv
					' we want to start the mesh on the x axis
					Dim theta As Double = ti * dt

					mesh.Positions.Add(GetPosition(theta, phi, radius))
					mesh.Normals.Add(GetNormal(theta, phi))
					mesh.TextureCoordinates.Add(GetTextureCoordinate(theta, phi))
				Next ti
			Next pi

			For pi As Integer = 0 To pDiv - 1
				For ti As Integer = 0 To tDiv - 1
					Dim x0 As Integer = ti
					Dim x1 As Integer = (ti + 1)
					Dim y0 As Integer = pi * (tDiv + 1)
					Dim y1 As Integer = (pi + 1) * (tDiv + 1)

					mesh.TriangleIndices.Add(x0 + y0)
					mesh.TriangleIndices.Add(x0 + y1)
					mesh.TriangleIndices.Add(x1 + y0)

					mesh.TriangleIndices.Add(x1 + y0)
					mesh.TriangleIndices.Add(x0 + y1)
					mesh.TriangleIndices.Add(x1 + y1)
				Next ti
			Next pi

			mesh.Freeze()
			Return mesh
		End Function
		'</SnippetTessellate>
	End Class
	'</SnippetSphere>
End Namespace
