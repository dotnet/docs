' <Snippet_graphicsmm_StateEventHandlers>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors

	Partial Public Class StateExample
		Inherits Page

		Private Sub parentTimelineStateInvalidated(ByVal sender As Object, ByVal args As EventArgs)
			Dim myClock As Clock = CType(sender, Clock)
			ParentTimelineStateTextBlock.Text += myClock.CurrentTime.ToString() & ":" & myClock.CurrentState.ToString() & " "
		End Sub

		Private Sub animation1StateInvalidated(ByVal sender As Object, ByVal args As EventArgs)

			Dim myClock As Clock = CType(sender, Clock)

			Animation1StateTextBlock.Text += myClock.Parent.CurrentTime.ToString() & ":" & myClock.CurrentState.ToString() & " "
		End Sub

		Private Sub animation2StateInvalidated(ByVal sender As Object, ByVal args As EventArgs)

			Dim myClock As Clock = CType(sender, Clock)
			Animation2StateTextBlock.Text += myClock.Parent.CurrentTime.ToString() & ":" & myClock.CurrentState.ToString() & " "
		End Sub
	End Class
End Namespace
' </Snippet_graphicsmm_StateEventHandlers>