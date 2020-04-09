' <SnippetSeekStoryboardExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class SeekStoryboardExample
		Inherits Page

        Private ReadOnly myStoryboard As Storyboard

        Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()

            ' Create a rectangle.
            Dim myRectangle As New Rectangle With {
                .Width = 100,
                .Height = 20,
                .Margin = New Thickness(12, 0, 0, 5),
                .Fill = New SolidColorBrush(Color.FromArgb(170, 51, 51, 255)),
                .HorizontalAlignment = HorizontalAlignment.Left
            }
            myStackPanel.Children.Add(myRectangle)

			' Assign the rectangle a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations.
			RegisterName("myRectangle", myRectangle)

			'
			' Create an animation and a storyboard to animate the
			' rectangle.
			'
			Dim myDoubleAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(5)))
			Storyboard.SetTargetName(myDoubleAnimation, "myRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

            ' Create a buton to begin the Storyboard.
            Dim buttonPanel As New StackPanel With {
                .Orientation = Orientation.Horizontal
            }
            Dim beginButton As New Button With {
                .Content = "Begin"
            }
            AddHandler beginButton.Click, AddressOf beginButton_Clicked
			buttonPanel.Children.Add(beginButton)

            ' Create a button to seek to a specific time in the Storyboard.
            Dim seekStoryboardButton As New Button With {
                .Content = "Seek to One Second After Begin Time"
            }
            AddHandler seekStoryboardButton.Click, AddressOf seekStoryboardButton_Clicked
			buttonPanel.Children.Add(seekStoryboardButton)

			myStackPanel.Children.Add(buttonPanel)
			Content = myStackPanel
		End Sub

        ' Begins the storyboard.
        Private Sub beginButton_Clicked(sender As Object, args As RoutedEventArgs)
            ' Specifying "true" as the second Begin parameter
            ' makes this storyboard controllable.
            myStoryboard.Begin(Me, True)

        End Sub

        ' Seek (skip to) one second into the Storboard's active period (Duration). 
        Private Sub seekStoryboardButton_Clicked(sender As Object, args As RoutedEventArgs)
            ' Create time interval to seek to. This TimeSpan is set for one second.
            Dim myTimeSpan As New TimeSpan(0, 0, 1)

            ' Seek (skip to) to one second from the begin time of the Storyboard.
            myStoryboard.Seek(Me, myTimeSpan, TimeSeekOrigin.BeginTime)

        End Sub
    End Class
End Namespace
' </SnippetSeekStoryboardExampleWholePage>
