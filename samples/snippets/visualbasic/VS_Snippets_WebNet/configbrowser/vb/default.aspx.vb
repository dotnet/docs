' <Snippet25>
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text
' </Snippet25>

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' <Snippet22>
        If Session("Heading") IsNot Nothing Then
            HeadingLabel.Text = HeadingLabel.Text.Replace(
                "Machine.config", Session("Heading").ToString())
        End If

        Dim virtualPath As String = ""
        Dim site As String = ""
        Dim locationSubPath As String = ""
        Dim server As String = ""

        If Session("Path") IsNot Nothing Then
            virtualPath = Session("Path").ToString()
        End If

        If Session("Site") IsNot Nothing Then
            site = Session("Site").ToString()
        End If

        If Session("SubPath") IsNot Nothing Then
            locationSubPath = Session("SubPath").ToString()
        End If

        If Session("Server") IsNot Nothing Then
            site = Session("Server").ToString()
        End If
        ' </Snippet22>

        ' <Snippet23>
        Dim config As Configuration =
            WebConfigurationManager.OpenWebConfiguration(
                virtualPath, site, locationSubPath, server)

        Dim listString As New StringBuilder("<ul>")
        For Each sectionGroup As ConfigurationSectionGroup _
            In config.SectionGroups

            AddSectionGroupInfo(sectionGroup, listString)
        Next
        listString.Append("</ul>")


        ' </Snippet23>
        SectionGroupsLiteral.Text = listString.ToString()
    End Sub

    ' <Snippet24>
    Public Sub AddSectionGroupInfo(ByVal sectionGroup _
                                   As ConfigurationSectionGroup,
                                   ByVal listString As StringBuilder)
        listString.Append(
            ("<li><a href='SectionGroup.aspx?SectionGroup=" _
                & sectionGroup.SectionGroupName & "'>") _
                + sectionGroup.Name & "</a></li>")

        listString.Append("<ul>")
        If OptionsCheckBoxList.Items(0).Selected Then
            For Each section As ConfigurationSection _
                In sectionGroup.Sections

                listString.Append(
                    "<li>" & section.SectionInformation.Name & "</li>")
            Next
        End If
        If OptionsCheckBoxList.Items(1).Selected Then
            For Each s As ConfigurationSectionGroup _
                In sectionGroup.SectionGroups

                AddSectionGroupInfo(s, listString)
            Next
        End If
        listString.Append("</ul>")
    End Sub
    ' </Snippet24>
End Class