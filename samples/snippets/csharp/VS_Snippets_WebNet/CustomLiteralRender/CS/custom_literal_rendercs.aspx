<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom LiteralControl - Render - C# Example</title>
       <script runat="server">
      void Button1_Click(Object sender, EventArgs e)
      {
         Literal1.Text = "Welcome to ASP.NET!";
      }
   </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom LiteralControl - Render - C# Example</h3>
            
            <aspSample:CustomLiteralRender id="Literal1" 
              runat="server" />

      <br /><br />

      <asp:Button id="Button1"
        Text="Change"
        OnClick="Button1_Click"
        runat="server"/>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
