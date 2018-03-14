<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>RegularExpressionValidator Example</title>
<script runat="server">
 
       void ValidateBtn_Click(Object sender, EventArgs e) 
       {
          if (Page.IsValid) 
          {
             lblOutput.Text = "Page is Valid.";
          }
          else 
          {
             lblOutput.Text = "Page is InValid.";
          }
       }
 
    </script>

 </head>
 <body> 
    <form id="form1" runat="server">
 
    <h3>RegularExpressionValidator Example</h3>

       <table style="background-color:#eeeeee; padding:10">
          <tr valign="top">
             <td colspan="3">
                <asp:Label ID="lblOutput" 
                     Text="Enter a 5-digit ZIP Code" 
                     runat="server"
                     AssociatedControlID="TextBox1"/>
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
                <asp:TextBox id="TextBox1" 
                     runat="server"/>
             </td>
             <td>
                <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                     ControlToValidate="TextBox1"
                     ValidationExpression="\d{5}"
                     Display="Static"
                     ErrorMessage="ZIP code must be 5 numeric digits"
                     EnableClientScript="False" 
                     runat="server"/>
             </td>
          </tr>
          <tr>
             <td></td>
             <td>
                <asp:Button text="Validate" 
                     OnClick="ValidateBtn_Click" 
                     runat="server" />
             </td>
             <td></td>
          </tr>
       </table>
 
    </form>
 </body>
 </html>
 
<!--</Snippet1>-->
