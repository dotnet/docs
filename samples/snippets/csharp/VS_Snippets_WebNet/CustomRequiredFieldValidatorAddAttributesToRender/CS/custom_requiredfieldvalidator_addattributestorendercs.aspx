<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom RequiredFieldValidator - AddAttributesToRender - C# Example</title>
    <script runat="server">
      void Button1_Click(Object sender, EventArgs e) 
      {
        if (Page.IsValid) 
        {
          Label1.Text = "Required field is filled!";
        }
        else 
        {
          Label1.Text = "Required field is empty!";
        }
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom RequiredFieldValidator - AddAttributesToRender - C# Example</h3>

      <table border="0" cellpadding="4" cellspacing="0">
        <tr valign="top">
          <td colspan="3">
            <asp:Label ID="Label1" runat="server" Text="Fill in the required field below" />
          </td>
        </tr>
        <tr>
          <td align="right">Card Number:</td>
          <td>
            <asp:TextBox id="TextBox1" runat="server" />
          </td>
          <td>
            <aspSample:CustomRequiredFieldValidatorAddAttributesToRender 
              id="RequiredFieldValidator1" 
              runat="server" 
              ControlToValidate="TextBox1" 
              Display="Static" 
              ErrorMessage="Required" />
          </td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>
            <asp:Button id="Button1" runat="server" Text="Validate" OnClick="Button1_Click" />
          </td>
          <td>&nbsp;</td>
        </tr>
      </table>

    </form>
  </body>
</html>
<!-- </Snippet1> -->