Imports System.Collections
Imports System.Windows.Media.Media3D


Namespace HitTest3D
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetHitTest3D3DN4>
		Public Sub HitTest(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
			Dim mouseposition As Point = args.GetPosition(myViewport)
			Dim testpoint3D As New Point3D(mouseposition.X, mouseposition.Y, 0)
			Dim testdirection As New Vector3D(mouseposition.X, mouseposition.Y, 10)
			Dim pointparams As New PointHitTestParameters(mouseposition)
			Dim rayparams As New RayHitTestParameters(testpoint3D, testdirection)

			'test for a result in the Viewport3D
			VisualTreeHelper.HitTest(myViewport, Nothing, AddressOf HTResult, pointparams)
		'</SnippetHitTest3D3DN4>
			UpdateTestPointInfo(testpoint3D, testdirection)
		End Sub

		'<SnippetHitTest3D3DN5>
		Public Function HTResult(ByVal rawresult As HitTestResult) As HitTestResultBehavior
            Dim rayResult As RayHitTestResult = TryCast(rawresult, RayHitTestResult)

			If rayResult IsNot Nothing Then
				Dim rayMeshResult As RayMeshGeometry3DHitTestResult = TryCast(rayResult, RayMeshGeometry3DHitTestResult)

				If rayMeshResult IsNot Nothing Then
					Dim hitgeo As GeometryModel3D = TryCast(rayMeshResult.ModelHit, GeometryModel3D)

					UpdateResultInfo(rayMeshResult)
					UpdateMaterial(hitgeo, (TryCast(side1GeometryModel3D.Material, MaterialGroup)))
				End If
			End If

			Return HitTestResultBehavior.Continue
		End Function
		'</SnippetHitTest3D3DN5>

		Public Sub UpdateMaterial(ByVal hitgeo As GeometryModel3D, ByVal changegroup As MaterialGroup)
			Dim priorMaterial As MaterialGroup = TryCast(hitgeo.Material, MaterialGroup)

			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide01"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide01"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("BranchesMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If
			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide02"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide02"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("FlowersMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If
			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide03"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide03"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("BerriesMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If
			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide04"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide04"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("LeavesMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If
			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide05"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide05"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("RocksMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If
			If hitgeo.Geometry Is CType(Application.Current.Resources("CubeSide06"), MeshGeometry3D) Then
				HitFaceInfo.Text = "CubeSide06"
				If priorMaterial Is CType(Application.Current.Resources("HitMaterial"), MaterialGroup) Then
					hitgeo.Material = CType(Application.Current.Resources("SunsetMaterial"), MaterialGroup)
				Else
					hitgeo.Material = CType(Application.Current.Resources("HitMaterial"), MaterialGroup)
				End If
			End If

		End Sub

		'<SnippetHitTest3D3DN7>
		Public Sub UpdateResultInfo(ByVal rayMeshResult As RayMeshGeometry3DHitTestResult)
			HitVisualInfo.Text = rayMeshResult.VisualHit.ToString()
			HitModelInfo.Text = rayMeshResult.ModelHit.ToString()
			HitMeshInfo.Text = rayMeshResult.MeshHit.ToString()
            HitDistanceInfo.Text = rayMeshResult.DistanceToRayOrigin.ToString()
			Vertex1Info.Text = (rayMeshResult.VertexWeight1 * 100) & "%"
			Vertex2Info.Text = (rayMeshResult.VertexWeight2 * 100) & "%"
			Vertex3Info.Text = (rayMeshResult.VertexWeight3 * 100) & "%"
		End Sub
		'</SnippetHitTest3D3DN7>

		Public Sub UpdateTestPointInfo(ByVal testpoint3D As Point3D, ByVal testdirection As Vector3D)
			TestPointInfo.Text = "Test point (" & testpoint3D.X & "," & testpoint3D.Y & "," & testpoint3D.Z & ")"
			TestVectorInfo.Text = "Test vector (" & testdirection.X & "," & testdirection.Y & "," & testdirection.Z & ")"
		End Sub

		'<SnippetHitTest3D3DN12>
		'Toggle between camera projections.
		Public Sub ToggleCamera(ByVal sender As Object, ByVal e As EventArgs)
			If CBool(CameraCheck.IsChecked) = True Then
				Dim myOCamera As New OrthographicCamera(New Point3D(0, 0, -3), New Vector3D(0, 0, 1), New Vector3D(0, 1, 0), 3)
				myViewport.Camera = myOCamera
			End If
			If CBool(CameraCheck.IsChecked) <> True Then
				Dim myPCamera As New PerspectiveCamera(New Point3D(0, 0, -3), New Vector3D(0, 0, 1), New Vector3D(0, 1, 0), 50)
				myViewport.Camera = myPCamera
			End If
		End Sub
		'</SnippetHitTest3D3DN12>

		'<SnippetHitTest3D3DN13>
		Public Sub AddAnimation(ByVal sender As Object, ByVal e As EventArgs)
			If CBool(CenterAnimCheck.IsChecked) = True Then
				'Shift point around which model rotates to (-0.5, -0.5, -0.5).
				myHorizontalRTransform.CenterX = -0.5
				myHorizontalRTransform.CenterY = -0.5
				myHorizontalRTransform.CenterZ = -0.5
			End If
			If CBool(CenterAnimCheck.IsChecked) <> True Then
				'Set point around which model rotates back to (0, 0, 0).
				myHorizontalRTransform.CenterX = 0
				myHorizontalRTransform.CenterY = 0
				myHorizontalRTransform.CenterZ = 0
			End If
		End Sub
		'</SnippetHitTest3D3DN13>



	End Class
End Namespace

