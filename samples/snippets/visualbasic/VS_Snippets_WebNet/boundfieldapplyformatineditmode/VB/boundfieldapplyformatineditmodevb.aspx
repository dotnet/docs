<!-- <Snippet1> -->

<%@ Page language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomersGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs) Handles CustomersGridView.RowUpdating
    
    ' Use the NewValues property to retrieve the updated CustomerID
    ' value entered by the user.
    Dim customerID As String = e.NewValues("CustomerID").ToString()
  
    ' Remove the formating applied by the DataFormatString property.
    If customerID.StartsWith("D:") Then
    
      e.NewValues("CustomerID") = customerID.Substring(2)
      
    End If

  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>BoundField Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>BoundField Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        autogenerateeditbutton="true"
        allowpaging="true" 
        datakeynames="CustomerID"  
        runat="server">
         
        <columns>
          <asp:boundfield datafield="CustomerID"
            dataformatstring="D:{0}"
            applyformatineditmode="true"       
            headertext="Customer ID"/>
          <asp:boundfield datafield="CompanyName"
            convertemptystringtonull="true"
            headertext="Customer Name"/>
          <asp:boundfield datafield="Address"
            convertemptystringtonull="true"
            headertext="Address"/>
          <asp:boundfield datafield="City"
            convertemptystringtonull="true"
            headertext="City"/>
          <asp:boundfield datafield="PostalCode"
            convertemptystringtonull="true"
            headertext="ZIP Code"/>
          <asp:boundfield datafield="Country"
            convertemptystringtonull="true"
            headertext="Country"/>
        </columns>
                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        updatecommand="Update Customers Set CustomerID=@CustomerID, CompanyName=@CompanyName, Address=@Address, City=@City, PostalCode=@PostalCode, Country=@Country Where (CustomerID = @CustomerID)"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->