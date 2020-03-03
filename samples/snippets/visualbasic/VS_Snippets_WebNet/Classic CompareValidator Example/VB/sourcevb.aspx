<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>CompareValidator Example</title>
<script runat="server">
 
      Sub Button_Click(sender As Object, e As EventArgs) 
 
         If Page.IsValid Then 
         
            lblOutput.Text = "Result: Valid!"
         
         Else 
         
            lblOutput.Text = "Result: Not valid!"
         
         End If

      End Sub
 
      Sub Operator_Index_Changed(sender As Object, e As EventArgs) 

         Compare1.Operator = CType(ListOperator.SelectedIndex, ValidationCompareOperator)
         Compare1.Validate()

      End Sub

      Sub Type_Index_Changed(sender As Object, e As EventArgs) 

         Compare1.Type = CType(ListType.SelectedIndex, ValidationDataType)
         Compare1.Validate()

      End Sub
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>CompareValidator Example</h3>
      <br />
      Enter a value in each textbox. Select a comparison operator<br />
      and data type. Click "Validate" to compare values.
 
      <table style="background-color:#eeeeee; padding:10">

         <tr valign="top">

            <td>

               <h5>String 1:</h5>
               <asp:TextBox id="TextBox1" 
                    runat="server"/>

            </td>

            <td>

               <h5>Comparison Operator:</h5>
 
               <asp:ListBox id="ListOperator" 
                    OnSelectedIndexChanged="Operator_Index_Changed" 
                    runat="server">

                  <asp:ListItem Selected="True" Value="Equal">Equal</asp:ListItem>
                  <asp:ListItem Value="NotEqual">NotEqual</asp:ListItem>
                  <asp:ListItem Value="GreaterThan">GreaterThan</asp:ListItem>
                  <asp:ListItem Value="GreaterThanEqual">GreaterThanEqual</asp:ListItem>
                  <asp:ListItem Value="LessThan">LessThan</asp:ListItem>
                  <asp:ListItem Value="LessThanEqual">LessThanEqual</asp:ListItem>
                  <asp:ListItem Value="DataTypeCheck">DataTypeCheck</asp:ListItem>

               </asp:ListBox>

            </td>

            <td>

               <h5>String 2:</h5>
               <asp:TextBox id="TextBox2" 
                    runat="server"/>
               <br />
               <asp:Button id="Button1"
                    Text="Validate"  
                    OnClick="Button_Click" 
                    runat="server"/>

            </td>
         </tr>

         <tr>
            <td colspan="3" align="center">

               <h5>Data Type:</h5>

               <asp:ListBox id="ListType" 
                    OnSelectedIndexChanged="Type_Index_Changed" 
                    runat="server">

                  <asp:ListItem Selected="true" Value="String" >String</asp:ListItem>
                  <asp:ListItem Value="Integer" >Integer</asp:ListItem>
                  <asp:ListItem Value="Double" >Double</asp:ListItem>
                  <asp:ListItem Value="Date" >Date</asp:ListItem>
                  <asp:ListItem Value="Currency" >Currency</asp:ListItem>

               </asp:ListBox>
            </td>
         </tr>
      </table>
 
      <asp:CompareValidator id="Compare1" 
           ControlToValidate="TextBox1" 
           ControlToCompare="TextBox2"
           EnableClientScript="False" 
           Type="String" 
           runat="server"/>
 
      <br />
       
      <asp:Label id="lblOutput" 
           Font-Names="verdana" 
           Font-Size="10pt" 
           runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
