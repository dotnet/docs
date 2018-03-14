<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>CompareValidator ValueToCompare Example</title>
<script runat="server">
 
      Sub Button_Click(sender As Object, e As EventArgs) 

         Dim rand_number As New Random()

         Compare1.ValueToCompare = rand_number.Next(1, 10).ToString()
         Compare1.Validate()
 
         If Page.IsValid Then 
         
            lblOutput.Text = "You guessed correctly!!"
         
         Else 
         
            lblOutput.Text = "You guessed poorly"
         
         End If

         lblOutput.Text &= "<br /><br />" & "The number is: " & Compare1.ValueToCompare

      End Sub
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>CompareValidator ValueToCompare Example</h3>

      <h5>Pick a number between 1 and 10:</h5>
      <asp:TextBox id="TextBox1" 
           runat="server"/>

      <br /><br />

      <asp:Button id="Button1"
           Text="Submit"
           OnClick="Button_Click"
           runat="server"/>

      <br /><br />
       
      <asp:CompareValidator id="Compare1" 
           ControlToValidate="TextBox1"
           ValueToCompare="0"  
           Type="Integer"
           EnableClientScript="False" 
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
