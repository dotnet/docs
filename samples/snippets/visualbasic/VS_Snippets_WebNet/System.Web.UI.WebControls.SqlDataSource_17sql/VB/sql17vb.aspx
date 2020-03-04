<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

            <p>Show all employees with the following title:
            <asp:DropDownList
                id="DropDownList1"
                runat="server"
                AutoPostBack="True">
                <asp:ListItem Selected="True">Sales Representative</asp:ListItem>
                <asp:ListItem>Sales Manager</asp:ListItem>
                <asp:ListItem>Vice President, Sales</asp:ListItem>
            </asp:DropDownList></p>

            <asp:SqlDataSource
                id="SqlDataSource1"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
                SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees"
                FilterExpression="Title='{0}'">
                <FilterParameters>
                    <asp:ControlParameter Name="Title" ControlId="DropDownList1" PropertyName="SelectedValue"/>
                </FilterParameters>
            </asp:SqlDataSource>

            <p><asp:GridView
                id="GridView1"
                runat="server"
                DataSourceID="SqlDataSource1"
                AutoGenerateColumns="False">
                <columns>
                    <asp:BoundField Visible="False" DataField="EmployeeID" />
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                </columns>
            </asp:GridView></p>

        </form>
    </body>
</html>
<!-- </Snippet1> -->