<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>HyperLinkField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>HyperLinkField Example</h3>
                    
      <!-- Populate the Columns collection declaratively. -->
      <!-- Set the HyperLinkField field column to a static     -->
      <!-- caption and URL.                                    -->
      <asp:gridview id="OrdersGridView" 
        datasourceid="OrdersSqlDataSource" 
        autogeneratecolumns="false"
        runat="server">
                
        <columns>
                
          <asp:boundfield datafield="OrderID" 
            headertext="OrderID"/>
          <asp:boundfield datafield="CustomerID" 
            headertext="Customer ID"/>
          <asp:boundfield datafield="OrderDate" 
            headertext="Order Date"
            dataformatstring="{0:d}" />
          <asp:hyperlinkfield text="Details..."
            navigateurl="~\details.aspx"            
            headertext="Order Details"
            target="_blank" />
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Northwind sample database.                   -->
      <asp:sqldatasource id="OrdersSqlDataSource"  
        selectcommand="SELECT [OrderID], [CustomerID], [OrderDate] FROM [Orders]"
        connectionstring="server=localhost;database=northwind;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->