<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlInputButton - OnPreRender - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e)
      {
        HtmlInputButton1.Attributes.Add("onclick","alert('Hello client-side world.');");
      }

      void HtmlInputButton1_ServerClick(Object sender, EventArgs e)
      {
        Div1.InnerHtml = "Hello server-side world.";
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlInputButton - OnPreRender - C# Example</h3>

      <aspSample:CustomHtmlInputButtonOnPreRender
        id="HtmlInputButton1"
        runat="server"
        type="button"
        onserverclick="HtmlInputButton1_ServerClick"
        value="Html Input Button"
        name="HtmlInputButton1">&nbsp;&nbsp;

      <div id="Div1" runat="server"
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
