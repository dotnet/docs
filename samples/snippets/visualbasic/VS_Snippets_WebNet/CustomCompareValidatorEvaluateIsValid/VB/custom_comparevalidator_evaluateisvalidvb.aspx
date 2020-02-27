<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CompareValidator - EvaluateIsValid - VB.NET Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom CompareValidator - EvaluateIsValid - C# Example</h3>
            <asp:TextBox id="TextBox1" runat="server">123</asp:TextBox><br />
            <asp:TextBox id="TextBox2" runat="server">123</asp:TextBox>
            <aspSample:CustomCompareValidatorEvaluateIsValid
             id="CompareValidator1" runat="server"
             ErrorMessage="Value in TextBox2 does not match value in TextBox1."
             Display="Dynamic" ControlToCompare="TextBox2" ControlToValidate="TextBox1" /><br />
             <asp:Button id="Button1" runat="server" Text="Button" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
