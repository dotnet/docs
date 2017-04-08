<%--<Snippet50>--%>
<%@ Page Language="VB" %>
<%@ Register Tagprefix="aspSample" Namespace="Samples.AspNet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

            <asp:treeview
                id="TreeView1"
                runat="server"
                datasourceid="FileSystemDataSource1" />            

            <aspSample:filesystemdatasource
                id = "FileSystemDataSource1"
                runat = "server" />            

        </form>
    </body>
</html>
<%--</Snippet50>--%>