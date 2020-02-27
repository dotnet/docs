<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Panel Example</title>
<script language="C#" runat="server">
 
    void Page_Load(Object sender, EventArgs e) {
       Label l = new Label();
       l.Text = "This panel contains a label control.";
       Panel1.Controls.Add(l);
    }
     
    void Button1_Click(Object sender, EventArgs e) {
       if (Panel1.Wrap == true) {
          Panel1.Wrap = false;
          Button1.Text = "Set Wrap=True";
       } 
       else {
          Panel1.Wrap = true;
          Button1.Text = "Set Wrap=False";
       }
    }
 
    </script>
 </head>
 <body>
 
    <h3>Panel Example</h3>
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" Height="200" Width="100" BackColor="Gainsboro"
            Wrap="True" runat="server"/>
     
       <br /> 
       <asp:Button id="Button1" OnClick="Button1_Click"
            Text="Set Wrap=False" runat="server"/>
 
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
