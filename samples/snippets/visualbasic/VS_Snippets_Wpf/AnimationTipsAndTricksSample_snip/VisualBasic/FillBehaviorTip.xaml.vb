Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Animation
	''' <summary>
	''' Interaction logic for FillBehaviorTip.xaml
	''' </summary>

	Partial Public Class FillBehaviorTip
		Inherits System.Windows.Controls.Page
		Public Sub New()
			InitializeComponent()

		End Sub

		' <SnippetFillBehaviorTipStoryboardC1CompletedHandler>
		Private Sub StoryboardC_Completed(ByVal sender As Object, ByVal e As EventArgs)

			Dim translationAnimationStoryboard As Storyboard = CType(Me.Resources("TranslationAnimationStoryboardResource"), Storyboard)
			translationAnimationStoryboard.Begin(Me)
		End Sub
		' </SnippetFillBehaviorTipStoryboardC1CompletedHandler>

	End Class
End Namespace