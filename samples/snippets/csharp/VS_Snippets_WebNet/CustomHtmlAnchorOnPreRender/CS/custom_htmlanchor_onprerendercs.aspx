<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlAnchor - OnPreRender - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      Top of Page
      &lt;<aspSample:CustomHtmlAnchorOnPreRender
           id="HtmlAnchor1"
           runat="server"
           name="HtmlAnchor1">HtmlAnchor1</aspSample:CustomHtmlAnchorOnPreRender>&gt;

      <h3>Custom HtmlAnchor - OnPreRender - C# Example</h3>
      <p>&nbsp;</p>
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
      &lt;<aspSample:CustomHtmlAnchorOnPreRender
           id="HtmlAnchor2"
           runat="server"
           name="HtmlAnchor2">HtmlAnchor2</aspSample:CustomHtmlAnchorOnPreRender>&gt;
    </form>
  </body>
</html>
<!-- </Snippet1> -->
