<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>HyperLinkField DataBinding Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>HyperLinkField DataBinding Example</h3>
                    
      <!-- Populate the Columns collection declaratively. -->
      <!-- Bind the CompanyName and HomePage fields from the   -->
      <!-- Northwind database to the caption and URL of the    -->
      <!-- hyperlinks in the HyperLinkField field column. Note -->
      <!-- that the URLs specified in the Northwind database   -->
      <!-- might not be valid URLs.                            -->
      <asp:gridview id="SuppliersGridView" 
        datasourceid="SuppliersSqlDataSource" 
        autogeneratecolumns="false"
        runat="server">
                
        <columns>
                
          <asp:hyperlinkfield datatextfield="CompanyName"
            datanavigateurlfields="HomePage"          
            headertext="Company Name"
            target="_blank" />
          <asp:boundfield datafield="City" 
            headertext="City"/>
                 
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Northwind sample database.                   -->
      <asp:sqldatasource id="SuppliersSqlDataSource"  
        selectcommand="SELECT [SupplierID], [CompanyName], [City], [HomePage] FROM [Suppliers]"
        connectionstring="server=localhost;database=northwind;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->