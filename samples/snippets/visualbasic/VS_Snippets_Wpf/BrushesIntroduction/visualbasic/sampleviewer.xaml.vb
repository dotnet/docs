Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media.Animation
Imports System.Reflection
Imports System.Xml

Namespace BrushesIntroduction
	''' <summary>
	''' Interaction logic for SampleViewer.xaml
	''' </summary>

	Partial Public Class SampleViewer
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub transitionAnimationStateChanged(ByVal sender As Object, ByVal args As EventArgs)
			Dim transitionAnimationClock As AnimationClock = CType(sender, AnimationClock)


			If transitionAnimationClock.CurrentState = ClockState.Filling Then
				fadeEnded()
			End If
		End Sub


		' <SnippetBeginAnimationHandoff>  
		Private Sub myFrameNavigated(ByVal sender As Object, ByVal args As NavigationEventArgs)
			Dim myFadeInAnimation As DoubleAnimation = CType(Me.Resources("MyFadeInAnimationResource"), DoubleAnimation)
			myFrame.BeginAnimation(Frame.OpacityProperty, myFadeInAnimation, HandoffBehavior.SnapshotAndReplace)
		End Sub
		' </SnippetBeginAnimationHandoff>

		Private Sub fadeEnded()

			Dim el As XmlElement = CType(myPageList.SelectedItem, XmlElement)
			Dim att As XmlAttribute = el.Attributes("Uri")
			If att IsNot Nothing Then
				myFrame.Navigate(New Uri(att.Value, UriKind.Relative))
			Else
				myFrame.Content = Nothing
			End If
		End Sub

		Public Shared ExitCommand As New RoutedUICommand("Exit", "Exit", GetType(SampleViewer))

		Private Sub executeExitCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Application.Current.Shutdown()
		End Sub
	End Class










End Namespace