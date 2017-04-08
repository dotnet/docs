<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom LinkButton - AddAttributesToRender - VB.NET Example</title>
        <script runat="server">
            Sub LinkButton1_Click(sender As Object, e As CommandEventArgs)
                ' Redirect to the Microsoft home page.
                Response.Redirect("http://www.microsoft.com/")
            End Sub
        </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom LinkButton - AddAttributesToRender - VB.NET Example</h3>
            
            <aspSample:CustomLinkButtonAddAttributesToRender id="LinkButton1" 
             runat="server" OnCommand="LinkButton1_Click" 
             ToolTip="Microsoft Home">Microsoft Corp.</aspSample:CustomLinkButtonAddAttributesToRender>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
