<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlButton - RenderAttributes - Visual Basic Example</title>
    <script runat="server">
      Sub Page_Load(sender As Object, e As EventArgs)
        HtmlButton1.Attributes.Add("onclick", "alert('Hello client-side world.');")
      End Sub

      Sub HtmlButton1_ServerClick(sender As Object, e As EventArgs)
        Div1.InnerHtml = "Hello server-side world."
      End Sub
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlButton - RenderAttributes - Visual Basic Example</h3>

      <aspSample:CustomHtmlButtonRenderAttributes
        id="HtmlButton1"
        runat="server"
        type="button"
        onserverclick="HtmlButton1_ServerClick"
        name="HtmlButton1">Html Button</aspSample:CustomHtmlButtonRenderAttributes>&nbsp;&nbsp;

      <div id="Div1" runat="server"
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
