<!-- <Snippet1> -->

<%@ Page language="C#" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    protected void CustomerDetailView_DataBound(object sender, 
      EventArgs e)
    {
        DataRowView rowView = (DataRowView)CustomerDetailView.DataItem;
        if (rowView.Row[0].ToString() == "SpecialID")
        {
            CustomerDetailView.FieldHeaderStyle.BackColor = 
              System.Drawing.Color.Red;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView ModeChanging Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView ModeChanging Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          autogenerateeditbutton="true" 
          OnDataBound="CustomerDetailView_DataBound"
          allowpaging="true"
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