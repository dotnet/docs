<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BaseCompareValidator CanConvert Example</title>
<script runat="server">
 
      Sub Button_Click(sender As Object, e As EventArgs) 
          
         ' Display whether the value of TextBox1 passes validation.  
         If Page.IsValid Then 

            lblOutput.Text = "Validation passed! "

            ' An input control passes validation if the value it is being 
            ' compared to cannot be converted to the data type specified 
            ' by the BaseCompareValidator.Type property. Be sure to use 
            ' validation controls on each input control independently.

            ' Test the values being compared for their data types.
            ValidateType(Page.IsValid)

         Else 

            lblOutput.Text = "Validation failed! "

            ' Test the values being compared for their data types.
            ValidateType(Page.IsValid)

         End If         

      End Sub

      Sub ValidateType(Valid As Boolean)
          
         ' Display an error message if the value of TextBox1 cannot be 
         ' converted to the data type specified by the 
         ' BaseCompareValidator.Type property (in this case an integer).
         If Not BaseCompareValidator.CanConvert(TextBox1.Text, ValidationDataType.Integer) Then

            lblOutput.Text &= "The first value is not an integer. "

         End If

         ' Display an error message if the value of TextBox2 cannot be 
         ' converted to the data type specified by the 
         ' BaseCompareValidator.Type property (in this case an integer).
         If Not BaseCompareValidator.CanConvert(TextBox2.Text, ValidationDataType.Integer) Then
          
            ' An input control passes validation if the value it is being 
            ' compared to cannot be converted to the data type specified 
            ' by the BaseCompareValidator.Type property. 
            ' Display a different message when this scenario occurs.
            If Valid Then

               lblOutput.Text &= "However, the second value is not an integer. "
            
            Else
            
               lblOutput.Text &= "The second value is not an integer. "

            End If

         End If

      End Sub
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>BaseCompareValidator CanConvert Example</h3>
      <p>
      Enter an integer in each text box. <br />
      Click "Validate" to compare the values <br />
      for equality.
      </p>
 
      <table  style="background-color:#eeeeee; padding:10">

         <tr valign="top">

            <td>

               <h5>Value 1:</h5>
               <asp:TextBox id="TextBox1" 
                    runat="server"/>

            </td>


            <td>

               <h5>Value 2:</h5>
               <asp:TextBox id="TextBox2" 
                    runat="server"/>
               <p>
               <asp:Button id="Button1"
                    Text="Validate"  
                    OnClick="Button_Click" 
                    runat="server"/>
                </p>    

            </td>
         </tr>

      </table>
 
      <asp:CompareValidator id="Compare1" 
           ControlToValidate="TextBox1" 
           ControlToCompare="TextBox2"
           EnableClientScript="False" 
           Type="Integer" 
           runat="server"/>
 
      <br />
       
      <asp:Label id="lblOutput" 
           Font-Names="verdana" 
           Font-Size="10pt" 
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
