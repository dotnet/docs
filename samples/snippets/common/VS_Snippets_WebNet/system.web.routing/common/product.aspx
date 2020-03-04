<%--<Snippet103>--%>
<%@ Page %>

<!doctype html public "-//w3c//dtd xhtml 1.0 transitional//en" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Product Page</h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksLTConnectionString %>" 
            SelectCommand="SELECT SalesLT.Product.ProductID, 
                SalesLT.Product.Name, 
                SalesLT.ProductDescription.Description 
                FROM SalesLT.Product 
                INNER JOIN SalesLT.ProductModel 
                ON SalesLT.Product.ProductModelID = 
                SalesLT.ProductModel.ProductModelID 
                INNER JOIN SalesLT.ProductModelProductDescription 
                ON SalesLT.ProductModel.ProductModelID = 
                SalesLT.ProductModelProductDescription.ProductModelID 
                INNER JOIN SalesLT.ProductDescription 
                ON SalesLT.ProductModelProductDescription.ProductDescriptionID = 
                SalesLT.ProductDescription.ProductDescriptionID 
                WHERE (SalesLT.ProductModelProductDescription.Culture = @culture) 
                AND (SalesLT.Product.Name = @productname)">
            <SelectParameters>
                <asp:RouteParameter DefaultValue="en" Name="culture" RouteKey="culture" />
                <asp:RouteParameter Name="productname" RouteKey="productname" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" 
            DataSourceID="SqlDataSource1">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
<%--</Snippet103>--%>