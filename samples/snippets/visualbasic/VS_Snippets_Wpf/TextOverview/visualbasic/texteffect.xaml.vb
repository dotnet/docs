Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Imports System.Windows.Media.Animation

Namespace TextElementSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			'TextEffectsProp()
			'Stub1()
			Stub3()
		End Sub

		Private Sub TextEffectsProp()
			' <SnippetTextEffectSnippet1>
			' Create and configure a simple color animation sequence.  Timespan is in 1000ns ticks.
			Dim colorAnimation As New ColorAnimation(Colors.Maroon, Colors.White, New Duration(New TimeSpan(1000000)))
			colorAnimation.AutoReverse = True
			colorAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Create a new brush and apply the color animation.
			Dim solidColorBrush As New SolidColorBrush(Colors.Black)
			solidColorBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation)

			' Create a new TextEffect object. Set the foreground to the color-animated brush.
			Dim textEffect As New TextEffect()
			textEffect.Foreground = solidColorBrush

			' Apply the TextEffect to the entire range of characters.
			textEffect.PositionStart = 0
			textEffect.PositionCount = Integer.MaxValue

			' Create a new text Run, and add the TextEffect to the TextEffectCollection of the Run.
			Dim flickerRun As New Run("Text that flickers...")
			flickerRun.TextEffects = New TextEffectCollection()
			flickerRun.TextEffects.Add(textEffect)

			MyFlowDocument.Blocks.Add(New Paragraph(flickerRun))
			' </SnippetTextEffectSnippet1>
		End Sub

		Private Sub Stub1()
			Dim textEffect As New TextEffect()
			' <SnippetTextEffectSnippet2>
			' Ensure that all characters in the text are affected.
			textEffect.PositionCount = Integer.MaxValue
			' </SnippetTextEffectSnippet2>
		End Sub

		Private Sub Stub3()
			' Create and configure a simple color animation sequence.  Timespan is in 1000ns ticks.
			Dim colorAnimation As New ColorAnimation(Colors.Maroon, Colors.White, New Duration(New TimeSpan(1000000)))
			colorAnimation.AutoReverse = True
			colorAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Create a new brush and apply the color animation.
			Dim solidColorBrush As New SolidColorBrush(Colors.Black)
			solidColorBrush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation)

			' <SnippetTextEffectSnippet3>
			' Create a new TextEffect object, setting only the foreground brush, position start, and position count.
			Dim textEffect As New TextEffect(Nothing, solidColorBrush, Nothing, 0, Integer.MaxValue)
			' </SnippetTextEffectSnippet3>

			' Create a new text Run, and add the TextEffect to the TextEffectCollection of the Run.
			Dim flickerRun As New Run("Text that flickers...")
			flickerRun.TextEffects = New TextEffectCollection()
			flickerRun.TextEffects.Add(textEffect)

			MyFlowDocument.Blocks.Add(New Paragraph(flickerRun))
		End Sub
	End Class
End Namespace