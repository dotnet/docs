<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView Fields Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView Fields Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          AutoGenerateRows="false"
          allowpaging="true"
          runat="server">
               
        <Fields>
         <asp:BoundField 
           DataField="CompanyName" 
           HeaderText="Company Name"/>
         <asp:BoundField 
           DataField="City" 
           HeaderText="City"/>
        </Fields>
                    
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