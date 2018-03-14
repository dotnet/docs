' <SnippetGraphicsMMVisualBrushReflectionExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes
Namespace SDKSample
	Partial Public Class ReflectionExample
		Inherits Page
		Public Sub New()
			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Me.Background = Brushes.Black
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(50)

			Dim myReflectedBorder As New Border()
			Me.RegisterName("ReflectedVisual", myReflectedBorder)

			' Create a gradient background for the border.
			Dim firstStop As New GradientStop()
			firstStop.Offset = 0.0
			Dim firstStopColor As New Color()
			firstStopColor.R = 204
			firstStopColor.G = 204
			firstStopColor.B = 255
			firstStopColor.A = 255
			firstStop.Color = firstStopColor
			Dim secondStop As New GradientStop()
			secondStop.Offset = 1.0
			secondStop.Color = Colors.White

			Dim myGradientStopCollection As New GradientStopCollection()
			myGradientStopCollection.Add(firstStop)
			myGradientStopCollection.Add(secondStop)

			Dim myLinearGradientBrush As New LinearGradientBrush()
			myLinearGradientBrush.StartPoint = New Point(0, 0.5)
			myLinearGradientBrush.EndPoint = New Point(1, 0.5)
			myLinearGradientBrush.GradientStops = myGradientStopCollection

			myReflectedBorder.Background = myLinearGradientBrush

			' Add contents to the border.
			Dim borderStackPanel As New StackPanel()
			borderStackPanel.Orientation = Orientation.Horizontal
			borderStackPanel.Margin = New Thickness(10)

			Dim myTextBlock As New TextBlock()
			myTextBlock.TextWrapping = TextWrapping.Wrap
			myTextBlock.Width = 200
			myTextBlock.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit." & " Suspendisse vel ante. Donec luctus tortor sit amet est." & " Nullam pulvinar odio et wisi." & " Pellentesque quis magna. Sed pellentesque." & " Nulla euismod." & "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas."

			borderStackPanel.Children.Add(myTextBlock)

			Dim ellipseStackPanel As New StackPanel()

			Dim ellipse1 As New Ellipse()
			ellipse1.Margin = New Thickness(10)
			ellipse1.Height = 50
			ellipse1.Width = 50
			ellipse1.Fill = Brushes.Black
			ellipseStackPanel.Children.Add(ellipse1)
			Dim ellipse2 As New Ellipse()
			ellipse2.Margin = New Thickness(10)
			ellipse2.Height = 50
			ellipse2.Width = 50
			ellipse2.Fill = Brushes.Black
			ellipseStackPanel.Children.Add(ellipse2)
			Dim ellipse3 As New Ellipse()
			ellipse3.Margin = New Thickness(10)
			ellipse3.Height = 50
			ellipse3.Width = 50
			ellipse3.Fill = Brushes.Black
			ellipseStackPanel.Children.Add(ellipse3)
			borderStackPanel.Children.Add(ellipseStackPanel)

			myReflectedBorder.Child = borderStackPanel

			' Create divider rectangle
			Dim dividerRectangle As New Rectangle()
			dividerRectangle.Height = 1
			dividerRectangle.Fill = Brushes.Gray
			dividerRectangle.HorizontalAlignment = HorizontalAlignment.Stretch

			' Create the object to contain the reflection.
			Dim reflectionRectangle As New Rectangle()

			' Bind the height of the rectangle to the border height.
			Dim heightBinding As New Binding()
			heightBinding.ElementName = "ReflectedVisual"
			heightBinding.Path = New PropertyPath(Rectangle.HeightProperty)
			BindingOperations.SetBinding(reflectionRectangle, Rectangle.HeightProperty, heightBinding)

			' Bind the width of the rectangle to the border width.
			Dim widthBinding As New Binding()
			widthBinding.ElementName = "ReflectedVisual"
			widthBinding.Path = New PropertyPath(Rectangle.WidthProperty)
			BindingOperations.SetBinding(reflectionRectangle, Rectangle.WidthProperty, widthBinding)

			' Creates the reflection.
			Dim myVisualBrush As New VisualBrush()
			myVisualBrush.Opacity = 0.75
			myVisualBrush.Stretch = Stretch.None
			Dim reflectionBinding As New Binding()
			reflectionBinding.ElementName = "ReflectedVisual"
			BindingOperations.SetBinding(myVisualBrush, VisualBrush.VisualProperty, reflectionBinding)

			Dim myScaleTransform As New ScaleTransform()
			myScaleTransform.ScaleX = 1
			myScaleTransform.ScaleY = -1
			Dim myTranslateTransform As New TranslateTransform()
			myTranslateTransform.Y = 1

			Dim myTransformGroup As New TransformGroup()
			myTransformGroup.Children.Add(myScaleTransform)
			myTransformGroup.Children.Add(myTranslateTransform)

			myVisualBrush.RelativeTransform = myTransformGroup

			reflectionRectangle.Fill = myVisualBrush

			' Create a gradient background for the border.
			Dim firstStop2 As New GradientStop()
			firstStop2.Offset = 0.0
			Dim c1 As New Color()
			c1.R = 0
			c1.G = 0
			c1.B = 0
			c1.A = 255
			firstStop2.Color = c1
			Dim secondStop2 As New GradientStop()
			secondStop2.Offset = 0.5
			Dim c2 As New Color()
			c2.R = 0
			c2.G = 0
			c2.B = 0
			c2.A = 51
			firstStop2.Color = c2
			Dim thirdStop As New GradientStop()
			thirdStop.Offset = 0.75
			Dim c3 As New Color()
			c3.R = 0
			c3.G = 0
			c3.B = 0
			c3.A = 0
			thirdStop.Color = c3

			Dim myGradientStopCollection2 As New GradientStopCollection()
			myGradientStopCollection2.Add(firstStop2)
			myGradientStopCollection2.Add(secondStop2)
			myGradientStopCollection2.Add(thirdStop)

			Dim myLinearGradientBrush2 As New LinearGradientBrush()
			myLinearGradientBrush2.StartPoint = New Point(0.5, 0)
			myLinearGradientBrush2.EndPoint = New Point(0.5, 1)
			myLinearGradientBrush2.GradientStops = myGradientStopCollection2

			reflectionRectangle.OpacityMask = myLinearGradientBrush2

			Dim myBlurBitmapEffect As New BlurBitmapEffect()
			myBlurBitmapEffect.Radius = 1.5

			reflectionRectangle.BitmapEffect = myBlurBitmapEffect

			myStackPanel.Children.Add(myReflectedBorder)
			myStackPanel.Children.Add(dividerRectangle)
			myStackPanel.Children.Add(reflectionRectangle)
			Me.Content = myStackPanel

		End Sub
    End Class
End Namespace
' </SnippetGraphicsMMVisualBrushReflectionExampleWholePage>