<!-- <Snippet1> -->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView RowStyle and AlternatingRowStyle Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView RowStyle and AlternatingRowStyle Example</h3>
                
        <asp:detailsview id="CustomersView"
          datasourceid="Customers"
          autogeneraterows="true"
          allowpaging="true" 
          runat="server">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
            
          <RowStyle BackColor="LightGray"
            ForeColor="Blue"
            Font-Names="Arial"
            Font-Size="10"
            Font-Italic="true"/>
            
          <AlternatingRowStyle BackColor="White"
            ForeColor="Blue"
            Font-Names="Arial"
            Font-Size="10"
            Font-Italic="true"/>
                    
        </asp:detailsview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database. -->           
        <asp:SqlDataSource ID="Customers" runat="server" 
          ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
          SelectCommand="SELECT [CompanyName], [ContactName], [CustomerID], [Phone] FROM [Customers]">
        </asp:SqlDataSource>
            
      </form>
  </body>
</html>
<!-- </Snippet1> -->
