' <SnippetFrameworkContentElementStoryboardExampleUsingWholePage>
'
'    This example shows how to animate
'    a FrameworkContentElement with a storyboard.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Documents


Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
	Public Class FrameworkContentElementStoryboardExample
		Inherits FlowDocument

		Private myStoryboard As Storyboard

		Public Sub New()

			' Create a name scope for the document.
			NameScope.SetNameScope(Me, New NameScope())
			Me.Background = Brushes.White

			' Create a run of text.
			Dim theText As New Run("Lorem ipsum dolor sit amet, consectetuer adipiscing elit." & "Ut non lacus. Nullam a ligula id leo adipiscing ornare." & " Duis mattis. ")

			' Create a TextEffect
			Dim animatedSpecialEffect As New TextEffect()
			animatedSpecialEffect.Foreground = Brushes.OrangeRed
			animatedSpecialEffect.PositionStart = 0
			animatedSpecialEffect.PositionCount = 0

			' Assign the TextEffect a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations            
			Me.RegisterName("animatedSpecialEffect", animatedSpecialEffect)

			' Apply the text effect to the run.
			theText.TextEffects = New TextEffectCollection()
			theText.TextEffects.Add(animatedSpecialEffect)

			' Create a paragraph to contain the run.
			Dim animatedParagraph As New Paragraph(theText)
			animatedParagraph.Background = Brushes.LightGray
			animatedParagraph.Padding = New Thickness(20)

			Me.Blocks.Add(animatedParagraph)
			Dim controlsContainer As New BlockUIContainer()

			'
			' Create an animation and a storyboard to animate the
			' text effect.
			'
			Dim countAnimation As New Int32Animation(0, 127, TimeSpan.FromSeconds(10))
			Storyboard.SetTargetName(countAnimation, "animatedSpecialEffect")
			Storyboard.SetTargetProperty(countAnimation, New PropertyPath(TextEffect.PositionCountProperty))
			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(countAnimation)

			'
			' Create a button to start the storyboard.
			'
			Dim beginButton As New Button()
			beginButton.Content = "Begin"
			AddHandler beginButton.Click, AddressOf beginButton_Clicked

			controlsContainer.Child = beginButton
			Me.Blocks.Add(controlsContainer)

		End Sub

		' Begins the storyboard.
		Private Sub beginButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			myStoryboard.Begin(Me)
		End Sub



	End Class
End Namespace
' </SnippetFrameworkContentElementStoryboardExampleUsingWholePage>
