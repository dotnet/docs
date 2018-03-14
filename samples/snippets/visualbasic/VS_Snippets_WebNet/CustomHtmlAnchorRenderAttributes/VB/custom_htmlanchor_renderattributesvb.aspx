<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlAnchor - RenderAttributes - Visual Basic Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      Top of Page
      &lt;<aspSample:CustomHtmlAnchorRenderAttributes
           id="HtmlAnchor1"
           runat="server"
           name="HtmlAnchor1">HtmlAnchor1</aspSample:CustomHtmlAnchorRenderAttributes>&gt;

      <h3>Custom HtmlAnchor - RenderAttributes - Visual Basic Example</h3>
      <p>Place the mouse pointer over the HtmlAnchor1 tag (above). A Title attribute was added from within the RenderAttributes override method.</p>
      <p>Jump to <a href="#HtmlAnchor2">HtmlAnchor2</a> below.</p>

      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>
      <p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p>

      <p>Jump to <a href="#HtmlAnchor1">HtmlAnchor1</a> above.</p>
      <p>&nbsp;</p>Bottom of Page
      &lt;<aspSample:CustomHtmlAnchorRenderAttributes
           id="HtmlAnchor2"
           runat="server"
           name="HtmlAnchor2">HtmlAnchor2</aspSample:CustomHtmlAnchorRenderAttributes>&gt;
    </form>
  </body>
</html>
<!-- </Snippet1> -->
