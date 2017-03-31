<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CommandField Example</title>
</head>
<body>
    <form id="form1" runat="server">
      
      <h3>CommandField Example</h3>

      <asp:detailsview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneraterows="false"
        datakeynames="CustomerID"  
        allowpaging="true" 
        runat="server">
        
        <fields>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID" />
          <asp:boundfield datafield="CompanyName"
            headertext="CompanyName"/>
          <asp:boundfield datafield="Address"
            headertext="Address"/>
          <asp:boundfield datafield="City"
            headertext="City"/>
          <asp:boundfield datafield="PostalCode"
            headertext="ZIP Code"/>
          <asp:boundfield datafield="Country"
            headertext="Country"/>
          <asp:commandfield showinsertbutton="true"
            buttontype="Image"
            insertimageurl="~\Images\InsertButton.jpg"
            newimageurl="~\Images\AddButton.jpg"
            cancelimageurl="~\Images\CancelButton.jpg"  
            showheader="true"
            headertext="Add Store"/>
        </fields>
        
      </asp:detailsview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        insertcommand="Insert Into [Customers]([CustomerID], [CompanyName], [City], [PostalCode], [Country]) Values (@CustomerID, @CompanyName, @City, @PostalCode, @Country)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->