<!-- <Snippet1> -->

<%@ Page language="VB" autoeventwireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub CustomerDetailsView_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles CustomerDetailsView.DataBound

    ' Get the value of the key field at index 2 in the DataKey object.
    Dim value As String = CustomerDetailsView.DataKey(2).ToString()

    ' Display the the value of the key field.
    MessageLabel.Text = "The value of the PostalCode key field is " & value & _
      "."

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DataKey Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>DataKey Example</h3>
                       
        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true"
          datakeynames="CustomerID, CompanyName, PostalCode"  
          allowpaging="true"
          runat="server">
            
        </asp:detailsview>
        
        <br/>
        
        <asp:label id="MessageLabel"
          forecolor="Red"
          runat="server"/>
            
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the Web.config file.                            -->
        <asp:sqldatasource id="DetailsViewSource"
          selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
          connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
          runat="server"/>
            
      </form>
  </body>
</html>

<!-- </Snippet1> -->