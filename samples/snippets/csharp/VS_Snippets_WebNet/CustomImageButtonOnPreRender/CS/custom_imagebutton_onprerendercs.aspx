<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom ImageButton - OnPreRender - C# Example</title>
    <script runat="server">
      void ImageButton1_Command(Object sender, CommandEventArgs e) 
      {
        // Redirect to the Microsoft home page.
        Response.Redirect("http://www.microsoft.com/");
      }
    </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom ImageButton - OnPreRender - C# Example</h3>
            
            <aspSample:CustomImageButtonOnPreRender 
              id="ImageButton1" 
              runat="server" 
              OnCommand="ImageButton1_Command" 
              AlternateText="Microsoft Home" 
              ImageUrl="http://www.microsoft.com/homepage/gif/bnr-microsoft.gif" />

        </form>
    </body>
</html>
<!-- </Snippet1> -->
