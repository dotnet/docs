<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom RangeValidator - EvaluateIsValid - C# Example</title>
    <script runat="server">
      void ButtonClick(Object sender, EventArgs e)
      {
        if (Page.IsValid)
        {
          Label1.Text="Page is valid.";
        }
        else
        {
          Label1.Text="Page is not valid!!";
        }
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom RangeValidator - EvaluateIsValid - C# Example</h3>

      Enter a number from 1 to 10:<br />
      <asp:TextBox id="TextBox1" Runat="server" />

      <aspSample:CustomRangeValidatorEvaluateIsValid 
        id="RangeValidator1" 
        runat="server" 
        ControlToValidate="TextBox1" 
        MinimumValue="1" 
        MaximumValue="10" 
        Type="Integer" 
        EnableClientScript="false" 
        Text="The value must be from 1 to 10!" />
        
      <br />
      <br />
      <asp:Button id="Button1" Text="Submit" OnClick="ButtonClick" runat="server" /><br />
      <br />

      <asp:Label id="Label1" runat="server" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
