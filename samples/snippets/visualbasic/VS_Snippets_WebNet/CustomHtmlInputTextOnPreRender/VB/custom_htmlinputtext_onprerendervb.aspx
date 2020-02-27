<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(sender As Object, e As EventArgs)

    If Not Page.IsPostBack Then

      HtmlInputText1.Value = "Hello HtmlInputText World."

    End If

  End Sub

  Sub HtmlInputText1_ServerChange(sender As Object, e As System.EventArgs)

    Dim htmlInputText1 As System.Web.UI.HtmlControls.HtmlInputText = CType(sender, System.Web.UI.HtmlControls.HtmlInputText)
    Div1.InnerHtml = "Change the preceding text to:<br />" & htmlInputText1.Value

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom HtmlInputText OnPreRender Example</title>
  </head>

  <body>
    <form id="Form1" method="post" runat="server">

      <h3>Custom HtmlInputText OnPreRender Example</h3>

      <p>Make a change to the text, and then press the ENTER.<br />

      <aspSample:CustomHtmlInputTextOnPreRender 
        id="HtmlInputText1" 
        name="HtmlInputText1" 
        runat="server" 
        type="text"
        size="45"
        style="WIDTH: 305px; HEIGHT: 22px" 
        onserverchange="HtmlInputText1_ServerChange">

      </p>
      <br />
      <div 
        id="Div1" 
        runat="server" 
        style="DISPLAY: inline; WIDTH: 256px; HEIGHT: 15px" />
          
    </form>
  </body>
</html>
<!-- </Snippet1> -->
