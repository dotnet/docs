<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim count As Integer = Panel1.DeviceSpecific.Choices.Count
        Dim i As Integer
        
        ' Cycle through the DeviceSpecificChoiceCollection.
        For i = 0 To count - 1
            Dim txt1 As String = "Choice {0} has {1} Templates. "
            Dim txt2 As String = "Filter name is '{0}'. "
            
            Label1.Text &= String.Format(txt1, i, _
                Panel1.DeviceSpecific.Choices(i).Templates.Count)
            Label2.Text &= String.Format(txt2, _
                Panel1.DeviceSpecific.Choices(i).Filter)
        Next
    End Sub
    
    '<Snippet3>
    ' Add a DeviceSpecificChoice section programatically
    Protected Sub form1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim devSpecific As DeviceSpecific = Panel1.DeviceSpecific
        Dim devChoiceHtml As DeviceSpecificChoice = New DeviceSpecificChoice()
        devChoiceHtml.Filter = "isCHTML10"
        devSpecific.Choices.Add(devChoiceHtml)
        CType(form1, IParserAccessor).AddParsedSubObject(devSpecific)
    End Sub
    '</Snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Panel id="Panel1" Runat="server">
            <mobile:DeviceSpecific ID="DeviceSpecific1" Runat="server">
                <Choice Filter="isHTML32">
                    <ContentTemplate>
                        <!-- For HTML Browsers -->
                        <br />
                        <mobile:Label ID="Label3" Runat="server" 
                            Text="Visible in an HTML Browser" />
                        <br />
                    </ContentTemplate>
                </Choice>
                <Choice Filter="isWML11">
                    <ContentTemplate>
                        <!-- For WML Browsers -->
                        <br />
                        <mobile:Label ID="Label4" Runat="server" 
                            Text="Viewable in a WML browser" />
                        <br />
                    </ContentTemplate>
                </Choice>
            </mobile:DeviceSpecific>
        </mobile:Panel>
        <mobile:Label id="Label1" Runat="server" Font-Bold="true" />
        <mobile:Label ID="Label2" Runat="server" Font-Bold="true" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
