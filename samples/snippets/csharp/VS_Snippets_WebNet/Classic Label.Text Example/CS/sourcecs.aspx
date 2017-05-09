<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Label Example</title>
<script language="C#" runat="server">
         void Button1_Click(Object Sender, EventArgs e) {
            Label l2 = new Label();
            l2.Text = "This is a new Label";
            l2.BorderStyle = BorderStyle.Solid;    
            Page.Controls.Add(l2);
         }
     </script>
 
 </head>
 <body>
     <h3>Label Example</h3>
     <form id="form1" runat="server">
 
         <asp:Button id="Button1" Text="Create and Show a Label" 
         OnClick="Button1_Click" Runat="server"/>
 
     </form>
 </body>
 </html>
   
<!--</Snippet1>-->
