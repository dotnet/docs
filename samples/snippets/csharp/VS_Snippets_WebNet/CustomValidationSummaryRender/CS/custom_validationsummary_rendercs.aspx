<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom ValidationSummary - Render - C# Example</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom ValidationSummary - Render - C# Example</h3>

      <table id="Table1" cellpadding="4" cellspacing="0">
        <tr>
          <td>
            <table id="Table2" cellpadding="4" cellspacing="0" style="background-color:#eeeeee">
              <tr>
                <td colspan="3"><b>Credit Card Information</b> </td>
              </tr>
              <tr>
                <td align="right">Card Type: </td>
                <td>
                  <asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatLayout="Flow">
                      <asp:ListItem>MasterCard</asp:ListItem>
                      <asp:ListItem>Visa</asp:ListItem>
                  </asp:RadioButtonList>
                </td>
                <td align="center" rowspan="1">
                  <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator1" 
                    runat="server" 
                    ErrorMessage="Card Type" 
                    Width="100%" 
                    Display="Static" 
                    ControlToValidate="RadioButtonList1">*
                  </asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr>
                <td align="right">Card Number: </td>
                <td><asp:TextBox id="TextBox1" runat="server"></asp:TextBox></td>
                <td>
                  <asp:RequiredFieldValidator 
                    id="RequiredFieldValidator2" 
                    runat="server" 
                    ErrorMessage="Card Number" 
                    Width="100%" 
                    Display="Static" 
                    ControlToValidate="TextBox1">*
                  </asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr>
                <td></td>
                <td><asp:Button id="Button1" runat="server" text="Validate"></asp:Button></td>
                <td></td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td valign="top">
            <aspSample:CustomValidationSummaryRender
              id="ValidationSummary1" 
              runat="server" 
              DisplayMode="BulletList" 
              HeaderText="You must enter a value in the following fields:" />
          </td>
        </tr>
      </table>

        </form>
    </body>
</html>
<!-- </Snippet1> -->
