<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Columns Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView Columns Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        runat="server">
        
        <columns>
          <asp:boundfield datafield="CustomerID" headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName" headertext="Company Name"/>
          <asp:boundfield datafield="Address" headertext="Address"/>
          <asp:boundfield datafield="City" headertext="City"/>
          <asp:boundfield datafield="PostalCode" headertext="Postal Code"/>
          <asp:boundfield datafield="Country" headertext="Country"/>
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
        
    </form>
  </body>
</html>

<!-- </Snippet1> -->