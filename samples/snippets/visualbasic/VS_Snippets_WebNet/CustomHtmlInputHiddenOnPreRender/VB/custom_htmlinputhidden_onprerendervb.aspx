<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    
    <title>Custom HtmlInputHidden - OnPreRender - Visual Basic Example</title>
    
    <script runat="server">
      Sub Page_Load(sender As Object, e As EventArgs)
        HtmlInputHidden1.Value = "<Hello HtmlInputHidden World>"
      End Sub
    </script>
    </head>
    <body onload="alert('View the source to see the HTML Hidden Input value.')">
        <form id="Form1" method="post" runat="server">
            <h3>Custom HtmlInputHidden - OnPreRender - Visual Basic Example</h3>
        
          <aspSample:CustomHtmlInputHiddenOnPreRender 
            id="HtmlInputHidden1" 
            runat="server" 
            type="hidden">
            
        </form>
    </body>
</html>
<!-- </Snippet1> -->
