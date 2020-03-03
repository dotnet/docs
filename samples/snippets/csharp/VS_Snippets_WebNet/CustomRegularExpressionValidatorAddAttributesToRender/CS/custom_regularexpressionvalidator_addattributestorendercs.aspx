<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom RegularExpressionValidator - AddAttributesToRender - C# Example</title>
    <script runat="server">
      void Button1_Click(Object sender, EventArgs e) 
      {
        if (Page.IsValid) 
        {
          Label1.Text = "Page is valid.";
        }
        else 
        {
          Label1.Text = "Page is invalid!";
        }
      }
    </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom RegularExpressionValidator - AddAttributesToRender - C# Example</h3>
       <table style="background-color:#eeeeee; padding:10">
          <tr valign="top">
             <td colspan="3">
                <asp:Label ID="Label1" 
                  Text="Enter a 5 digit zip code" 
                  runat="server"/>
             </td>
          </tr>
 
          <tr>
             <td colspan="3">
                <b>Personal Information</b>
             </td>
          </tr>
          <tr>
             <td align="right">
                Zip Code:
             </td>
             <td>
                <asp:TextBox id="TextBox1" runat="server"/>
             </td>
             <td>
                <aspSample:CustomRegularExpressionValidatorAddAttributesToRender 
                  id="Regularexpressionvalidator1" 
                  runat="server"
                  ControlToValidate="TextBox1"
                  ValidationExpression="\d{5}"
                  ErrorMessage="Zip code must be 5 numeric digits"
                  Display="Static"
                  EnableClientScript="False" />
             </td>
          </tr>
          <tr>
             <td></td>
             <td>
                <asp:Button text="Button1" 
                  OnClick="Button1_Click" 
                  runat="server" ID="Button1"/>
             </td>
             <td></td>
          </tr>
       </table>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
