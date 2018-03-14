Imports System.Collections

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Private hitResultsList As New ArrayList()
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		' <Snippet100>
		' Respond to the left mouse button down event by initiating the hit test.
		Private Overloads Sub OnMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Perform the hit test against a given portion of the visual object tree.
			Dim result As HitTestResult = VisualTreeHelper.HitTest(myCanvas, pt)

			If result IsNot Nothing Then
				' Perform action on hit visual object.
			End If
		End Sub
		' </Snippet100>

		' <Snippet101>
		' Respond to the right mouse button down event by setting up a hit test results callback.
		Private Overloads Sub OnMouseRightButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Clear the contents of the list used for hit test results.
			hitResultsList.Clear()

			' Set up a callback to receive the hit test result enumeration.
			VisualTreeHelper.HitTest(myCanvas, Nothing, New HitTestResultCallback(AddressOf MyHitTestResult), New PointHitTestParameters(pt))

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				Console.WriteLine("Number of Visuals Hit: " & hitResultsList.Count)
			End If
		End Sub
		' </Snippet101>

		' <Snippet102>
		' Return the result of the hit test to the callback.
		Public Function MyHitTestResult(ByVal result As HitTestResult) As HitTestResultBehavior
			' Add the hit test result to the list that will be processed after the enumeration.
			hitResultsList.Add(result.VisualHit)

			' Set the behavior to return visuals at all z-order levels.
			Return HitTestResultBehavior.Continue
		End Function
		' </Snippet102>

		' Dummy routine to hold snippet.
		Public Function MyDummyHitTestResult(ByVal result As HitTestResult) As HitTestResultBehavior
			' <Snippet103>
			' Set the behavior to stop enumerating visuals.
			Return HitTestResultBehavior.Stop
			' </Snippet103>
		End Function

		' <Snippet104>
		' Respond to the mouse wheel event by setting up a hit test filter and results enumeration.
		Private Overloads Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Clear the contents of the list used for hit test results.
			hitResultsList.Clear()

			' Set up a callback to receive the hit test result enumeration.
			VisualTreeHelper.HitTest(myCanvas, New HitTestFilterCallback(AddressOf MyHitTestFilter), New HitTestResultCallback(AddressOf MyHitTestResult), New PointHitTestParameters(pt))

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				ProcessHitTestResultsList()
			End If
		End Sub
		' </Snippet104>

		' Dummy routine to hold snippet.
		Private Sub OnDummyEvent01(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' Retrieve the coordinate of the mouse position.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Clear the contents of the list used for hit test results.
			hitResultsList.Clear()

			' <Snippet105>
			' Set up a callback to receive the hit test result enumeration,
			' but no hit test filter enumeration.
			VisualTreeHelper.HitTest(myCanvas, Nothing, New HitTestResultCallback(AddressOf MyHitTestResult), New PointHitTestParameters(pt)) ' No hit test filtering.
			' </Snippet105>

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				ProcessHitTestResultsList()
			End If
		End Sub

		' <Snippet106>
		' Filter the hit test values for each object in the enumeration.
		Public Function MyHitTestFilter(ByVal o As DependencyObject) As HitTestFilterBehavior
			' Test for the object value you want to filter.
			If o.GetType() Is GetType(Label) Then
				' Visual object and descendants are NOT part of hit test results enumeration.
				Return HitTestFilterBehavior.ContinueSkipSelfAndChildren
			Else
				' Visual object is part of hit test results enumeration.
				Return HitTestFilterBehavior.Continue
			End If
		End Function
		' </Snippet106>


		Public Sub ProcessHitTestResultsList()
		End Sub
	End Class

	' Dummy class to hold snippet.
	Public Class MyDummyVisual
		Inherits DrawingVisual
		'<Snippet107>
		' Override default hit test support in visual object.
		Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As PointHitTestParameters) As HitTestResult
			Dim pt As Point = hitTestParameters.HitPoint

			' Perform custom actions during the hit test processing,
			' which may include verifying that the point actually
			' falls within the rendered content of the visual.

			' Return hit on bounding rectangle of visual object.
			Return New PointHitTestResult(Me, pt)
		End Function
		'</Snippet107>
	End Class

	' Dummy class to hold snippet.
	Public Class MyDummyVisual2
		Inherits DrawingVisual
		'<Snippet108>
		' Override default hit test support in visual object.
		Protected Overrides Overloads Function HitTestCore(ByVal hitTestParameters As PointHitTestParameters) As HitTestResult
			' Perform actions based on hit test of bounding rectangle.
			' ...

			' Return results of base class hit testing,
			' which only returns hit on the geometry of visual objects.
			Return MyBase.HitTestCore(hitTestParameters)
		End Function
		'</Snippet108>
	End Class
End Namespace