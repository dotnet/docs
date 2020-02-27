<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head><title>Custom HtmlInputRadioButton - OnPreRender - Visual Basic Example</title>
    <script runat="server">
      Sub Page_Load(sender As Object, e As EventArgs)
        Div1.InnerHtml = ""
      End Sub

      Sub HtmlInputRadioButtonGroup1_ServerChange(sender As Object, e As System.EventArgs)
        Dim htmlInputRadioButtonGroup1 As System.Web.UI.HtmlControls.HtmlInputRadioButton  = CType(sender, System.Web.UI.HtmlControls.HtmlInputRadioButton)
        Div1.InnerHtml = "You change your selection to: " & htmlInputRadioButtonGroup1.Value
      End Sub
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlInputRadioButton - OnPreRender - Visual Basic Example</h3>

      <aspSample:CustomHtmlInputRadioButtonOnPreRender 
        id="HtmlInputRadioButton1" 
        name="HtmlInputRadioButtonGroup1" 
        runat="server" 
        type="radio" checked
        onserverchange="HtmlInputRadioButtonGroup1_ServerChange" 
        value="HtmlInputRadioButton1">HtmlInputRadioButton1
      </aspSample:CustomHtmlInputRadioButtonOnPreRender>
      <br />

      <aspSample:CustomHtmlInputRadioButtonOnPreRender 
        id="HtmlInputRadioButton2" 
        name="HtmlInputRadioButtonGroup1" 
        runat="server" 
        type="radio" 
        onserverchange="HtmlInputRadioButtonGroup1_ServerChange" 
        value="HtmlInputRadioButton2">HtmlInputRadioButton2
      </aspSample:CustomHtmlInputRadioButtonOnPreRender>

      <p>
        <input type="submit" value="Submit" id="Submit1" name="Submit1" runat="server" />
      </p>
      
      <div 
        id="Div1" 
        runat="server" 
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->