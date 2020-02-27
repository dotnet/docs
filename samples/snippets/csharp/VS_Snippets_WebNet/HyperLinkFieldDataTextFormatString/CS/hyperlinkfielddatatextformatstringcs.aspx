<!-- <Snippet1> -->

<%@ Page language="C#" %>

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
      <!-- The UnitPrice field values are bound to the         -->
      <!-- captions of the hyperlinks in the HyperLinkField    -->
      <!-- field column, formatted as currency. The ProductID  -->
      <!-- field values are bound to the navigate URLs of the  -->
      <!-- hyperlinks. However, instead of being the actual    -->
      <!-- URL values, the product ID is passed to the linked  -->
      <!-- page as a parameter in the URL specified by the     -->
      <!-- DataNavigateUrlFormatString property.               -->
      <asp:gridview id="OrdersGridView" 
        datasourceid="OrdersSqlDataSource" 
        autogeneratecolumns="false"
        runat="server">
                
        <columns>
                
          <asp:boundfield datafield="OrderID" 
            headertext="Order ID"/>
          <asp:boundfield datafield="ProductID" 
            headertext="Product ID"/>
          <asp:hyperlinkfield datatextfield="UnitPrice"
            datatextformatstring="{0:c}"
            datanavigateurlfields="ProductID"
            datanavigateurlformatstring="~\details.aspx?ProductID={0}"          
            headertext="Price"
            target="_blank" />
          <asp:boundfield datafield="Quantity" 
            headertext="Quantity"/>
                 
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Northwind sample database.                   -->
      <asp:sqldatasource id="OrdersSqlDataSource"  
        selectcommand="SELECT [OrderID], [ProductID], [UnitPrice], [Quantity] FROM [Order Details]"
        connectionstring="server=localhost;database=northwind;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->