' <SnippetMultipleTransformsCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class MultipleTransformsExample
		Inherits Page
		Public Sub New()
			' Create a Button that will have two transforms applied to it.
			Dim myButton As New Button()
			myButton.Content = "Click"

			' Set the center point of the transforms.
			myButton.RenderTransformOrigin = New Point(0.5,0.5)

			' Create a transform to scale the size of the button.
			Dim myScaleTransform As New ScaleTransform()

			' Set the transform to triple the scale in the Y direction.
			myScaleTransform.ScaleY = 3

			' Create a transform to rotate the button
			Dim myRotateTransform As New RotateTransform()

			' Set the rotation of the transform to 45 degrees.
			myRotateTransform.Angle = 45

			' Create a TransformGroup to contain the transforms
			' and add the transforms to it.
			Dim myTransformGroup As New TransformGroup()
			myTransformGroup.Children.Add(myScaleTransform)
			myTransformGroup.Children.Add(myRotateTransform)

			' Associate the transforms to the button.
			myButton.RenderTransform = myTransformGroup

			' Create a StackPanel which will contain the Button.
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(50)
			myStackPanel.Children.Add(myButton)
			Me.Content = myStackPanel

		End Sub
	End Class
End Namespace
' </SnippetMultipleTransformsCodeExampleWholePage>