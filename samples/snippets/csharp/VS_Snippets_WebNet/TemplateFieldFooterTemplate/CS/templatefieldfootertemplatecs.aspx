<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  // Create a variable to store the order total.
  private Decimal orderTotal = 0.0M;

  void OrderGridView_RowCreated(Object sender, GridViewRowEventArgs e)
  {
    
    if (e.Row.RowType == DataControlRowType.Footer)
    {
      
      // Get the OrderTotalLabel Label control in the footer row.
      Label total = (Label)e.Row.FindControl("OrderTotalLabel");
      
      // Display the grand total of the order formatted as currency.
      if (total != null)
      {
        total.Text = orderTotal.ToString("c");
      }
      
    }
    
  }
  
  void OrderGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
  {
    
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      
      // Get the cell that contains the item total.
      TableCell cell = e.Row.Cells[2];
      
      // Get the DataBoundLiteralControl control that contains the 
      // data-bound value.
      DataBoundLiteralControl boundControl = (DataBoundLiteralControl)cell.Controls[0];
      
      // Remove the '$' character so that the type converter works properly.
      String itemTotal = boundControl.Text.Replace("$",  "");
      
      // Add the total for an item (row) to the order total.
      orderTotal += Convert.ToDecimal(itemTotal);
      
    }
    
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TemplateField FooterTemplate Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>TemplateField FooterTemplate Example</h3>

      <!-- Populate the Columns collection declaratively. -->
      <!-- Create a custom TemplateField column that uses      -->
      <!-- two Label controls to display an author's first and -->
      <!-- last name in the same column.                       -->
      <asp:gridview id="OrderGridView" 
        datasourceid="OrderSqlDataSource" 
        autogeneratecolumns="False" 
        showfooter="true"
        onrowcreated="OrderGridView_RowCreated"
        onrowdatabound="OrderGridView_RowDataBound"   
        runat="server">
                
        <columns>
        
          <asp:boundfield datafield="UnitPrice"
            itemstyle-horizontalalign="Right"
            headertext="Unit Price" 
            dataformatstring="{0:c}"/>
                  
          <asp:boundfield datafield="Quantity"
            itemstyle-horizontalalign="Right"
            headertext="Quantity"/>
                           
          <asp:templatefield headertext="Total"
            itemstyle-horizontalalign="Right"
            footerstyle-horizontalalign="Right"
            footerstyle-backcolor="Blue"
            footerstyle-forecolor="White">
            <itemtemplate>
              <%#Eval("Total", "{0:c}") %>
            </itemtemplate>
            <footertemplate>
              <asp:label id="OrderTotalLabel"
                runat="server"/>
            </footertemplate>
          </asp:templatefield>
                
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects -->
      <!-- to the Northwind sample database.                   -->
      <asp:sqldatasource id="OrderSqlDataSource"  
        selectcommand="SELECT [OrderID], [UnitPrice], [Quantity], [UnitPrice]*[Quantity] As [Total] FROM [order details] WHERE [OrderID]=10248"
        connectionstring="server=localhost;database=northwind;integrated security=SSPI"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->