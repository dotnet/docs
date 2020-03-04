<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Private Sub Form_Init(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a DeviceSpecific group for Choice elements
        Dim devSpecific As New DeviceSpecific()
        Dim ipa As IParserAccessor

        ' Create two Choice objects, one with a filter
        For i As Integer = 0 To 1
            Dim devChoice As DeviceSpecificChoice
            Dim custTemplate As ITemplate

            ' Create a Choice object 
            devChoice = New DeviceSpecificChoice()
            ' Only the first Choice has a filter (must be in Web.config)
            If i = 0 Then
                devChoice.Filter = "isHTML32"

                ' Create the header template.
                custTemplate = New CustomTemplate("HeaderTemplate")
                ' Put header template in a new container
                custTemplate.InstantiateIn(New TemplateContainer())
                ' Add the header template to the Choice
                devChoice.Templates.Add("HeaderTemplate", custTemplate)

                ' Create the footer template
                custTemplate = New CustomTemplate("FooterTemplate")
                ' Put footer template in a new container
                custTemplate.InstantiateIn(New TemplateContainer())
                ' Add the footer template to the Choice
                devChoice.Templates.Add("FooterTemplate", custTemplate)
            End If
            
            ' Add the Choice to the DeviceSpecific
            ipa = CType(devSpecific, IParserAccessor)
            ipa.AddParsedSubObject(devChoice)
        Next

        ' Add the DeviceSpecific object to the form
        ipa = CType(Form1, IParserAccessor)
        ipa.AddParsedSubObject(devSpecific)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim lab As System.Web.UI.MobileControls.Label
        lab = CType(Form1.Header.FindControl("Label1"), _
            System.Web.UI.MobileControls.Label)
        If IsNothing(lab) Then Return

        ' Get the selected choice's filter name
        Dim filterName As String = _
        Form1.DeviceSpecific.SelectedChoice.Filter
        If filterName = "isHTML32" Then
            lab.Text += " - HTML32"
        Else
            lab.Text += " - Default"
        End If
    End Sub

    Public Class CustomTemplate
        Implements ITemplate
        Dim templName As String

        ' Constructor
        Public Sub New(ByVal TemplateName As String)
            templName = TemplateName
        End Sub

        Public Sub InstantiateIn(ByVal container As Control) _
            Implements ITemplate.InstantiateIn
            
            If templName = "HeaderTemplate" Then
                ' Create a label
                Dim lab As New System.Web.UI.MobileControls.Label
                lab.Text = "Header Template"
                lab.ID = "Label1"

                ' Create a command
                Dim cmd As New Command()
                cmd.Text = "Submit"

                ' Add controls to the container
                container.Controls.Add(lab)
                container.Controls.Add(cmd)
            
            ElseIf templName = "FooterTemplate" Then
                ' Create a label
                Dim lab As System.Web.UI.MobileControls.Label
                lab = New System.Web.UI.MobileControls.Label()
                lab.ID = "Label2"
                lab.Text = "Footer Template"

                ' Add label to the container
                container.Controls.Add(lab)
            End If
        End Sub
    End Class

</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server" 
        OnInit="Form_Init">
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
