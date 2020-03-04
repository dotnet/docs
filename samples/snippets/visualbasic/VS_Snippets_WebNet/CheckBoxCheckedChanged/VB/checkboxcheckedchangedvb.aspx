<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CheckBox CheckedChanged Example</title>
<script runat="server">
 
      Sub Check_Clicked(sender As Object, e As EventArgs) 

         ' Calculate the subtotal and display the result in currency format.
         ' Include tax if the check box is selected.
         Message.Text = CalculateTotal(checkbox1.Checked).ToString("c")

      End Sub

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Display the subtotal without tax when the page is first loaded.
         If Not IsPostBack Then

            ' Calculate the subtotal and display the result in currency format.
            Message.Text = CalculateTotal(false).ToString("c")

         End If

      End Sub

      Function CalculateTotal(Taxable As Boolean) As Double 

         ' Calculate the subtotal for the example.
         Dim Result As Double = 1.99 + 2.99 + 3.99

         ' Add tax, if applicable.
         If(Taxable)

            Result += Result * 0.086
         
         End If

         Return Result 

      End Function
 
   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">
 
      <h3>CheckBox CheckedChanged Example</h3>

      Select whether to include tax in the subtotal.

      <br /><br />

      <table border="1" cellpadding="5">

         <tr>

            <th colspan="2">

               Shopping cart

            </th>

         </tr>

         <tr>

            <td>

               Item 1

            </td>

            <td>

               $1.99

            </td>

         </tr>

         <tr>

            <td>

               Item 2

            </td>

            <td>

               $2.99

            </td>

         </tr>

         <tr>

            <td>

               Item 3

            </td>

            <td>

               $3.99

            </td>

         </tr>

         <tr>

            <td>

               <b>Subtotal</b>

            </td>

            <td>

               <asp:Label id="Message" runat="server"/>

            </td>

         </tr>

         <tr>

            <td colspan="2">

               <asp:CheckBox id="checkbox1" runat="server"
                    AutoPostBack="True"
                    Text="Include 8.6% sales tax"
                    TextAlign="Right"
                    OnCheckedChanged="Check_Clicked"/>

            </td>

         </tr>

      </table>
                   
   </form>
         
</body>

</html>

<!-- </Snippet1> -->