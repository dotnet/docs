<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlButton - OnPreRender - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e)
      {
        HtmlButton1.Attributes.Add("onclick","alert('Hello client-side world.');");
      }

      void HtmlButton1_ServerClick(Object sender, EventArgs e)
      {
        Div1.InnerHtml = "Hello server-side world.";
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlButton - OnPreRender - C# Example</h3>

      <aspSample:CustomHtmlButtonOnPreRender
        id="HtmlButton1"
        runat="server"
        type="button"
        onserverclick="HtmlButton1_ServerClick"
        name="HtmlButton1">Html Button</aspSample:CustomHtmlButtonOnPreRender>&nbsp;&nbsp;

      <div id="Div1" runat="server"
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
