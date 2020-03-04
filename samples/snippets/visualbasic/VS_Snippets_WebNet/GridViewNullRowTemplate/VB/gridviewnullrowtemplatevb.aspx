<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView EmptyDataTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView EmptyDataTemplate Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        runat="server">
        
        <emptydatarowstyle backcolor="LightBlue"
          forecolor="Red"/>
                    
        <emptydatatemplate>
                
          <asp:image id="NoDataImage"
            imageurl="~/images/Image.jpg"
            alternatetext="No Image" 
            runat="server"/>
                        
            No Data Found.  
                
        </emptydatatemplate> 
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file. The following query        -->
      <!-- returns an empty data source to demonstrate the      -->
      <!-- empty row.                                           -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers] Where CustomerID='NoID'"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->