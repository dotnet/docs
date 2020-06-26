Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes
Namespace SDKSample
	Partial Public Class AutoLayoutContentExample
		Inherits Page
		Public Sub New()
			Dim stackPanel1 As StackPanel = ReturnStackPanel1()
			Dim stackPanel2 As StackPanel = ReturnStackPanel2()
			Dim myStackPanel As New StackPanel()
			myStackPanel.Children.Add(stackPanel1)
			myStackPanel.Children.Add(stackPanel2)

			Me.Content = myStackPanel
		End Sub

		Private Function ReturnStackPanel1() As StackPanel
			' <SnippetAutoLayoutContentNonParentedUIElementExample>
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20, 0, 0, 0)
			Dim myTextBlock As New TextBlock()
			myTextBlock.Margin = New Thickness(0, 10, 0, 0)
			myTextBlock.Text = "AutoLayoutContent: True"
			myStackPanel.Children.Add(myTextBlock)

			Dim myRectangle As New Rectangle()
			myRectangle.Width = 100
			myRectangle.Height = 100
			myRectangle.Stroke = Brushes.Black
			myRectangle.StrokeThickness = 1

			' Create the Fill for the rectangle using a VisualBrush.
			Dim myVisualBrush As New VisualBrush()
			myVisualBrush.AutoLayoutContent = True

			' This button is used as the visual for the VisualBrush.
			Dim myButton As New Button()
			myButton.Content = "Hello, World"

			myVisualBrush.Visual = myButton

			' Set the fill of the Rectangle to the Visual Brush.
			myRectangle.Fill = myVisualBrush

			myStackPanel.Children.Add(myRectangle)

			Dim myTextBlock2 As New TextBlock()
			myTextBlock2.Margin = New Thickness(0, 10, 0, 0)
			myTextBlock2.Text = "AutoLayoutContent: False"
			myStackPanel.Children.Add(myTextBlock2)

			Dim myRectangle2 As New Rectangle()
			myRectangle2.Width = 100
			myRectangle2.Height = 100
			myRectangle2.Stroke = Brushes.Black
			myRectangle2.StrokeThickness = 1

			' Create the Fill for the rectangle using a VisualBrush.
			Dim myVisualBrush2 As New VisualBrush()
			myVisualBrush2.AutoLayoutContent = False

			' This button is used as the visual for the VisualBrush.
			Dim myButton2 As New Button()
			myButton2.Content = "Hello, World"
			myButton2.Width = 100
			myButton2.Height = 100

			myVisualBrush2.Visual = myButton2

			' Set the fill of the Rectangle to the Visual Brush.
			myRectangle2.Fill = myVisualBrush2

			myStackPanel.Children.Add(myRectangle2)
			' </SnippetAutoLayoutContentNonParentedUIElementExample>
			Return myStackPanel
		End Function

		Private Function ReturnStackPanel2() As StackPanel

			' <SnippetAutoLayoutContentParentedUIElementExample>
			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20, 0, 0, 0)
			Dim myTextBlock As New TextBlock()
			myTextBlock.Margin = New Thickness(0, 10, 0, 0)
			myTextBlock.Text = "The UIElement"
			myStackPanel.Children.Add(myTextBlock)

			Dim myButton As New Button()
			myButton.Content = "Hello, World"
			myButton.Width = 70
			Me.RegisterName("MyButton", myButton)
			myStackPanel.Children.Add(myButton)

			Dim myTextBlock2 As New TextBlock()
			myTextBlock2.Margin = New Thickness(0, 10, 0, 0)
			myTextBlock2.Text = "AutoLayoutContent: True"
			myStackPanel.Children.Add(myTextBlock2)

			Dim myRectangle As New Rectangle()
			myRectangle.Width = 100
			myRectangle.Height = 100
			myRectangle.Stroke = Brushes.Black
			myRectangle.StrokeThickness = 1

			' Create the Fill for the rectangle using a VisualBrush.
			Dim myVisualBrush As New VisualBrush()
			myVisualBrush.AutoLayoutContent = True
			Dim buttonBinding As New Binding()
			buttonBinding.ElementName = "MyButton"
			BindingOperations.SetBinding(myVisualBrush, VisualBrush.VisualProperty, buttonBinding)

			' Set the fill of the Rectangle to the Visual Brush.
			myRectangle.Fill = myVisualBrush

			' Add the first rectangle.
			myStackPanel.Children.Add(myRectangle)

			Dim myTextBlock3 As New TextBlock()
			myTextBlock3.Margin = New Thickness(0, 10, 0, 0)
			myTextBlock3.Text = "AutoLayoutContent: False"
			myStackPanel.Children.Add(myTextBlock3)

			Dim myRectangle2 As New Rectangle()
			myRectangle2.Width = 100
			myRectangle2.Height = 100
			myRectangle2.Stroke = Brushes.Black
			myRectangle2.StrokeThickness = 1

			' Create the Fill for the rectangle using a VisualBrush.
			Dim myVisualBrush2 As New VisualBrush()
			myVisualBrush2.AutoLayoutContent = False
			Dim buttonBinding2 As New Binding()
			buttonBinding2.ElementName = "MyButton"
			BindingOperations.SetBinding(myVisualBrush2, VisualBrush.VisualProperty, buttonBinding2)

			' Set the fill of the Rectangle to the Visual Brush.
			myRectangle2.Fill = myVisualBrush2

			myStackPanel.Children.Add(myRectangle2)

			' </SnippetAutoLayoutContentParentedUIElementExample>
			Return myStackPanel
		End Function

	End Class
End Namespace