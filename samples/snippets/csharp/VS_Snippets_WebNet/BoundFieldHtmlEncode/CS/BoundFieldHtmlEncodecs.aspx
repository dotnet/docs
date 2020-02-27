<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>BoundField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>BoundField Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        allowpaging="true" 
        runat="server">
         
        <columns>
          <asp:boundfield datafield="CustomerID"
            readonly="true"      
            headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName"
            htmlencode="false"
            headertext="Customer Name"/>
          <asp:boundfield datafield="Address"
            htmlencode="false"
            headertext="Address"/>
          <asp:boundfield datafield="City"
            htmlencode="false"
            headertext="City"/>
          <asp:boundfield datafield="PostalCode"
            htmlencode="false"
            headertext="ZIP Code"/>
          <asp:boundfield datafield="Country"
            htmlencode="false"
            headertext="Country"/>
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->