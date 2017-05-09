Imports System
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

Namespace SDKSample
	Public Class MyLights
		'<SnippetShow3DLights3DN1>
		' Ambient light value.
		Private _ambLight As New AmbientLight(System.Windows.Media.Brushes.DarkBlue.Color)
		'</SnippetShow3DLights3DN1>

		'<SnippetShow3DLights3DN2>
		' Directional light values.
		Private Const nbrDirLights As Integer = 2
		Private _dirLight(nbrDirLights - 1) As DirectionalLight
		Private _dirVector() As Vector3D = { New Vector3D(0.91, -0.5, -0.26), New Vector3D(-0.91, 0.5, 0.36) }
		Private _dirLightColor() As System.Windows.Media.Color = { System.Windows.Media.Brushes.White.Color, System.Windows.Media.Brushes.Yellow.Color }
		'</SnippetShow3DLights3DN2>

		'<SnippetShow3DLights3DN3>
		' Point light values.
		Private _ptLight As New PointLight()
		'</SnippetShow3DLights3DN3>
		'<SnippetShow3DLights3DN4>
		' ...
		'</SnippetShow3DLights3DN4>

		'<SnippetShow3DLights3DN5>
		Public Sub New()
			For i As Integer = 0 To nbrDirLights - 1
				_dirLight(i) = New DirectionalLight()
				_dirLight(i).Color = _dirLightColor(i)
				_dirLight(i).Direction = _dirVector(i)
			Next i

			_ptLight.Position = New Point3D(-3, -7, 10)
			_ptLight.Color = System.Windows.Media.Brushes.White.Color
			_ptLight.Range = 15.0
			_ptLight.ConstantAttenuation = 3.0
		End Sub
		'</SnippetShow3DLights3DN5>

		Public Sub ShowAmbientLight(ByVal show As Boolean, ByVal modelGroup As Model3DGroup)
			For Each m As Model3D In modelGroup.Children
				Dim s As String = m.ToString()
			Next m
			If show = True Then
				modelGroup.Children.Add(_ambLight)
			End If

			If show = False Then
				modelGroup.Children.Remove(_ambLight)
			End If
		End Sub

		Public Sub ShowDirLight(ByVal index As Integer, ByVal show As Boolean, ByVal modelGroup As Model3DGroup)
			If show = True Then
				modelGroup.Children.Add(_dirLight(index))
			End If

			If show = False Then
				modelGroup.Children.Remove(_dirLight(index))
			End If
		End Sub

		Public Sub ShowPointLight(ByVal indexer As Integer, ByVal show As Boolean, ByVal modelGroup As Model3DGroup)
			If show = True Then
				modelGroup.Children.Add(_ptLight)
			End If

			If show = False Then
				modelGroup.Children.Remove(_ptLight)
			End If
		End Sub

		Public Property PointLightPosition() As Point3D
			Get
				Return _ptLight.Position
			End Get
			Set(ByVal value As Point3D)
				_ptLight.Position = value
			End Set
		End Property

		Public Property PointLightRange() As Double
			Get
				Return _ptLight.Range
			End Get
			Set(ByVal value As Double)
				_ptLight.Range = value
			End Set
		End Property

		Public Property PointLightConstantAttenuation() As Double
			Get
				Return _ptLight.ConstantAttenuation
			End Get
			Set(ByVal value As Double)
				_ptLight.ConstantAttenuation = value
			End Set
		End Property

		Public Property PointLightLinearAttenuation() As Double
			Get
				Return _ptLight.LinearAttenuation
			End Get
			Set(ByVal value As Double)
				_ptLight.LinearAttenuation = value
			End Set
		End Property

		Public Property PointLightQuadraticAttenuation() As Double
			Get
				Return _ptLight.QuadraticAttenuation
			End Get
			Set(ByVal value As Double)
				_ptLight.QuadraticAttenuation = value
			End Set
		End Property

		Public Sub TransformPointLight(ByVal pointLightVector As Vector3D, ByVal changeVector As Vector3D)
			' Transform light vector.
			Dim pointLightTransform As New TranslateTransform3D()
			pointLightTransform.OffsetX = pointLightVector.X
			pointLightTransform.OffsetY = pointLightVector.Y
			pointLightTransform.OffsetZ = pointLightVector.Z
			_ptLight.Position = pointLightTransform.Transform(_ptLight.Position)

		End Sub

	End Class
End Namespace
