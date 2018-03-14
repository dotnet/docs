<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>CustomValidator ServerValidate Example</title>
<script runat="server">

      Sub ValidateBtn_OnClick(sender As Object, e As EventArgs) 

         ' Display whether the page passed validation.
         If Page.IsValid Then 

            Message.Text = "Page is valid."

         Else 

            Message.Text = "Page is not valid!"

         End If

      End Sub

      Sub ServerValidation(source As Object, args As ServerValidateEventArgs)

         Try 

            ' Test whether the value entered into the text box is even.
            Dim num As Integer = Integer.Parse(args.Value)
            args.IsValid = ((num mod 2) = 0)
 
         Catch ex As Exception
         
            args.IsValid = false

         End Try

      End Sub

      Sub Page_Load(sende As object, e As EventArgs)

         ' Manually register the event-handling method for the  
         ' ServerValidate event of the CustomValidator control.
         AddHandler CustomValidator1.ServerValidate, _
             AddressOf ServerValidation

      End Sub

   </script>    

</head>
<body>

   <form id="form1" runat="server">
  
      <h3>CustomValidator ServerValidate Example</h3>

      <asp:Label id="Message"
           Text="Enter an even number:" 
           Font-Names="Verdana" 
           Font-Size="10pt" 
           runat="server"
           AssociatedControlID="Text1" />

      <br />

      <asp:TextBox id="Text1" 
           runat="server" />
    
      &nbsp;&nbsp;

      <asp:CustomValidator id="CustomValidator1"
           ControlToValidate="Text1"
           Display="Static"
           ErrorMessage="Not an even number!"
           ForeColor="green"
           Font-Names="verdana" 
           Font-Size="10pt"
           runat="server"/>

      <br />
 
      <asp:Button id="Button1"
           Text="Validate" 
           OnClick="ValidateBtn_OnClick" 
           runat="server"/>

   </form>
  
</body>
</html>

<!-- </Snippet1> -->