<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom RequiredFieldValidator - EvaluateIsValid - VB.NET Example</title>
        <script runat="server">
            Sub Button1_Click(sender As Object, e As EventArgs) 
            
                If Page.IsValid Then 
                
                    Label1.Text = "Required field is filled!"
                
                Else 
                
                    Label1.Text = "Required field is empty!"
                
                End If

            End Sub
        </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom RequiredFieldValidator - EvaluateIsValid - VB.NET Example</h3>

            <table border="0" cellpadding="4" cellspacing="0">
                <tr valign="top">
                    <td colspan="3">
                        <asp:Label ID="Label1" runat="server" 
                         Text="Fill in the required field below" />
                    </td>
                </tr>
                <tr>
                    <td align="right">Card Number:</td>
                    <td>
                        <asp:TextBox id="TextBox1" runat="server" />
                    </td>
                    <td>
                        <aspSample:CustomRequiredFieldValidatorEvaluateIsValid id="RequiredFieldValidator1" 
                         runat="server" ControlToValidate="TextBox1" Display="Static" ErrorMessage="*" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button id="Button1" runat="server" Text="Validate" 
                         OnClick="Button1_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </form>
    </body>
</html>
<!-- </Snippet1> -->