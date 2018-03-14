<!-- <Snippet1> -->
<%@ Page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void CustomerDetailView_DataBound(object sender, EventArgs e)
    {

      // Get the pager row.
      DetailsViewRow pagerRow = CustomerDetailView.BottomPagerRow;

      // Get the Label controls that display the current page information 
      // from the pager row.
      Label pageNum = (Label)pagerRow.Cells[0].FindControl("PageNumberLabel");
      Label totalNum = (Label)pagerRow.Cells[0].FindControl("TotalPagesLabel");

      if ((pageNum != null) && (totalNum != null))
      {
          // Update the Label controls with the current page values.
          int page = CustomerDetailView.DataItemIndex + 1;
          int count = CustomerDetailView.DataItemCount;

          pageNum.Text = page.ToString();
          totalNum.Text = count.ToString();
      }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DetailsView PagerTemplate Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView PagerTemplate Example</h3>
                
        <!-- Notice that the LinkButton controls in the pager   -->
        <!-- template have their CommandName properties set.    -->
        <!-- The DetailsView control automatically recognizes   -->
        <!-- certain command names and performs the appropriate -->
        <!-- operation. In this example, the CommandName        -->
        <!-- properties are set "Page" and the CommandArgument  -->
        <!-- properties are set to "Next" and "Prev", which     -->
        <!-- causes the DetailsView control to navigate to the  -->
        <!-- next and previous record, respectively.            -->        
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true" 
          allowpaging="true"
        
          runat="server" OnDataBound="CustomerDetailView_DataBound">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
            
          <pagerstyle VerticalAlign="Bottom" />
            
          <pagertemplate>
          
            <table width="100%">
              <tr>
                <td>
                  <asp:LinkButton id="PreviousButton"
                    text="<"
                    CommandName="Page"
                    CommandArgument="Prev"
                    runat="Server"/>
                  <asp:LinkButton id="NextButton"
                    text=">"
                    CommandName="Page"
                    CommandArgument="Next"
                    runat="Server"/> 
                </td>
                <td align="right">                
                  Page <asp:Label id="PageNumberLabel" runat="server" /> 
                  of <asp:Label id="TotalPagesLabel" runat="server" />                
                </td>
              </tr>
            </table>          
          </pagertemplate>   
                    
        </asp:detailsview>
        
        <!-- This example uses Microsoft SQL Server and connects  -->
        <!-- to the Northwind sample database. Use an ASP.NET     -->
        <!-- expression to retrieve the connection string value   -->
        <!-- from the web.config file.                            -->
        <asp:SqlDataSource ID="DetailsViewSource" runat="server" 
          ConnectionString=
            "<%$ ConnectionStrings:NorthWindConnectionString%>"
            InsertCommand="INSERT INTO [Customers]([CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country]) VALUES (@CustomerID, @CompanyName, @Address, @City, @PostalCode, @Country)"
          SelectCommand="Select [CustomerID], [CompanyName], 
            [Address], [City], [PostalCode], [Country] From 
            [Customers]">
        </asp:SqlDataSource>
    </form>
  </body>
</html>

<!-- </Snippet1> -->