<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  ' Create a variable to store the order total.
  Private orderTotal As Decimal = 0.0

  Sub OrderGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' Retrieve the current row.
    Dim row As GridViewRow = e.Row
    
    ' Update the column total if the row being created is
    ' a footer row.
    If row.RowType = DataControlRowType.Footer Then
          
      ' Get the OrderTotalTotal Label control in the footer row.
      Dim total As Label = CType(e.Row.FindControl("OrderTotalLabel"), Label)
      
      ' Display the grand total of the order formatted as currency.
      If (Not total Is Nothing)
      
        total.Text = orderTotal.ToString("c")
      
      End If 
      
    End If
    
  End Sub
  
  Sub OrderGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' Retrieve the current row.
    Dim row As GridViewRow = e.Row
    
    ' Add the field value to the column total if the row being created is
    ' a data row.
    If row.RowType = DataControlRowType.DataRow Then
      
      ' Get the cell that contains the item total.
      Dim cell As TableCell = e.Row.Cells(2)
      
      ' Get the DataBoundLiteralControl control that contains the 
      ' data bound value.
      Dim boundControl As DataBoundLiteralControl = CType(cell.Controls(0), DataBoundLiteralControl)
      
      ' Remove the '$' character for the type converter to work properly.
      Dim itemTotal As String = boundControl.Text.Replace("$",  "")
      
      ' Add the total for an item (row) to the order total.
      orderTotal += Convert.ToDecimal(itemTotal)
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridViewRow RowType Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridViewRow RowType Example</h3>

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