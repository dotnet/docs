<!-- <Snippet1> -->

<%@ Page language="VB" AutoEventWireup="False" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    ' Dynamically generated field columns need to be created only 
    ' the first time the page is loaded.
    If Not IsPostBack Then
    
      ' Create a CommandField object to display a Select button
      ' for each record in the GridView control.
      Dim selectCommandField As New CommandField()
      selectCommandField.ShowSelectButton = True
      selectCommandField.SelectText = "Select Company"
      
      ' Create a BoundField object to display the company names.
      Dim lastNameBoundField As New BoundField()
      lastNameBoundField.DataField = "au_lname"
      lastNameBoundField.HeaderText = "Last Name"

      ' Create a BoundField object to display a customer's company name.
      Dim nameBoundField As New BoundField()
      nameBoundField.DataField = "CompanyName"
      nameBoundField.HeaderText = "Company Name"

      ' Create a BoundField object to display a customer's city.
      Dim cityBoundField As New BoundField()
      cityBoundField.DataField = "City"
      cityBoundField.HeaderText = "City"

      ' Add the field columns to the ColumnFields collection of the
      ' GridView control.
      CustomersGridView.Columns.Add(selectCommandField)
      CustomersGridView.Columns.Add(nameBoundField)
      CustomersGridView.Columns.Add(cityBoundField)
      
    End If
      
  End Sub

  Sub CustomersGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CustomersGridView.SelectedIndexChanged
    
    ' Get the value of the company name and city from the appropriate cells.
    Dim companyName As String = CustomersGridView.SelectedRow.Cells(1).Text
    Dim city As String = CustomersGridView.SelectedRow.Cells(2).Text
   
    Message.Text = "You selected " & companyName & " located in " & city & "."
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>CommandField Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>CommandField Constructor Example</h3>

      <asp:label id="Message" 
        forecolor="Red"
        runat="server"/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="False"
        runat="server">                
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [City] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->