<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

            <asp:SqlDataSource
                id="SqlDataSource1"
                runat="server"
                DataSourceMode="DataSet"
                ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
                EnableCaching="True"
                CacheDuration="20"
                SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees">
            </asp:SqlDataSource>

            <asp:GridView
                id="GridView1"
                runat="server"
                AutoGenerateColumns="False"
                DataSourceID="SqlDataSource1">
                <columns>
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                    <asp:BoundField HeaderText="Title" DataField="Title" />
                </columns>
            </asp:GridView>

        </form>
    </body>
</html>
<!-- </Snippet1> -->