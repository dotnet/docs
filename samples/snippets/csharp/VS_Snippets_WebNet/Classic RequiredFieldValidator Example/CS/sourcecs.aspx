<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>RequiredField Validator Example</title>
<script runat="server">
 
      void ValidateBtn_Click(Object sender, EventArgs e) 
      {
 
         if (Page.IsValid) 
         {
            lblOutput.Text = "Required field is filled!";
         }
         else 
         {
            lblOutput.Text = "Required field is empty!";
         }
      }
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>RequiredField Validator Example</h3>
 
      <table style="background-color:#eeeeee; padding:10">
         <tr valign="top">
            <td colspan="3">
               <asp:Label ID="lblOutput" 
                    Text="Fill in the required field below"
                    runat="server"
                    AssociatedControlID="TextBox1"/>
               <br />
            </td>
         </tr>
 
         <tr>
            <td colspan="3">
               <b>Credit Card Information</b>
            </td>
         </tr>
     
         <tr>
            <td align="right">
               Card Number:
            </td>
            <td>
               <asp:TextBox id="TextBox1" 
                    runat="server"/>
            </td>
            <td>
               <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                    ControlToValidate="TextBox1"
                    Display="Static"
                    ErrorMessage="*"
                    runat="server"/> 
            </td>
         </tr>
         <tr>
            <td></td>
            <td>
               <asp:Button id="Button1" 
                    Text="Validate" 
                    OnClick="ValidateBtn_Click" 
                    runat="server"/>
            </td>
            <td></td>
         </tr>
      </table>
 
   </form>
 
</body>
</html>
    
<!--</Snippet1>-->