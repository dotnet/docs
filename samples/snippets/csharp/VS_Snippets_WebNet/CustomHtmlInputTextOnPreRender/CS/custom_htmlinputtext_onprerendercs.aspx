<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e) 
  {
    if (!Page.IsPostBack)
    {
      HtmlInputText1.Value = "Hello HtmlInputText World.";
    }
  }

  void HtmlInputText1_ServerChange(object sender, System.EventArgs e)
  {

    // Diplay the value of the selected HtmlInputText control.
    System.Web.UI.HtmlControls.HtmlInputText htmlInputText1 = (System.Web.UI.HtmlControls.HtmlInputText) sender;
    Div1.InnerHtml = "Change the preceding text to:<br />" + htmlInputText1.Value;

  }

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
