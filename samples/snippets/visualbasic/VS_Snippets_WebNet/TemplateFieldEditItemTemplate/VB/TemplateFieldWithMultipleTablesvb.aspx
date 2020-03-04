<!-- <Snippet2> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Example EditItemTemplate Using Related Tables</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- This example uses Microsoft SQL Server and connects -->
    <!-- to the Northwind sample database.                   -->
        <asp:SqlDataSource ID="SqlDataSource2" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]" 
            ProviderName="System.Data.SqlClient">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="SELECT P.ProductID, P.ProductName, P.CategoryID, C.CategoryName FROM Products AS P INNER JOIN Categories AS C ON P.CategoryID = C.CategoryID"
            UpdateCommand="UPDATE Products SET ProductName = @ProductName, CategoryID = @CategoryID WHERE (ProductID = @ProductID)"
            ProviderName="System.Data.SqlClient">
            <UpdateParameters>
                <asp:Parameter Name="ProductName" />
                <asp:Parameter Name="CategoryID" />
                <asp:Parameter Name="ProductID" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    <asp:GridView ID="GridView1" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="ProductID"
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ProductName" 
                HeaderText="ProductName" 
                SortExpression="ProductName" />
            <asp:TemplateField HeaderText="CategoryName" SortExpression="CategoryName">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" 
                        runat="server" 
                        DataSourceID="SqlDataSource2"
                        DataTextField="CategoryName" 
                        DataValueField="CategoryID" 
                        SelectedValue='<%# Bind("CategoryID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>

<!-- </Snippet2> -->