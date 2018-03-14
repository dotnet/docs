<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom LinkButton - AddAttributesToRender - C# Example</title>
    <script runat="server">
      void LinkButton1_Command(Object sender, CommandEventArgs e) 
      {
        // Redirect to the Microsoft home page.
        Response.Redirect("http://www.microsoft.com/");
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom LinkButton - AddAttributesToRender - C# Example</h3>

      <aspSample:CustomLinkButtonAddAttributesToRender 
        id="LinkButton1" 
        runat="server" 
        OnCommand="LinkButton1_Command" 
        ToolTip="Microsoft Home">Microsoft Corp.
      </aspSample:CustomLinkButtonAddAttributesToRender>
      
    </form>
  </body>
</html>
<!-- </Snippet1> -->