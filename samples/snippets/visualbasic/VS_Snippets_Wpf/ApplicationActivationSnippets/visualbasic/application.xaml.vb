'<SnippetDetectActivationStateCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private isApplicationActive As Boolean

		Private Sub App_Activated(ByVal sender As Object, ByVal e As EventArgs)
			' Application activated
			Me.isApplicationActive = True
		End Sub

		Private Sub App_Deactivated(ByVal sender As Object, ByVal e As EventArgs)
			' Application deactivated
			Me.isApplicationActive = False
		End Sub
	End Class
End Namespace
'</SnippetDetectActivationStateCODEBEHIND>