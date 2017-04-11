<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head><title>Custom HtmlInputRadioButton - OnPreRender - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e) 
      {
        Div1.InnerHtml = "";
      }

      void HtmlInputRadioButtonGroup1_ServerChange(object sender, System.EventArgs e)
      {
        // Diplay the value of the selected HtmlInputRadioButton control.
        System.Web.UI.HtmlControls.HtmlInputRadioButton htmlInputRadioButtonGroup1 = (System.Web.UI.HtmlControls.HtmlInputRadioButton) sender;
        Div1.InnerHtml = "You change your selection to: " + htmlInputRadioButtonGroup1.Value;
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom HtmlInputRadioButton - OnPreRender - C# Example</h3>

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