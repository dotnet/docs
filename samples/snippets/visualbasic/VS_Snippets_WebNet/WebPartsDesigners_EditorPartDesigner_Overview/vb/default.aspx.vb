'<snippet3>
Imports System.Web.UI.WebControls.WebParts

Public Partial Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If True Then
			' Make the 'Edit' verb available so the EditorZone can render
			Dim mgr As WebPartManager = WebPartManager.GetCurrentWebPartManager(Page)
			mgr.DisplayMode = mgr.SupportedDisplayModes("Edit")
		End If
	End Sub
End Class
'</snippet3>