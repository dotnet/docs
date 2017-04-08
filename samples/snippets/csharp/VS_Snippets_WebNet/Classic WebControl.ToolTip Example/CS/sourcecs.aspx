<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (((Button)sender).CommandArgument == "1")
            Label1.Text = "Share your happiness!";
        else
            Label1.Text = "Be happy!";

        Label1.BorderColor = System.Drawing.Color.BurlyWood;
        Label1.BorderWidth = 4;
    }
 
 </script>
 <html xmlns="http://www.w3.org/1999/xhtml">
 <head runat="server">
    <title>WebControl.ToolTip Example</title>
 </head>
 <body>
 <form id="Form1" runat="server">
 
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
