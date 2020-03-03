<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlInputCheckBox - OnPreRender - C# Example</title>
    <script runat="server">
      void Button1_Click(Object sender, EventArgs e)
      {
        Div1.InnerHtml = "";

        if(HtmlInputCheckBox1.Checked == true)
        {
          Div1.InnerHtml = "You like basketball. ";
        }

        if(HtmlInputCheckBox2.Checked == true)
        {
          Div1.InnerHtml += "You like football. ";
        }

        if(HtmlInputCheckBox3.Checked == true)
        {
          Div1.InnerHtml += "You like soccer. ";
        }
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlInputCheckBox - OnPreRender - C# Example</h3>
      <br />
      Enter Interests:<p>
      <aspSample:CustomHtmlInputCheckBoxOnPreRender
        id="HtmlInputCheckBox1"
        runat="server"
        type="checkbox" checked
        value="Basketball"> Basketball

      <aspSample:CustomHtmlInputCheckBoxOnPreRender
        id="HtmlInputCheckBox2"
        runat="server"
        type="checkbox"
        value="Football"> Football

      <aspSample:CustomHtmlInputCheckBoxOnPreRender
        id="HtmlInputCheckBox3"
        runat="server"
        type="checkbox"
        value="Soccer"> Soccer
      </p>
      <p>
      <input id="Button1"
        runat="server"
        type="button"
        value="Enter"
        onserverclick="Button1_Click"
        name="Button1" />
      </p>

      <div id="Div1" runat="server"
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
