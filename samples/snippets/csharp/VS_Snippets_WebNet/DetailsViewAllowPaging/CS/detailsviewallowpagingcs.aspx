<!-- <Snippet1> -->
<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView AllowPaging Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView AllowPaging Example</h3>
                
        <asp:detailsview id="StoresDetailView"
          datasourceid="Customers"
          autogeneraterows="true" 
          allowpaging="true"
          runat="server">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
            
          <pagersettings mode="NextPreviousFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            nextpagetext="Next"
            previouspagetext="Prev"/>
            
          <pagerstyle forecolor="White"
            backcolor="Blue"
            font-names="Arial"
            font-size="8" />   
        </asp:detailsview>
            
        <!-- This example uses Microsoft SQL Server and connects -->
        <!-- to the Northwind sample database. -->           
        <asp:SqlDataSource ID="Customers" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthwindConnectionString %>"
          SelectCommand="SELECT [CompanyName], [ContactName], 
             [CustomerID] FROM [Customers]">
        </asp:SqlDataSource>
            
      </form>
  </body>
</html>
<!-- </Snippet1> -->
