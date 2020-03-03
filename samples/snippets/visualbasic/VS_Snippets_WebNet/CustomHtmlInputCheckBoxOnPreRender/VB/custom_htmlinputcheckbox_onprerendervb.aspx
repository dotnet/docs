<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlInputCheckBox - OnPreRender - Visual Basic Example</title>
    <script runat="server">
      Sub Button1_Click(sender As Object, e As EventArgs)
        Div1.InnerHtml = ""

        If HtmlInputCheckBox1.Checked = True Then
            Div1.InnerHtml = "You like basketball. "
        End If

        If HtmlInputCheckBox2.Checked = True Then
            Div1.InnerHtml += "You like football. "
        End If

        If HtmlInputCheckBox3.Checked = True Then
            Div1.InnerHtml += "You like soccer. "
        End If
      End Sub

    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlInputCheckBox - OnPreRender - Visual Basic Example</h3>
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

      <br />
      <div id="Div1" runat="server"
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px"
        ms_positioning="FlowLayout" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
