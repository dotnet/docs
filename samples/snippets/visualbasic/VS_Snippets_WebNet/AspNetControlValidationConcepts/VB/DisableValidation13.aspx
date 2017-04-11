<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Disable Validation for ASP.NET Server Controls</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <!--<Snippet13>-->
      <asp:Button id="Button1" runat="server"
        Text="Cancel" CausesValidation="False">
      </asp:Button>
      <!--</Snippet13>-->
      
    </div>
    </form>
</body>
</html>
