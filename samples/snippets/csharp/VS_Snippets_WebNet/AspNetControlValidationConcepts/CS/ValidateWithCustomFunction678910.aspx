<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate with a Custom Function for ASP.NET Server Controls</title>
</head>

<script runat="server">
    
    //<Snippet6>
    protected void ValidationFunctionName(object source, ServerValidateEventArgs args)
    {

    }
    //</Snippet6>
    
    
    //<Snippet7>
    protected void TextValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (args.Value.Length >= 8);
    }
    //</Snippet7>
    
  </script>
  
<!--<Snippet8>-->
<script type="text/javascript">
  function validateLength(oSrc, args){
   args.IsValid = (args.Value.length >= 8);
}
</script>
<!--</Snippet8>-->

<body>
    <form id="form1" runat="server">
    <div>
    
      <!--<Snippet9>-->
      <asp:textbox id="TextBox1" runat="server"></asp:textbox>
      <asp:CustomValidator id="CustomValidator1" runat="server" 
        OnServerValidate="TextValidate" 
        ControlToValidate="TextBox1" 
        ErrorMessage="Text must be 8 or more characters.">
      </asp:CustomValidator>
      <!--</Snippet9>-->

      <!--<Snippet10>-->
      <asp:Textbox id="text1" runat="server" text=""></asp:Textbox>
      <asp:CustomValidator id="CustomValidator2" runat="server" 
        ControlToValidate = "text1"
        ErrorMessage = "You must enter at least 8 characters!"
        ClientValidationFunction="validateLength" >
      </asp:CustomValidator>
      <!--</Snippet10>-->

     <asp:Button id="Button1" runat="server" Text="Submit" CausesValidation="true" />
     </div>
    </form>
</body>
</html>
