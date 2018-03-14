<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' Use the RowType property to determine whether the 
    ' row being created is the header row. 
    If e.Row.RowType = DataControlRowType.Header Then
    
      ' Call the GetSortColumnIndex helper method to determine
      ' the index of the column being sorted.
      Dim sortColumnIndex As Integer = GetSortColumnIndex()
      
      If sortColumnIndex <> -1 Then
      
        ' Call the AddSortImage helper method to add
        ' a sort direction image to the appropriate
        ' column header. 
        AddSortImage(sortColumnIndex, e.Row)
    
      End If
      
    End If
    
  End Sub

  ' This is a helper method used to determine the index of the
  ' column being sorted. If no column is being sorted, -1 is returned.
  Function GetSortColumnIndex() As Integer

    ' Iterate through the Columns collection to determine the index
    ' of the column being sorted.
    Dim field As DataControlField
    For Each field In CustomersGridView.Columns
    
      If field.SortExpression = CustomersGridView.SortExpression Then
      
        Return CustomersGridView.Columns.IndexOf(field)

      End If
      
    Next

    Return -1
      
  End Function

  ' This is a helper method used to add a sort direction
  ' image to the header of the column being sorted.
  Sub AddSortImage(ByVal columnIndex As Integer, ByVal row As GridViewRow)

    ' Create the sorting image based on the sort direction.
    Dim sortImage As New Image()
    If CustomersGridView.SortDirection = SortDirection.Ascending Then
    
      sortImage.ImageUrl = "~/Images/Ascending.jpg"
      sortImage.AlternateText = "Ascending Order"
    
    Else
    
      sortImage.ImageUrl = "~/Images/Descending.jpg"
      sortImage.AlternateText = "Descending Order"
    
    End If
    ' Add the image to the appropriate header cell.
    row.Cells(columnIndex).Controls.Add(sortImage)
    
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView AllowSorting Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView AllowSorting Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="false"
        emptydatatext="No data available." 
        allowsorting="true"
        onrowcreated="CustomersGridView_RowCreated"
        runat="server">
        
        <columns>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID"
            headerstyle-wrap="false" 
            sortexpression="CustomerID"/>
          <asp:boundfield datafield="CompanyName"
            headertext="CompanyName"
            headerstyle-wrap="false"
            sortexpression="CompanyName"/>
          <asp:boundfield datafield="Address"
            headertext="Address"
            headerstyle-wrap="false"
            sortexpression="Address"/>
          <asp:boundfield datafield="City"
            headertext="City"
            headerstyle-wrap="false"
            sortexpression="City"/>
          <asp:boundfield datafield="PostalCode"
            headertext="Postal Code"
            headerstyle-wrap="false"
            sortexpression="PostalCode" />
          <asp:boundfield datafield="Country"
            headertext="Country"
            headerstyle-wrap="false"
            sortexpression="Country"/>         
        </columns>
                
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