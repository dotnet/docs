<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom LiteralControl - CreateControlCollection - VB.Net Example</title>
       <script runat="server">
      Sub Button1_Click(sender As Object, e As EventArgs)
      
         Literal1.Text = "Welcome to ASP.NET!"
      
      End Sub

   </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom LiteralControl - CreateControlCollection - VB.Net Example</h3>
            
            <aspSample:CustomLiteralCreateControlCollection id="Literal1" 
              runat="server" text="Literal Text" />

      <br /><br />

      <asp:Button id="Button1"
        Text="Change"
        OnClick="Button1_Click"
        runat="server"/>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
