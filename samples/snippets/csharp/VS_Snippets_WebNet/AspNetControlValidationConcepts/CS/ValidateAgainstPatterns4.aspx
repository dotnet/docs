<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Against Patterns for ASP.NET Server Controls</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <!--<Snippet4>-->
     ZIP: <asp:TextBox id="txtZIP" runat="SERVER"></asp:TextBox>
          <asp:RegularExpressionValidator 
            id="txtZIP_validation" runat="SERVER" 
            ControlToValidate="txtZIP" 
            ErrorMessage="Enter a valid US ZIP code."
            ValidationExpression="\d{5}(-\d{4})?">
          </asp:RegularExpressionValidator>
     <!--</Snippet4>-->
     
     <br /> <br />
     <asp:Button id="Button1" runat="server" Text="Submit"/>
    </div>
    </form>
</body>
</html>
