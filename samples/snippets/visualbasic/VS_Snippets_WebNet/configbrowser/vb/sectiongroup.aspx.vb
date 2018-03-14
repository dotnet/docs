
Partial Class SectionGroup
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object,
                            ByVal e As EventArgs)
        ' <Snippet40>
        SectionGroupGridView.HeaderRow.TableSection =
            TableRowSection.TableHeader
        ' </Snippet40>

        ' <Snippet42>
        Dim s As String =
            ObjectDataSource1.SelectParameters("sectionGroupName").DefaultValue.ToString()
        If Request.QueryString("SectionGroup") IsNot Nothing Then
            s = Request.QueryString("SectionGroup")
        End If
        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", s)
        SectionGroupGridView.Caption =
            SectionGroupGridView.Caption.Replace("[name]", s)
        ' </Snippet42>
    End Sub
End Class
