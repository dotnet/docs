<!--<Snippet3>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HideDisabledControl Adapter</title>
    <script runat="server">
        Sub ServerButtonClick(ByVal source As Object, ByVal args As EventArgs)
            If (Button1.Text.Equals("Enable Label")) Then
                ContosoLabel1.Enabled = True
                Button1.Text = "Disable Label"
                messageLabel.Text = "The label is <b>En</b>abled"
            Else
                ContosoLabel1.Enabled = False
                Button1.Text = "Enable Label"
                messageLabel.Text = "The label is <b>dis</b>abled"
            End If
        End Sub
    </script>
</head>
<body style="background-color:silver">
    <form id="Form1" runat="server">
        <asp:Label id="ContosoLabel1"             
            text="Contoso Label" 
            WinCE:text="CE Label"
            BorderWidth="3" 
            BorderStyle="Inset"
            style="FONT-SIZE: xx-small"
            runat="server">
            </asp:Label>
        <br />
        <asp:Button id="Button1" 
            text="Disable Label"
            OnClick="ServerButtonClick" 
            runat="server" />
        <br />    
        <asp:Label id="messageLabel" 
            runat="server" 
            style="FONT-SIZE: xx-small"
            AssociatedControlID="Button1">
            <i>Select the button to disable the label.</i>
        </asp:Label>
    </form>
</body>
</html>
<!--</Snippet3>-->
