<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>CustomValidator ServerValidate Example</title>
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

      void Page_Load(object sender, EventArgs e)
      {

         // Manually register the event-handling method for the  
         // ServerValidate event of the CustomValidator control.
         CustomValidator1.ServerValidate += 
             new ServerValidateEventHandler(this.ServerValidation);

      }

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
           AssociatedControlID="Text1"/>

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