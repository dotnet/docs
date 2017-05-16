<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <script language="VB" runat="server">
 
    Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, Button).CommandArgument = "1" Then
            Label1.Text = "Share your happiness!"
        Else
            Label1.Text = "Be happy!"
        End If
        Label1.BorderColor = Drawing.Color.BurlyWood
        Label1.BorderWidth = 4
    End Sub
 
 </script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="server">
    <title>ToolTip Property of a Web Control</title>
</head>
<body>
  
 <form id="form1" runat="server">
 
    <h3>ToolTip Property of a Web Control</h3>
    <p>Don't know which button to click?<br />
        Move the mouse pointer over the buttons to find out!
    </p>

    <p><asp:Button id="SubmitBtn1" OnClick="SubmitBtn_Click" 
            Text="Click Me" CommandArgument="1"
            ToolTip="Click me if you are happy" runat="server"/>
    </p>

    <p><asp:Button id="SubmitBtn2" OnClick="SubmitBtn_Click" 
            Text="Click Me" CommandArgument="2"
            ToolTip="Click me if you are sad." runat="server"/>
    </p>

    <asp:Label id="Label1" Font-size="24pt" Font-Bold="True" 
        BackColor="Yellow" runat="server"/>

 </form>
 
 </body>
 </html>
 
<!--</Snippet1>-->
