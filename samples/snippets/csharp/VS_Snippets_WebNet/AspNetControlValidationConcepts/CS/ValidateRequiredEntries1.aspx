<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Required Entries for ASP.NET Server Controls</title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
            
      <!--<Snippet1>-->
      <asp:Textbox id="txtLastName" runat="server"></asp:Textbox>
      <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
        ControlToValidate="txtLastName"
        ErrorMessage="Last name is a required field."
        ForeColor="Red">
      </asp:RequiredFieldValidator>
      <!--</Snippet1>-->
      
      <asp:Button id="submit" runat="server" />
      </div>
    </form>
</body>
</html>
