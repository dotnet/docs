' <SnippetFrameworkContentElementStoryboardWithHandoffBehaviorExampleWholePage>
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
Imports System.Windows.Input


Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
	Public Class FrameworkContentElementStoryboardWithHandoffBehaviorExample
		Inherits FlowDocument

		Private myStoryboard As Storyboard
		Private xAnimation As DoubleAnimation
		Private yAnimation As DoubleAnimation

		Public Sub New()

			' Create a name scope for the document.
			NameScope.SetNameScope(Me, New NameScope())
			Me.Background = Brushes.Orange

			' Create a run of text.
			Dim theText As New Run("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.")

			' Create a TextEffect
			Dim animatedSpecialEffect As New TextEffect()
			animatedSpecialEffect.Foreground = Brushes.OrangeRed
			animatedSpecialEffect.PositionStart = 0
			animatedSpecialEffect.PositionCount = 20

			Dim animatedTransform As New TranslateTransform()

			' Assign the transform a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations.      
			Me.RegisterName("animatedTransform", animatedTransform)
			animatedSpecialEffect.Transform = animatedTransform


			' Apply the text effect to the run.
			theText.TextEffects = New TextEffectCollection()
			theText.TextEffects.Add(animatedSpecialEffect)


			' Create a paragraph to contain the run.
			Dim animatedParagraph As New Paragraph(theText)
			animatedParagraph.Background = Brushes.LightGray

			Me.Blocks.Add(animatedParagraph)

			'
			' Create a storyboard to animate the
			' text effect's transform.
			'
			myStoryboard = New Storyboard()

			xAnimation = New DoubleAnimation()
			xAnimation.Duration = TimeSpan.FromSeconds(5)
			Storyboard.SetTargetName(xAnimation, "animatedTransform")
			Storyboard.SetTargetProperty(xAnimation, New PropertyPath(TranslateTransform.XProperty))
			myStoryboard.Children.Add(xAnimation)

			yAnimation = New DoubleAnimation()
			yAnimation.Duration = TimeSpan.FromSeconds(5)
			Storyboard.SetTargetName(yAnimation, "animatedTransform")
			Storyboard.SetTargetProperty(yAnimation, New PropertyPath(TranslateTransform.YProperty))
			myStoryboard.Children.Add(yAnimation)

			AddHandler MouseLeftButtonDown, AddressOf document_mouseLeftButtonDown
			AddHandler MouseRightButtonDown, AddressOf document_mouseRightButtonDown

		End Sub



		' When the user left-clicks, use the 
		' SnapshotAndReplace HandoffBehavior when applying the animation.        
		Private Sub document_mouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

			Dim clickPoint As Point = Mouse.GetPosition(Me)


			' Animate to the target point.
			xAnimation.To = clickPoint.X
			yAnimation.To = clickPoint.Y

			Try
				myStoryboard.Begin(Me, HandoffBehavior.SnapshotAndReplace)

			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		' When the user right-clicks, use the 
		' Compose HandoffBehavior when applying the animation.
		Private Sub document_mouseRightButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)


			Dim clickPoint As Point = Mouse.GetPosition(Me)

			' Animate to the target point.
			xAnimation.To = clickPoint.X
			yAnimation.To = clickPoint.Y
			myStoryboard.Begin(Me, HandoffBehavior.Compose)


		End Sub





	End Class
End Namespace
' </SnippetFrameworkContentElementStoryboardWithHandoffBehaviorExampleWholePage>


