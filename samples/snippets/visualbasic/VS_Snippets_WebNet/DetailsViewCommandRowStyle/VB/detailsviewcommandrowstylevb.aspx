<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView CommandRowStyle Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView CommandRowStyle Example</h3>

        <asp:detailsview id="CustomerDetailsView"
          datasourceid="DetailsViewSource"
          autogeneraterows="false"  
          datakeynames="CustomerID"     
          gridlines="Both"
          allowpaging="true"     
          runat="server">
          
          <headerstyle backcolor="Navy"
            forecolor="White" />
                      
          <commandrowstyle backcolor="LightCyan"
            font-names="Arial"
            font-size="10"
            font-bold="true"/>
                              
          <fields>
          
            <asp:commandfield ButtonType="Link"
              ShowEditButton="true"/>
            
            <asp:boundfield datafield="CustomerID"
              headertext="Customer ID"
              readonly="true"/>
              
            <asp:boundfield datafield="CompanyName"
              headertext="Company Name"/>
              
            <asp:boundfield datafield="Address"
              headertext="Address"/>
              
            <asp:boundfield datafield="City"
              headertext="City"/>
                  
            <asp:boundfield datafield="PostalCode"
              headertext="Postal Code"/>
              
            <asp:boundfield datafield="Country"
              headertext="Country"/>
              
          </fields>
              
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