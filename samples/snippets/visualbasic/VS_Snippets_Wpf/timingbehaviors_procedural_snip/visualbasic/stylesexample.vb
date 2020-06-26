'
'  StylesExample.vb
'     This example shows how to create storyboards in a style.
'

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors
    Partial Public Class StylesExample
        Inherits Page



        Public Sub New()

            ' Create a name scope for the page.
            NameScope.SetNameScope(Me, New NameScope())

            Me.WindowTitle = "Storyboard in Styles Example"
            Me.Background = Brushes.White

            '
            ' Define a Button style 
            '
            Dim myStyle As New Style()
            Dim mySetter As New Setter()
            ' mySetter.Property = 

            Dim myEventTrigger As New EventTrigger()
            myEventTrigger.RoutedEvent = Button.MouseEnterEvent
            Dim myBeginStoryboard As New BeginStoryboard()
            Dim myStoryboard As New Storyboard()
            myBeginStoryboard.Storyboard = myStoryboard


            Dim myDoubleAnimation As New DoubleAnimation()
            Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Button.OpacityProperty))
            myDoubleAnimation.From = 1.0
            myDoubleAnimation.To = 0.5
            myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(500))
            myDoubleAnimation.AutoReverse = True
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever
            myStoryboard.Children.Add(myDoubleAnimation)
            myEventTrigger.Actions.Add(myBeginStoryboard)

            '
            '  Returns the button's opacity to 1 when the mouse leaves. 
            '
            myEventTrigger = New EventTrigger()
            myEventTrigger.RoutedEvent = Button.MouseLeaveEvent
            myBeginStoryboard = New BeginStoryboard()
            myStoryboard = New Storyboard()
            myBeginStoryboard.Storyboard = myStoryboard
            myDoubleAnimation = New DoubleAnimation()
            Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Button.OpacityProperty))
            myDoubleAnimation.From = 1.0
            myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(100))
            myStoryboard.Children.Add(myDoubleAnimation)
            myEventTrigger.Actions.Add(myBeginStoryboard)

            '
            '  Changes the button's color when clicked. Notice that the animation can't target the SolidColorBrush used 
            '     to paint the button's background directly. The brush must be accessed through the button's Background property.
            '
            myEventTrigger = New EventTrigger()
            myEventTrigger.RoutedEvent = Button.ClickEvent
            myBeginStoryboard = New BeginStoryboard()
            myStoryboard = New Storyboard()
            myBeginStoryboard.Storyboard = myStoryboard
            Dim myColorAnimation As New ColorAnimation()
            'Storyboard.SetTargetProperty(myColorAnimation, new PropertyPath("(0).(1)",new DependencyProperty[] { (Button.Background).(SolidColorBrush.Color)   }))
            myColorAnimation.From = Color.FromArgb(255, 255, 165, 0)
            myColorAnimation.To = Color.FromArgb(255, 255, 255, 255)
            myColorAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(100))
            myColorAnimation.AutoReverse = True
            myStoryboard.Children.Add(myColorAnimation)
            myEventTrigger.Actions.Add(myBeginStoryboard)
        End Sub
    End Class
End Namespace