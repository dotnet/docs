<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CustomValidator - ControlPropertiesValid - C# Example</title>
    <script runat="server">
    void CustomValidator1_ServerValidate(Object source, ServerValidateEventArgs args) 
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
  <form id="Form1" method="post" runat="server">
    <h3>Custom CustomValidator - ControlPropertiesValid - C# Example</h3>
    
    <asp:Label id="Label1" runat="server" Text="Enter an even number:" AssociatedControlID="TextBox1" /><br />
    
    <asp:TextBox id="TextBox1" runat="server" />&nbsp;
    
    <aspSample:CustomCustomValidatorControlPropertiesValid 
      id="Customvalidator1" 
      runat="server" 
      ControlToValidate="TextBox1" 
      Display="Static" 
      ErrorMessage="Not an even number!" 
      OnServerValidate="CustomValidator1_ServerValidate" /><br /><br />
    
    <asp:Button id="Button1" runat="server" Text="Validate" />
  </form>
</body>
</html>
<!-- </Snippet1> -->