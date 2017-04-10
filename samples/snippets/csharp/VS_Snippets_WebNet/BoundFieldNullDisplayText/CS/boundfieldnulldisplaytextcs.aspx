<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>BoundField NullDisplayText Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>BoundField NullDisplayText Example</h3>

      <asp:gridview id="DiscountsGridView" 
        datasourceid="DiscountsSqlDataSource" 
        autogeneratecolumns="false"
        runat="server">
                
        <columns>
                
          <asp:boundfield datafield="discounttype"
            nulldisplaytext="No Data"
            headertext="Discount Type"/>
                  
          <asp:boundfield datafield="stor_id"
            nulldisplaytext="No Data"
            headertext="Store ID"/> 
                    
          <asp:boundfield datafield="lowqty"
            nulldisplaytext="No Data"
            headertext="Low Quantity"/>
                    
          <asp:boundfield datafield="highqty"
            nulldisplaytext="No Data"
            headertext="High Quantity"/>
                    
          <asp:boundfield datafield="discount"
            nulldisplaytext="No Data"
            dataformatstring="{0:F4}%" 
            itemstyle-horizontalalign="Right" 
            headertext="Discount"/>     
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Pubs sample database.                        -->
      <asp:sqldatasource id="DiscountsSqlDataSource"  
        selectcommand="SELECT [discounttype], [stor_id], [lowqty], [highqty], [discount] FROM [discounts]"
        connectionstring="<%$ ConnectionStrings:PubsConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->