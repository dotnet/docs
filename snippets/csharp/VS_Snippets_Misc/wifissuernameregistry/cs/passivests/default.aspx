<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="PassiveSTS._Default" ValidateRequest="false" %>
<%@ OutputCache Location="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Windows Identity Foundation - Passive STS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        You have been redirected from relying party to this STS site. You have not been authenticated yet. Make sure that Windows Authentication is enabled and all other Authentication disabled in your IIS configuration for this STS web application 
    </div>
    </form>
</body>
</html>
