<%-- <Snippet1> --%>
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Northwind Employees</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                    ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:TemplateField HeaderText="ReportsTo" SortExpression="ReportsTo">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False" DataSourceID="SqlDataSource2"
                            DataTextField="Name" DataValueField="EmployeeID" SelectedValue='<%# Eval("ReportsTo") %>' AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="">(none)</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="Name" DataValueField="EmployeeID" SelectedValue='<%# Bind("ReportsTo") %>' AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="">(none)</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [ReportsTo] FROM [Employees]"
            UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [ReportsTo] = @ReportsTo WHERE [EmployeeID] = @EmployeeID">
            <UpdateParameters>
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="ReportsTo" Type="Int32" />
                <asp:Parameter Name="EmployeeID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            SelectCommand="SELECT EmployeeID, LastName + ', ' + FirstName As Name From Employees">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>
