<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="True" %>

<html>
<head>

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
               args.IsValid = ((num Mod 2) = 0)
           Catch ex As Exception
               args.IsValid = False
           End Try
       End Sub

   </script>      

</head>
<body>

   <form id="Form1" runat="server">
  
      <h3>CustomValidator ServerValidate Example</h3>

      <asp:Label id="Message"  
           Text="Enter an even number:" 
           Font-Name="Verdana" 
           Font-Size="10pt" 
           runat="server"/>

      <p>

      <asp:TextBox id="Text1" 
           runat="server" />
    
      &nbsp;&nbsp;

      <asp:CustomValidator id="CustomValidator1"
           ControlToValidate="Text1"
           ClientValidationFunction="ClientValidate"
           OnServerValidate="ServerValidation"
           Display="Static"
           ErrorMessage="Not an even number!"
           ForeColor="green"
           Font-Name="verdana" 
           Font-Size="10pt"
           runat="server"/>

      <p>
 
      <asp:Button id="Button1"
           Text="Validate" 
           OnClick="ValidateBtn_OnClick" 
           runat="server"/>

   </form>
  
</body>
</html>

<script language="javascript">
   function ClientValidate(source, arguments)
   {
        if (arguments.Value % 2 == 0 ){
            arguments.IsValid = true;
        } else {
            arguments.IsValid = false;
        }
   }
</script>
<!-- </Snippet1> -->
