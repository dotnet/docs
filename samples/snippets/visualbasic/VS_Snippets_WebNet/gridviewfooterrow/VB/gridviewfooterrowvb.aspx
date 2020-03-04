<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub CustomersGridView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
      
    ' Get the header row.
    Dim headerRow As GridViewRow = CustomersGridView.HeaderRow
    
    ' Get the footer row.
    Dim footerRow As GridViewRow = CustomersGridView.FooterRow

    ' Set the font color of the header and footer rows
    ' based on the sort direction. 
    Select Case CustomersGridView.SortDirection

      Case SortDirection.Ascending
        headerRow.ForeColor = System.Drawing.Color.Green
        footerRow.ForeColor = System.Drawing.Color.Green
      Case SortDirection.Descending
        headerRow.ForeColor = System.Drawing.Color.Red
        footerRow.ForeColor = System.Drawing.Color.Red
      Case Else
        headerRow.ForeColor = System.Drawing.Color.Black
        footerRow.ForeColor = System.Drawing.Color.Black
        
    End Select

    ' Display the sort order in the footer row.
    footerRow.Cells(0).Text = "Sort Order = " & CustomersGridView.SortDirection.ToString()
      
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView HeaderRow and FooterRow Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView HeaderRow and FooterRow Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="true"
        emptydatatext="No data available." 
        allowsorting="true"
        allowpaging="true" 
        showheader="true"
        showfooter="true"
        ondatabound="CustomersGridView_DataBound"    
        runat="server">
        
        <headerstyle backcolor="LightCyan"
          forecolor="MediumBlue"/>
                    
        <footerstyle backcolor="LightCyan"
          forecolor="MediumBlue"/>
                        
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