'<SnippetHandlingSessionEndingCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System.Windows

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_SessionEnding(ByVal sender As Object, ByVal e As SessionEndingCancelEventArgs)
			' Ask the user if they want to allow the session to end
			Dim msg As String = String.Format("{0}. End session?", e.ReasonSessionEnding)
			Dim result As MessageBoxResult = MessageBox.Show(msg, "Session Ending", MessageBoxButton.YesNo)

			' End session, if specified
			If result = MessageBoxResult.No Then
				e.Cancel = True
			End If
		End Sub
	End Class
End Namespace
'</SnippetHandlingSessionEndingCODEBEHIND>