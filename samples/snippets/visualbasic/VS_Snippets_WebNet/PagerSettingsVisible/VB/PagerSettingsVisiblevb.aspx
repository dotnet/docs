<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles CustomerGridView.RowEditing

    ' Hide the pager row.
    CustomerGridView.PagerSettings.Visible = False
    
  End Sub

  Sub CustomerGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles CustomerGridView.RowCommand
  
    If e.CommandName = "Cancel" Or e.CommandName = "Update" Then
    
      ' Show the pager row.
      CustomerGridView.PagerSettings.Visible = True
      
    End If
      
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>PagerSetting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>PagerSetting Example</h3>
                       
        <asp:gridview id="CustomerGridView"
          datasourceid="CustomerDataSource"
          autogeneratecolumns="true"
          datakeynames="CustomerID"  
          allowpaging="true"
          autogenerateeditbutton="true" 
          runat="server">
          
          <pagersettings mode="NextPreviousFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            nextpagetext="Next"
            previouspagetext="Prev"   
            position="Bottom"/> 
            
        </asp:gridview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="CustomerDataSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          updatecommand="Update [Customers] Set [CompanyName]=@CompanyName, [Address]=@Address, [City]=@City, [PostalCode]=@PostalCode, [Country]=@Country Where [CustomerID]=@CustomerID" 
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->