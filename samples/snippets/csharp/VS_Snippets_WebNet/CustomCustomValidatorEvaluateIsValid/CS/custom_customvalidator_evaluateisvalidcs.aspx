<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CustomValidator - EvaluateIsValid - C# Example</title>
  </head>
<body>
  <form id="Form1" method="post" runat="server">
    <h3>Custom CustomValidator - EvaluateIsValid - C# Example</h3>

    <asp:Label id="Label1" runat="server" Text="Enter an even number:"
      AssociatedControlID="TextBox1" /><br />

    <asp:TextBox id="TextBox1" runat="server" />&nbsp;

    <aspSample:CustomCustomValidatorEvaluateIsValid
      id="Customvalidator1"
      runat="server"
      ControlToValidate="TextBox1"
      Display="Static"
      ErrorMessage="Not an even number!" /><br /><br />

    <asp:Button id="Button1" runat="server" Text="Validate" />

  </form>
</body>
</html>
<!-- </Snippet1> -->