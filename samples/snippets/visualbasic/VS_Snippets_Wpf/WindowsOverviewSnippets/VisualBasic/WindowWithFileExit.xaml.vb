'<SnippetWindowWithFileExitCODEBEHIND>

Imports System.Windows

Namespace SDKSample
	Partial Public Class WindowWithFileExit
		Inherits System.Windows.Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub fileExitMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Close this window
			Me.Close()
		End Sub
	End Class
End Namespace
'</SnippetWindowWithFileExitCODEBEHIND>