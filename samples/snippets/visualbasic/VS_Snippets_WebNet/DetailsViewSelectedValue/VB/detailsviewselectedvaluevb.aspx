<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub CustomerDetailView_ItemUpdated(ByVal sender As Object, ByVal e As DetailsViewUpdatedEventArgs)
        ' Log the update operation using the key value contained
        ' in the SelectedValue property.
        Dim keyValue As String = CustomerDetailView.SelectedValue.ToString()
        LogUpdate(keyValue)

    End Sub

    Sub LogUpdate(ByVal keyValue As String)
        ' Insert code to log the update operation.
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
            DetailsView SelectedValue Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            DetailsView SelectedValue Example</h3>
        <asp:DetailsView ID="CustomerDetailView" DataSourceID="DetailsViewSource" DataKeyNames="CustomerID"
            AutoGenerateRows="true" AutoGenerateEditButton="true" AllowPaging="true" OnItemUpdated="CustomerDetailView_ItemUpdated"
            runat="server">
            <FieldHeaderStyle BackColor="Navy" ForeColor="White" />
        </asp:DetailsView>
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
            InsertCommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
            SelectCommand="Select [CustomerID], [CompanyName], 
              [Address], [City], [PostalCode], [Country] 
              From [Customers]"
            UpdateCommand="UPDATE [Customers] SET [CompanyName] = @CompanyName, 
            [Address] = @Address, [City] = @City,
            [PostalCode] = @PostalCode, [Country] = @Country
            WHERE [CustomerID] = @CustomerID"></asp:SqlDataSource>
    </form>
</body>
</html>
<!-- </Snippet1> -->
