<!-- <Snippet1> -->

<%@ Page language="VB" AutoEventWireup="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub CustomersGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomersGridView.SelectedIndexChanged
    
    ' Retrieve the company name from the appropriate cell.
    Dim companyName As String = CustomersGridView.SelectedRow.Cells(2).Text
   
    ' Display company name selected by the user.
    Message.Text = "You selected " & companyName & "."
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CommandField Example</title>
</head>
<body>
    <form id="form1" runat="server">
      
      <h3>CommandField Example</h3>
      
      <asp:Label id="Message"
        forecolor="Red"
        runat="server"/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="false"
        datakeynames="CustomerID"
        runat="server">
        
        <columns>
          <asp:commandfield showselectbutton="true"
            selecttext="Pick"
            headertext="Select Customer"/>
          <asp:boundfield datafield="CustomerID"
            headertext="Customer ID" />
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
        </columns>
        
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->