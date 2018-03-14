Imports System
Imports System.Windows
Imports System.Collections
Imports System.Windows.Media

Namespace SDKSample
	Public Class MyShape
		Inherits ContainerVisual
		Public Shared numberCircles As Integer = 5
		Public Shared radius As Double = 50.0R
		Public Shared myRandom As New Random()
		Public Shared hitResultsList As New ArrayList()

		Friend Sub New()
			' Create a random x:y coordinate for the shape.
			Dim left As Integer = myRandom.Next(0, MyWindow._width)
			Dim top As Integer = myRandom.Next(0, MyWindow._height)

			Dim currRadius As Double = radius
			If radius = 0.0R Then
				currRadius = CDbl(myRandom.Next(30, 100))
			End If

			' Draw five concentric circles for the shape.
			Dim r As Double = currRadius
			For i As Integer = 0 To numberCircles - 1
				Dim TempMyCircle As MyCircle = New MyCircle(Me, New System.Windows.Point(left, top), r)
				r = currRadius * (1.0R - ((CDbl(i) + 1.0R) / CDbl(numberCircles)))
			Next i
		End Sub

		'<Snippet104>
		' Constant values from the "winuser.h" header file.
		Public Const WM_LBUTTONUP As Integer = &H0202, WM_RBUTTONUP As Integer = &H0205

		' Respond to WM_LBUTTONUP or WM_RBUTTONUP messages by determining which visual object was clicked.
		Public Shared Sub OnHitTest(ByVal pt As System.Windows.Point, ByVal msg As Integer)
			' Clear the contents of the list used for hit test results.
			hitResultsList.Clear()

			' Determine whether to change the color of the circle or to delete the shape.
			If msg = WM_LBUTTONUP Then
				MyWindow.changeColor = True
			End If
			If msg = WM_RBUTTONUP Then
				MyWindow.changeColor = False
			End If

			' Set up a callback to receive the hit test results enumeration.
			VisualTreeHelper.HitTest(MyWindow.myHwndSource.RootVisual, Nothing, New HitTestResultCallback(AddressOf CircleHitTestResult), New PointHitTestParameters(pt))

			' Perform actions on the hit test results list.
			If hitResultsList.Count > 0 Then
				ProcessHitTestResultsList()
			End If
		End Sub
		'</Snippet104>

		' Handle the hit test results enumeration in the callback.
		Friend Shared Function CircleHitTestResult(ByVal result As HitTestResult) As HitTestResultBehavior
			' Add the hit test result to the list that will be processed after the enumeration.
			hitResultsList.Add(result.VisualHit)

			' Determine whether hit test should return only the top-most layer visual.
			If MyWindow.topmostLayer = True Then
				' Set the behavior to stop the enumeration of visuals.
				Return HitTestResultBehavior.Stop
			Else
				' Set the behavior to continue the enumeration of visuals.
				' All visuals that intersect at the hit test coordinates are returned,
				' whether visible or not.
				Return HitTestResultBehavior.Continue
			End If
		End Function

		' Process the results of the hit test after the enumeration in the callback.
		' Do not add or remove objects from the visual tree until after the enumeration.
		Friend Shared Sub ProcessHitTestResultsList()
			For Each circle As MyCircle In hitResultsList
				' Determine whether to change the color of the ring or to delete the circle.
				If MyWindow.changeColor = True Then
					' Draw a different color ring for the circle.
					circle.Render()
				Else
					If circle.Parent Is MyWindow.myHwndSource.RootVisual Then
						' Remove the root visual by disposing of the host hwnd.
						MyWindow.myHwndSource.Dispose()
						MyWindow.myHwndSource = Nothing
						Return
					Else
						' Remove the shape that is the parent of the child circle.
						CType(MyWindow.myHwndSource.RootVisual, ContainerVisual).Children.Remove(CType(circle.Parent, Visual))
					End If
				End If
			Next circle
		End Sub

		Friend Class MyCircle
			Inherits DrawingVisual
			Public _pt As System.Windows.Point
			Public _radius As Double

			Friend Sub New(ByVal parent As MyShape, ByVal pt As System.Windows.Point, ByVal radius As Double)
				_pt = pt
				_radius = radius
				Me.Render()

				' Add the circle as a child to the shape parent.
				parent.Children.Add(Me)
			End Sub

			Friend Sub Render()
				' Draw a circle.
				Dim dc As DrawingContext = Me.RenderOpen()
				dc.DrawEllipse(New SolidColorBrush(MyColor.GenRandomColor()), Nothing, _pt, _radius, _radius)
				dc.Close()
			End Sub
		End Class

		Private Class MyColor
			Public Shared myRandom As New Random()

			Public Shared Function GenRandomColor() As System.Windows.Media.Color
				' Generate a random color value.
				Return System.Windows.Media.Color.FromRgb(CByte(myRandom.Next(0, 255)), CByte(myRandom.Next(0, 255)), CByte(myRandom.Next(0, 255)))
			End Function
		End Class
	End Class
End Namespace