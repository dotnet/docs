' <Snippet63>
Imports System.Web.UI.HtmlControls
' </Snippet63>

Partial Public Class Section
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    ' <Snippet62>
    Protected Sub ListView1_PreRender(ByVal sender As Object,
                                      ByVal e As EventArgs)

        Dim s As String =
            ObjectDataSource1.SelectParameters(
                "sectionName").DefaultValue.ToString()
        If Request.QueryString("Section") IsNot Nothing Then
            s = Request.QueryString("Section")
        End If
        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", s)

        Dim tableCaption As HtmlGenericControl =
            TryCast(ListView1.FindControl("ElementTableCaption"), 
                System.Web.UI.HtmlControls.HtmlGenericControl)
        If tableCaption IsNot Nothing Then
            tableCaption.InnerText =
                tableCaption.InnerText.Replace("[name]", s)
        End If

        Dim noElementsLabel As Label =
            TryCast(ListView1.Controls(0).FindControl("NoElementsLabel"), 
                Label)
        If noElementsLabel IsNot Nothing Then
            noElementsLabel.Text =
                noElementsLabel.Text.Replace("[name]", s)

        End If
    End Sub
    ' </Snippet62>
End Class