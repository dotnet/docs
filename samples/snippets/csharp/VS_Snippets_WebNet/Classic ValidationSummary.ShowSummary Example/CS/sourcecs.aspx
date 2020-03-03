<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ValidationSummary Sample</title>
</head>
 <body>
 
    <h3>ValidationSummary Sample</h3>
    <br />
 
    <form id="form1" runat="server">
 
       <table cellpadding="10">
          <tr>
             <td>
                <table style="background-color:#eeeeee; padding:10">
 
                   <tr>
                      <td colspan="3">
                         <b>Credit Card Information</b>
                      </td>
                   </tr>
                   <tr>
                      <td align="right">
                         Card Type:
                      </td>
                      <td>
                         <asp:RadioButtonList id="RadioButtonList1" 
                              RepeatLayout="Flow"
                               runat="server">
                            <asp:ListItem>MasterCard</asp:ListItem>
                            <asp:ListItem>Visa</asp:ListItem>
                         </asp:RadioButtonList>
                      </td>
                      <td align="center" rowspan="1">
                         <asp:RequiredFieldValidator 
                              id="RequiredFieldValidator1"
                              ControlToValidate="RadioButtonList1" 
                              ErrorMessage="Card Type. "
                              Display="Static"
                              InitialValue="" Width="100%" runat="server">
                            *
                         </asp:RequiredFieldValidator>
                      </td>
                   </tr>
                   <tr>
                      <td align="right">
                         Card Number:
                      </td>
                      <td>
                         <asp:TextBox id="TextBox1" runat="server" />
                      </td>
                      <td>
                         <asp:RequiredFieldValidator 
                              id="RequiredFieldValidator2"
                              ControlToValidate="TextBox1" 
                              ErrorMessage="Card Number. "
                              Display="Static"
                              Width="100%" runat="server">
                            *
                         </asp:RequiredFieldValidator>
                      </td>
                   </tr>
 
                   <tr>
                      <td></td>
                      <td>
                         <asp:Button 
                              id="Button1" 
                              text="Validate" 
                              runat="server" />
                      </td>
                      <td></td>
                   </tr>
                </table>
             </td>
             <td valign="top">
                <table cellpadding="20">
                   <tr>
                      <td>
                         <asp:ValidationSummary 
                              id="valSum" 
                              DisplayMode="BulletList" 
                              runat="server"
                              ShowSummary="True"
                              HeaderText="You must enter a value in the following fields:"
                              Font-Names="verdana" 
                              Font-Size="12"/>
                      </td>
                   </tr>
                </table>
             </td>
          </tr>
       </table>
 
    </form>
 
 </body>
 </html>
    
<!--</Snippet1>-->
