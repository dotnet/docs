<!-- <Snippet1> -->

<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub SubmitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
 
    ' Use the Count property to determine whether the
    ' Rows collection contains any item.
    If ItemDetailsView.Rows.Count > 0 Then
    
      ' Iterate through the Rows collection and display
      ' the value of each field.
      MessageLabel.Text = "The row values are: <br/><br/>"
    
      Dim row As DetailsViewRow
    
      For Each row In ItemDetailsView.Rows
    
        ' Use the Text property to access the value of 
        ' each cell. In this example, the cells in the 
        ' first column (index 0) contains the field names, 
        ' while the cells in the second column (index 1)
        ' contains the field value. 
        MessageLabel.Text &= row.Cells(0).Text & " = " & _
          row.Cells(1).Text & "<br/>"
    
      Next
    
    Else
      
      MessageLabel.Text = "No items."
    
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsViewRowCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>DetailsViewRowCollection Example</h3>
  
      <asp:detailsview id="ItemDetailsView"
        datasourceid="DetailsViewSource"
        allowpaging="true"
        autogeneraterows="false" 
        runat="server">
        <fields>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName"
            headertext="Company Name"/>
          <asp:boundfield datafield="Address"
            headertext="Address"/>
          <asp:boundfield datafield="City"
            headertext="City"/>
          <asp:boundfield datafield="PostalCode"
            headertext="ZIP Code"/>
          <asp:boundfield datafield="Country"
            headertext="Country"/>
        </fields>
      </asp:detailsview>
      
      <br/>
      
      <asp:button id="SubmitButton" 
        text="Display Row Values"
        onclick="SubmitButton_Click"
        runat="server"/>
        
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
      
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the web.config file.                            -->
      <asp:sqldatasource id="DetailsViewSource"
        selectcommand="Select [CustomerID], [CompanyName], [Address], 
          [City], [PostalCode], [Country] From [Customers]"
        connectionstring=
          "<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>  
  
    </form>
  </body>
</html>
<!-- </Snippet1> -->