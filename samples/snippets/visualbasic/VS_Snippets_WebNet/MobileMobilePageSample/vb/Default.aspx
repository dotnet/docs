<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    ' <Snippet2>
    Private Sub Command_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        ' Display the other form
        If ActiveForm.ID = "Form1" Then
            ActiveForm = Form2
        Else
            ActiveForm = Form1
        End If
    End Sub
    ' </Snippet2>

    Public Function isAccessKey(ByVal caps As MobileCapabilities, _
        ByVal optValue As String) As Boolean
        
        ' Determine if the browser is not a Web crawler 
        ' and can use access keys
        If Not caps.Crawler AndAlso caps.SupportsAccesskeyAttribute Then
            Return True
        End If
        Return False
    End Function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1" >
        <mobile:Label ID="Label1" Runat="server">This is Form1</mobile:Label>
        <mobile:Command id="cmd1" runat="server" Text="No AccessKey" 
            onClick="Command_OnClick">
            <DeviceSpecific>
               <Choice Filter="isAccessKey" Text="AccessKey is 1"/>
            </DeviceSpecific>
        </mobile:Command>
        <mobile:Label id="Label2" runat="server" />
    </mobile:Form>
    <mobile:Form ID="Form2" Runat="server">
        <mobile:Label ID="Label3" Runat="server">This is Form2</mobile:Label>
        <mobile:Command id="cmd2" runat="server" text="Back to Form1"
            onClick="Command_OnClick">
            <DeviceSpecific>
                <Choice Filter="isAccessKey" Text="1 is AccessKey" AccessKey="1" />
            </DeviceSpecific>
        </mobile:Command>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
