<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub CustomerDetailView_ItemUpdated(ByVal sender As Object, _
        ByVal e As DetailsViewUpdatedEventArgs)
    
        ' Create a dictionary that contains the key fields and values 
        ' using the AllValues method of the DataKey object contained 
        ' in the DataKey property.
        
        Dim keyList As IOrderedDictionary = _
            CustomerDetailsView.DataKey.Values

        ' Get the ArrayList objects that represent the key fields 
        ' and values.
        Dim keys As ArrayList = CType(keyList.Keys, ArrayList)
        Dim values As ArrayList = CType(keyList.Values, ArrayList)

        ' Get the key field and value for the current record. 
        Dim keyField As String = keys(0).ToString()
        Dim keyValue As String = values(0).ToString()
    
        ' Log the update operation using the key field and value.
        LogUpdate(keyField, keyValue)

    End Sub

    Sub LogUpdate(ByVal keyField As String, ByVal keyValue As String)
  
        ' Insert code to log the update operation.
  
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
            DetailsView DataKey Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            DetailsView DataKey Example</h3>
        <asp:DetailsView ID="CustomerDetailsView" 
          DataSourceID="DetailsViewSource" 
          DataKeyNames="CustomerID"
          AutoGenerateRows="true" 
          AutoGenerateEditButton="true" 
          AllowPaging="true" 
          OnItemUpdated="CustomerDetailView_ItemUpdated"
          runat="server">
          
          <HeaderStyle BackColor="Navy" ForeColor="White" />
        </asp:DetailsView>

        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
          InsertCommand="INSERT INTO [Customers]([CustomerID],
            [CompanyName], [Address], [City], [PostalCode], [Country]) 
            VALUES (@CustomerID, @CompanyName, @Address, @City, 
            @PostalCode, @Country)"
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
