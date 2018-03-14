<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<html>
<head>

   <script runat="server">

      void ValidateBtn_OnClick(object sender, EventArgs e) 
      { 
         // Display whether the page passed validation.
         if (Page.IsValid) 
         {
            Message.Text = "Page is valid.";
         }

         else 
         {
            Message.Text = "Page is not valid!";
         }
      }

      void ServerValidation(object source, ServerValidateEventArgs args)
      {
         try 
         {
            // Test whether the value entered into the text box is even.
            int i = int.Parse(args.Value);
            args.IsValid = ((i%2) == 0);
         }

         catch(Exception ex)
         {
            args.IsValid = false;
         }
      }
       
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
