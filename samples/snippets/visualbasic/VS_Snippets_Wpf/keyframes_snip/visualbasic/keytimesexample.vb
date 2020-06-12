' <SnippetKeyTimesExampleUsingWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	Friend Class KeyTimesExample
		Inherits Page

		Private mainPanel As StackPanel

		Public Sub New()

			' Create the mainPanel.
			mainPanel = New StackPanel()
			mainPanel.Margin = New Thickness(20)
			mainPanel.HorizontalAlignment = HorizontalAlignment.Left

			' Create the examples.
			createKeyTimeTimeSpanExample()
			createKeyTimePercentageExample()
			createKeyTimeUniformExample()
			createKeyTimePacedExample()

			Me.Content = mainPanel


		End Sub

		Private Sub createKeyTimeTimeSpanExample()
			' <SnippetKeyTimesTimeSpanExample>
'            
'               This Rectangle is animated with KeyTimes using TimeSpan Values. 
'               It moves horizontally to 100 in the first 3 seconds, 100 to 300 in 
'               the next second, and 300 to 500 in the last 6 seconds.
'            

			' Create the a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Fill = Brushes.Blue
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 5
			aRectangle.Width = 50
			aRectangle.Height = 50

			' Create a transform to move the rectangle
			' across the screen.
			Dim translateTransform1 As New TranslateTransform()
			aRectangle.RenderTransform = translateTransform1

			' Create a DoubleAnimationUsingKeyFrames
			' to animate the transform.
			Dim transformAnimation As New DoubleAnimationUsingKeyFrames()
			transformAnimation.Duration = TimeSpan.FromSeconds(10)

			' Animate to 100 at 3 seconds.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(100, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))))

			' Animate to 300 at 4 seconds.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(300, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4))))

			' Animate to 500 at 10 seconds.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(500, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(10))))

			' Start the animation when the rectangle is loaded.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) translateTransform1.BeginAnimation(TranslateTransform.XProperty, transformAnimation)

			' </SnippetKeyTimesTimeSpanExample>

			mainPanel.Children.Add(aRectangle)

		End Sub

		Private Sub createKeyTimePercentageExample()
			' <SnippetKeyTimesPercentageExample>
'            
'              This rectangle moves horizontally to 100 in the first 3 seconds, 
'              100 to 300 in  the next second, and 300 to 500 in the last 6 seconds.
'            

			' Create the a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Fill = Brushes.Purple
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 5
			aRectangle.Width = 50
			aRectangle.Height = 50

			' Create a transform to move the rectangle
			' across the screen.
			Dim translateTransform2 As New TranslateTransform()
			aRectangle.RenderTransform = translateTransform2

			' Create a DoubleAnimationUsingKeyFrames
			' to animate the transform.
			Dim transformAnimation As New DoubleAnimationUsingKeyFrames()
			transformAnimation.Duration = TimeSpan.FromSeconds(10)

			' Animate to 100 at 30% of the animation's duration.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(100, KeyTime.FromPercent(0.3)))

			' Animate to 300 at 40% of the animation's duration.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(300, KeyTime.FromPercent(0.4)))

			' Animate to 500 at 100% of the animation's duration.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(500, KeyTime.FromPercent(1.0)))

			' Start the animation when the rectangle is loaded.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) translateTransform2.BeginAnimation(TranslateTransform.XProperty, transformAnimation)
			' </SnippetKeyTimesPercentageExample>

			mainPanel.Children.Add(aRectangle)

		End Sub

		Private Sub createKeyTimeUniformExample()
			' <SnippetKeyTimesUniformExample>
'            
'               This rectangle is animated with KeyTimes using Uniform values. 
'               Goes to 100 in the first 3.3 seconds, 100 to
'               300 in the next 3.3 seconds, 300 to 500 in the last 3.3 seconds.
'            

			' Create the a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Fill = Brushes.Red
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 5
			aRectangle.Width = 50
			aRectangle.Height = 50

			' Create a transform to move the rectangle
			' across the screen.
			Dim translateTransform3 As New TranslateTransform()
			aRectangle.RenderTransform = translateTransform3

			' Create a DoubleAnimationUsingKeyFrames
			' to animate the transform.
			Dim transformAnimation As New DoubleAnimationUsingKeyFrames()
			transformAnimation.Duration = TimeSpan.FromSeconds(10)

'            
'               KeyTime properties are expressed with values of Uniform. When a key time is set to
'               "Uniform" the total allotted time of the animation is divided evenly between key frames.  
'               In this example, the total duration of the animation is ten seconds and there are four 
'               key frames each of which are set to "Uniform", therefore, the duration of each key frame 
'               is 3.3 seconds (10/3).
'             

			' Animate to 100.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(100, KeyTime.Uniform))

			' Animate to 300.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(300, KeyTime.Uniform))

			' Animate to 500.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(500, KeyTime.Uniform))

			' Start the animation when the rectangle is loaded.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) translateTransform3.BeginAnimation(TranslateTransform.XProperty, transformAnimation)

			' </SnippetKeyTimesUniformExample>

			mainPanel.Children.Add(aRectangle)

		End Sub

		Private Sub createKeyTimePacedExample()

			' <SnippetKeyTimesPacedExample>
'            
'               This rectangle is animated with KeyTimes using Paced Values. 
'               The rectangle moves between key frames at uniform rate except for first key frame
'               because using a Paced value on the first KeyFrame in a collection of frames gives a time of zero.
'            

			' Create the a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Fill = Brushes.Orange
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 5
			aRectangle.Width = 50
			aRectangle.Height = 50

			' Create a transform to move the rectangle
			' across the screen.
			Dim translateTransform4 As New TranslateTransform()
			aRectangle.RenderTransform = translateTransform4

			' Create a DoubleAnimationUsingKeyFrames
			' to animate the transform.
			Dim transformAnimation As New DoubleAnimationUsingKeyFrames()
			transformAnimation.Duration = TimeSpan.FromSeconds(10)

'            
'               Use Paced values when a constant rate is desired. 
'               The time allocated to a key frame with a KeyTime of "Paced" is
'               determined by the time allocated to the other key frames of the animation. This time is 
'               calculated to attempt to give a "paced" or "constant velocity" for the animation.
'             

			' Animate to 100.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(100, KeyTime.Paced))

			' Animate to 300.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(300, KeyTime.Paced))

			' Animate to 500.
			transformAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(500, KeyTime.Paced))

			' Start the animation when the rectangle is loaded.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) translateTransform4.BeginAnimation(TranslateTransform.XProperty, transformAnimation)

			' </SnippetKeyTimesPacedExample>

			mainPanel.Children.Add(aRectangle)

		End Sub


	End Class
End Namespace
' </SnippetKeyTimesExampleUsingWholePage>


