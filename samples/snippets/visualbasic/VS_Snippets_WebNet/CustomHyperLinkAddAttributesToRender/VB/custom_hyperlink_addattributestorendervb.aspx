<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom HyperLink - AddAttributesToRender - VB.NET Example</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom HyperLink - AddAttributesToRender - VB.NET Example</h3>

            <aspSample:CustomHyperLinkAddAttributesToRender 
             id="HyperLink1" runat="server" Target="_blank"
             NavigateUrl="http://www.microsoft.com/"  
             ToolTip="Microsoft Web Site">www.microsoft.com
            </aspSample:CustomHyperLinkAddAttributesToRender>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
