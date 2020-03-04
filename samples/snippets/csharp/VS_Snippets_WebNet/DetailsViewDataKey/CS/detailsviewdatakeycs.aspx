<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomerDetailView_ItemUpdated(Object sender, 
    DetailsViewUpdatedEventArgs e)
  {
  
    // Create a dictionary that contains the key fields and values using
    // the AllValues method of the DataKey object contained in the DataKey 
    // property.
    IOrderedDictionary keyList = CustomerDetailView.DataKey.Values;

    // Get the ArrayList objects that represent the key fields and values.
    ArrayList keys = (ArrayList)keyList.Keys;
    ArrayList values = (ArrayList)keyList.Values;

    // Get the key field and value for the current record. 
    String keyField = keys[0].ToString();
    String keyValue = values[0].ToString();
    
    // Log the update operation using the key field and value.
    LogUpdate(keyField, keyValue);

  }

  void LogUpdate(String keyField, String keyValue)
  {
    // Insert code to log the update operation.
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView DataKey Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView DataKey Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          autogenerateeditbutton="true" 
          allowpaging="true"
          onitemupdated="CustomerDetailView_ItemUpdated" 
          runat="server">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
                    
        </asp:detailsview>
        
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
            [Address], [City], [PostalCode], [Country] From [Customers]"
          UpdateCommand="UPDATE [Customers] SET 
            [CompanyName] = @CompanyName, 
            [Address] = @Address, [City] = @City,
            [PostalCode] = @PostalCode, [Country] = @Country
            WHERE [CustomerID] = @CustomerID">
        </asp:SqlDataSource>
    </form>
  </body>
</html>

<!-- </Snippet1> -->