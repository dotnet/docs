Imports System
Imports System.Windows
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim translate As New TranslateTransform(0, 0)
			myDrawing.RenderTransform = translate
		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			Stub01()
			Stub02()
			Stub03()
			Stub04()
			Stub05()
			Stub06()
			Stub07()
			Stub08()
			Snippets.SnippetGetRenderTier()
		End Sub

		Private Sub Stub01()
			'<SnippetVisualSnippet2>
			' Return the offset vector for the TextBlock object.
			Dim vector As Vector = VisualTreeHelper.GetOffset(myTextBlock)

			' Convert the vector to a point value.
			Dim currentPoint As New Point(vector.X, vector.Y)
			'</SnippetVisualSnippet2>
		End Sub

		Private Sub Stub02()
			'<SnippetVisualSnippet3>
			' Return the general transform for the specified visual object.
			Dim generalTransform1 As GeneralTransform = myTextBlock.TransformToAncestor(CType(myTextBlock.Parent, Visual))

			' Retrieve the point value relative to the parent.
			Dim currentPoint As Point = generalTransform1.Transform(New Point(0, 0))
			'</SnippetVisualSnippet3>
		End Sub

		Private Sub Stub03()
			'<SnippetVisualSnippet5>
			' Return the general transform for the specified visual object.
			Dim generalTransform1 As GeneralTransform = myTextBlock.TransformToAncestor(Me)

			' Retrieve the point value relative to the parent.
			Dim currentPoint As Point = generalTransform1.Transform(New Point(0, 0))
			'</SnippetVisualSnippet5>
		End Sub

		Private Sub Stub04()
			'<SnippetVisualSnippet6>
			' Return the transform for the specified visual object.
			Dim transform As Transform = VisualTreeHelper.GetTransform(myDrawing)

			' If there is no transform defined for the object, the return value is null.
			If transform IsNot Nothing Then
				' Return the offset of the returned transform. The offset is relative to the parent of the visual object.
				Dim pt As Point = transform.Transform(New Point(0, 0))
			End If
			'</SnippetVisualSnippet6>
		End Sub

		Private Sub Stub05()
			Dim translate As TranslateTransform = CType(myDrawing.RenderTransform, TranslateTransform)
			translate.X += 10
			translate.Y += 10
		End Sub

		Private Sub Stub06()
			'<SnippetVisualSnippet8>
			' Return the general transform for the specified visual object.
			Dim generalTransform1 As GeneralTransform = myStackPanel.TransformToVisual(myTextBlock)

			' Retrieve the point value relative to the child.
			Dim currentPoint As Point = generalTransform1.Transform(New Point(0, 0))
			'</SnippetVisualSnippet8>
		End Sub

		Private Sub Stub07()
			'<SnippetVisualSnippet9>
			' Return the general transform for the specified visual object.
			Dim generalTransform1 As GeneralTransform = myStackPanel.TransformToDescendant(myTextBlock)

			' Retrieve the point value relative to the child.
			Dim currentPoint As Point = generalTransform1.Transform(New Point(0, 0))
			'</SnippetVisualSnippet9>
		End Sub

		Private Sub Stub08()
			Dim myVisual As New MyVisual()
			myStackPanel.Children.Add(myVisual)
		End Sub
	End Class

	'<SnippetVisualSnippet10>
	Public Class MyVisual
		Inherits UIElement
		' Class member definitions
		' ...

		Protected Overrides Sub OnVisualParentChanged(ByVal oldParent As DependencyObject)
			' Perform actions based on OnVisualParentChanged event.
			' ...

			' Call base class to perform standard event handling.
			MyBase.OnVisualParentChanged(oldParent)
		End Sub
	End Class
	'</SnippetVisualSnippet10>
End Namespace