<%@ Page Language="C#" debug="true" %>
<%@ register tagprefix="acme" tagname="uc" src="dep1cs.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        The date and time on the page is: <%= DateTime.Now %><br />
        <acme:uc id="Uc1" runat="server"/>
    </div>
    </form>
</body>
</html>
