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
       if (Panel1.HorizontalAlign == HorizontalAlign.Left) {
          Panel1.HorizontalAlign = HorizontalAlign.Right;
          Button1.Text = "Left justify text within Panel";
       } 
       else {
          Panel1.HorizontalAlign = HorizontalAlign.Left;
          Button1.Text = "Right justify text within Panel";
       }
    }
    </script>
 
 </head>
 <body>
    <h3>Panel Example</h3>
    <form id="form1" runat="server">
 
       <asp:Panel id="Panel1" Height="200" Width="100" BackColor="Gainsboro"
            Wrap="True" HorizontalAlign="Right" runat="server"/>
 
       <br />
       <asp:Button id="Button1" OnClick="Button1_Click"
            Text="Left justify text within panel" runat="server"/>
 
    </form>
 </body>
 </html>
    
<!--</Snippet1>-->
