Imports System.Collections

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		' <SnippetHitTestingOverviewSnippet10>
		' Respond to the mouse button down event by setting up a hit test results callback.
		Private Overloads Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Expand the hit test area by creating a geometry centered on the hit test point.
			Dim expandedHitTestArea As New EllipseGeometry(pt, 10.0, 10.0)

			' Clear the contents of the list used for hit test results.
			hitResultsList.Clear()

			' Set up a callback to receive the hit test result enumeration.
			VisualTreeHelper.HitTest(myControl, Nothing, New HitTestResultCallback(AddressOf MyHitTestResultCallback), New GeometryHitTestParameters(expandedHitTestArea))

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				ProcessHitTestResultsList()
			End If
		End Sub
		' </SnippetHitTestingOverviewSnippet10>

		' <SnippetHitTestingOverviewSnippet11>
		' Return the result of the hit test to the callback.
		Public Function MyHitTestResultCallback(ByVal result As HitTestResult) As HitTestResultBehavior
			' Retrieve the results of the hit test.
			Dim intersectionDetail As IntersectionDetail = (CType(result, GeometryHitTestResult)).IntersectionDetail

			Select Case intersectionDetail
				Case IntersectionDetail.FullyContains

					' Add the hit test result to the list that will be processed after the enumeration.
					hitResultsList.Add(result.VisualHit)

					Return HitTestResultBehavior.Continue

				Case IntersectionDetail.Intersects

					' Set the behavior to return visuals at all z-order levels.
					Return HitTestResultBehavior.Continue

				Case IntersectionDetail.FullyInside

					' Set the behavior to return visuals at all z-order levels.
					Return HitTestResultBehavior.Continue

				Case Else
					Return HitTestResultBehavior.Stop
			End Select
		End Function
		' </SnippetHitTestingOverviewSnippet11>

		Private Sub OnDummyEvent02(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' <SnippetHitTestingOverviewSnippet12>
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Expand the hit test area by creating a geometry centered on the hit test point.
			Dim expandedHitTestArea As New EllipseGeometry(pt, 10.0, 10.0)

			' Set up a callback to receive the hit test result enumeration.
			VisualTreeHelper.HitTest(myControl, Nothing, New HitTestResultCallback(AddressOf MyHitTestResultCallback), New GeometryHitTestParameters(expandedHitTestArea))
			' </SnippetHitTestingOverviewSnippet12>

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				ProcessHitTestResultsList()
			End If
		End Sub

		' Dummy class to hold snippet.
		Public Class MyDummyVisual03
			Inherits DrawingVisual
			' <SnippetHitTestingOverviewSnippet13>
			' Override default hit test support in visual object.
			Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As GeometryHitTestParameters) As GeometryHitTestResult
				Dim intersectionDetail As IntersectionDetail = IntersectionDetail.NotCalculated

				' Perform custom actions during the hit test processing.

				Return New GeometryHitTestResult(Me, intersectionDetail)
			End Function
			' </SnippetHitTestingOverviewSnippet13>
		End Class

		' Dummy class to hold snippet.
		Public Class MyDummyVisual04
			Inherits DrawingVisual
			' <SnippetHitTestingOverviewSnippet14>
			' Override default hit test support in visual object.
			Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As GeometryHitTestParameters) As GeometryHitTestResult
				' Perform actions based on hit test of bounding rectangle.

				' Return results of base class hit testing,
				' which only returns hit on the geometry of visual objects.
				Return MyBase.HitTestCore(hitTestParameters)
			End Function
			' </SnippetHitTestingOverviewSnippet14>
		End Class
	End Class
End Namespace
