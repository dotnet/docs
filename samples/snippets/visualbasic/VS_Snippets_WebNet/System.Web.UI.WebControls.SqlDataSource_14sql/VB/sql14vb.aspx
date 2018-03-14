<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

            <asp:DropDownList
                id="DropDownList1"
                runat="server"
                DataTextField="LastName"
                DataSourceID="SqlDataSource1" />

            <asp:SqlDataSource
                id="SqlDataSource1"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
                SelectCommandType = "StoredProcedure"
                SelectCommand="sp_lastnames">
            </asp:SqlDataSource>

            <!--
                The sp_lastnames stored procedure is
                CREATE PROCEDURE sp_lastnames AS
                   SELECT LastName FROM Employees
                GO
            -->

        </form>
    </body>
</html>
<!-- </Snippet1> -->