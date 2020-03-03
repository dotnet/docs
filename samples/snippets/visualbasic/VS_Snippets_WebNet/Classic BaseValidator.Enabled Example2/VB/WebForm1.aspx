<%@ Page language="VB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>WebForm1</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <asp:TextBox id="TextBox1" 
                style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 16px" 
                runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" 
                style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 56px"
                runat="server" 
                ErrorMessage="Value is required." 
                Enabled="False" 
                ControlToValidate="TextBox1">Please enter a value.
            </asp:RequiredFieldValidator>
            <asp:Button id="Button1" 
                style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 88px" 
                runat="server"
                Text="Submit">
            </asp:Button>
            <input type="checkbox" 
                style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 136px" 
                onclick="Check_Changed()" />
            <div style="DISPLAY: inline; Z-INDEX: 105; LEFT: 56px; WIDTH: 144px; POSITION: absolute; TOP: 136px; HEIGHT: 24px"> 
                Enable Validator</div>
        </form>
    </body>
</html>
<script language="jscript" type="text/jscript">
 
 function Check_Changed()
 {
    ValidatorEnable(RequiredFieldValidator1, event.srcElement.status);
 }

</script>