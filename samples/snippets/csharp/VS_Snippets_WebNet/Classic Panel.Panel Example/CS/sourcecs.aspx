<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>Panel Example</title>
<script language="C#" runat="server">
 
       void Button1_Click(Object sender, EventArgs e) {
         
          Panel pR = new Panel();       
          pR.HorizontalAlign = HorizontalAlign.Right;
          pR.Wrap = true;
 
          pR.Height = 200;
          pR.Width = 200;
          pR.BackColor = System.Drawing.Color.Gainsboro;
 
          Label l = new Label();
          l.Text = "This panel contains a right justified label.";
          pR.Controls.Add(l);
 
          Page.Controls.Add(pR);
       }
 
    </script>
 
 </head>
 <body>
 
    <h3>Panel Example</h3>
 
    <form id="form1" runat="server">
 
       <asp:Button id="Button1" OnClick="Button1_Click"
            Text="Create a Panel with right justified text" runat="server"/>
 
    </form>
 
 </body>
 </html>
    
<!--</Snippet1>-->
