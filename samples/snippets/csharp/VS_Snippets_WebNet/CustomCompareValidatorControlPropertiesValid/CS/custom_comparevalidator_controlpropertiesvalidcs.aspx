<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CompareValidator - ControlPropertiesValid - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e)
      {
        // Run the Page Validate method in order to force
        // the CompareValidate to show it's error message.
        Page.Validate();
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom CompareValidator - ControlPropertiesValid - C# Example</h3>

      <asp:TextBox id="TextBox1" runat="server">123</asp:TextBox><br />

      <aspSample:CustomCompareValidatorControlPropertiesValid
        id="CompareValidator1"
        runat="server"
        Display="Dynamic"
        ErrorMessage="The value of TextBox1 must be '456'."
        ControlToValidate="TextBox1"
        ValueToCompare="456" /><br />

      <asp:Button id="Button1" runat="server" Text="Button" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->
