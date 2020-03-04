<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub CustomerDetailView_PageIndexChanged(ByVal sender As Object, _
        ByVal e As EventArgs)
        ' By default, if the DetailsView control is in edit mode and
        ' user navigates to another page, the DetailsView control
        ' remains in edit mode. In this example, the ChangeMode 
        ' method is used to put the DetailsView control in read-only  
        ' mode whenever the user navigates to another record.
        CustomerDetailView.ChangeMode(DetailsViewMode.ReadOnly)
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView ChangeMode Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView ChangeMode Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogenerateeditbutton="true"  
          autogeneraterows="true"
          allowpaging="true"
          OnPageIndexChanged="CustomerDetailView_PageIndexChanged"
          runat="server">
               
          <fieldheaderstyle backcolor="Navy"
            forecolor="White"/>
                    
        </asp:detailsview>
        
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
          InsertCommand="INSERT INTO [Customers]([CustomerID],
            [CompanyName], [Address], [City], [PostalCode], [Country]) 
            VALUES (@CustomerID, @CompanyName, @Address, @City, 
            @PostalCode, @Country)"
          SelectCommand="Select [CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country] From 
            [Customers]">
        </asp:SqlDataSource>
    </form>
  </body>
</html>

<!-- </Snippet1> -->