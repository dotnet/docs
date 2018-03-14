' <snippet2>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class Toolzone_overview_vb

    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        If TextBox1.Text = String.Empty Or TextBox1.Text.Length < 0 Then
            EditorZone1.InstructionText = String.Empty
        Else
            EditorZone1.InstructionText = Server.HtmlEncode(TextBox1.Text)
        End If
        TextBox1.Text = String.Empty
    End Sub

End Class
' </snippet2>