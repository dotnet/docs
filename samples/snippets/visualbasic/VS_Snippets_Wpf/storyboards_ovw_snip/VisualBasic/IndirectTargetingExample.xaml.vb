Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Data
Imports System.Windows.Shapes


Namespace Microsoft.Samples.Animation


	Partial Public Class IndirectTargetingExample
		Inherits Page


		Public Sub New()
			InitializeComponent()
			BrushTargetingExample()
			CollectionTargetingExample()

		End Sub

		Private Sub BrushTargetingExample()
			' <Snippet137>

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Dim rectangle01 As New Rectangle()
			rectangle01.Name = "Rectangle01"
			Me.RegisterName(rectangle01.Name, rectangle01)
			rectangle01.Width = 100
			rectangle01.Height = 100
			rectangle01.Fill = CType(Me.Resources("MySolidColorBrushResource"), SolidColorBrush)

			Dim myColorAnimation As New ColorAnimation()
			myColorAnimation.From = Colors.Blue
			myColorAnimation.To = Colors.AliceBlue
			myColorAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
			Storyboard.SetTargetName(myColorAnimation, rectangle01.Name)

			' <Snippet134>
			' <Snippet135>
			' <SnippetPropertyChainAndPath>
			Dim propertyChain() As DependencyProperty = {Rectangle.FillProperty, SolidColorBrush.ColorProperty}
			' </Snippet135>
			' <Snippet136>
			Dim thePath As String = "(0).(1)"
			' </Snippet136>
			' </SnippetPropertyChainAndPath>
			Dim myPropertyPath As New PropertyPath(thePath, propertyChain)
			Storyboard.SetTargetProperty(myColorAnimation, myPropertyPath)
			' </Snippet134>

			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myColorAnimation)
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard
			Dim myMouseEnterTrigger As New EventTrigger()
			myMouseEnterTrigger.RoutedEvent = Rectangle.MouseEnterEvent
			myMouseEnterTrigger.Actions.Add(myBeginStoryboard)
			rectangle01.Triggers.Add(myMouseEnterTrigger)
			' </Snippet137>
			myStackPanel.Children.Add(rectangle01)

		End Sub

		Private Sub CollectionTargetingExample()
			' <Snippet138>
			Dim rectangle02 As New Rectangle()
			rectangle02.Name = "Rectangle02"
			Me.RegisterName(rectangle02.Name, rectangle02)
			rectangle02.Width = 100
			rectangle02.Height = 100
			rectangle02.Fill = Brushes.Blue
			rectangle02.RenderTransform = CType(Me.Resources("MyTransformGroupResource"), TransformGroup)

			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 0
			myDoubleAnimation.To = 360
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
			Storyboard.SetTargetName(myDoubleAnimation, rectangle02.Name)

			' <Snippet139>
			' <Snippet140>
			Dim propertyChain() As DependencyProperty = { Rectangle.RenderTransformProperty, TransformGroup.ChildrenProperty, RotateTransform.AngleProperty }
			' </Snippet140>
			' <Snippet141>
			Dim thePath As String = "(0).(1)[1].(2)"
			' </Snippet141>
			Dim myPropertyPath As New PropertyPath(thePath, propertyChain)
			Storyboard.SetTargetProperty(myDoubleAnimation, myPropertyPath)
			' </Snippet139>

			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard
			Dim myMouseEnterTrigger As New EventTrigger()
			myMouseEnterTrigger.RoutedEvent = Rectangle.MouseEnterEvent
			myMouseEnterTrigger.Actions.Add(myBeginStoryboard)
			rectangle02.Triggers.Add(myMouseEnterTrigger)
			' </Snippet138>
			myStackPanel.Children.Add(rectangle02)

		End Sub


	End Class


End Namespace
