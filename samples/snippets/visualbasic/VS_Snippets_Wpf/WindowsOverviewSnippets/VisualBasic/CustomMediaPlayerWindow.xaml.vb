'<SnippetActivationDeactivationCODEBEHIND>

Imports System.Windows

Namespace SDKSample
	Partial Public Class CustomMediaPlayerWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub window_Activated(ByVal sender As Object, ByVal e As EventArgs)
			' Recommence playing media if window is activated
			Me.mediaElement.Play()
		End Sub

		Private Sub window_Deactivated(ByVal sender As Object, ByVal e As EventArgs)
			' Pause playing if media is being played and window is deactivated
			Me.mediaElement.Pause()
		End Sub
	End Class
End Namespace
'</SnippetActivationDeactivationCODEBEHIND>