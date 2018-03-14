' <SnippetControlTemplateStoryboardExampleWholePage>
'
'    This example shows how to animate
'    a FrameworkContentElement with a storyboard.
'
'


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Documents


Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
	Public Class ControlTemplateStoryboardExample
		Inherits Page

		Private myStoryboard As Storyboard

		Public Sub New()


			Dim myControlTemplate As New ControlTemplate(GetType(Button))
			Dim borderFactory As New FrameworkElementFactory(GetType(Border))
			Dim contentPresenterFactory As New FrameworkElementFactory(GetType(ContentPresenter))
			borderFactory.AppendChild(contentPresenterFactory)
			myControlTemplate.VisualTree = borderFactory

'           
'            borderFactory.SetValue(Border.BackgroundProperty,
'                TemplateBindingExpression(Button.BackgroundProperty))

			  ' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			  Me.WindowTitle = "Controlling a Storyboard"
			  Me.Background = Brushes.White

			  Dim myStackPanel As New StackPanel()
			  myStackPanel.Margin = New Thickness(20)

			  ' Create a rectangle.
			  Dim myRectangle As New Rectangle()
			  myRectangle.Width = 100
			  myRectangle.Height = 20
			  myRectangle.Margin = New Thickness(12,0,0,5)
			  myRectangle.Fill = New SolidColorBrush(Color.FromArgb(170, 51, 51, 255))
			  myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			  myStackPanel.Children.Add(myRectangle)

			  ' Assign the rectangle a name by 
			  ' registering it with the page, so that
			  ' it can be targeted by storyboard
			  ' animations.
			  Me.RegisterName("myRectangle", myRectangle)

			  '
			  ' Create an animation and a storyboard to animate the
			  ' rectangle.
			  '
			  Dim myDoubleAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(5)))
			  Storyboard.SetTargetName(myDoubleAnimation, "myRectangle")
			  Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			  myStoryboard = New Storyboard()
			  myStoryboard.Children.Add(myDoubleAnimation)

			'
			' Create a button to start the storyboard.
			'
			Dim beginButton As New Button()
			beginButton.Template = myControlTemplate
			beginButton.Content = "Begin"
			AddHandler beginButton.Click, AddressOf beginButton_Clicked

			myStackPanel.Children.Add(beginButton)
			Me.Content = myStackPanel

		End Sub

		' Begins the storyboard.
		Private Sub beginButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			myStoryboard.Begin(Me)
		End Sub



	End Class
End Namespace
' </SnippetControlTemplateStoryboardExampleWholePage>
