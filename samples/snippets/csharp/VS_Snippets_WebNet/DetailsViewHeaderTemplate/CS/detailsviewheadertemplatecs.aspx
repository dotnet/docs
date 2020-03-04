<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void CustomerDetailView_ItemCreated(Object sender, EventArgs e)
  {
    
    // Get the header row.
      DetailsViewRow headerRow = CustomerDetailView.HeaderRow;

    // Get the Label control that displays the current page information 
    // from the header row.
    Label pageNum = (Label)headerRow.FindControl("PageNumberLabel");

    if(pageNum != null)
    {
      // Update the Label control with the current page number.
        int page = CustomerDetailView.DataItemIndex + 1;
      pageNum.Text = "Page " + page.ToString ();
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView HeaderTemplate Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView HeaderTemplate Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          allowpaging="true"
          onitemcreated="CustomerDetailView_ItemCreated"   
          runat="server">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
            
          <pagersettings Mode="NextPreviousFirstLast"/>  
            
          <headertemplate>
          
            <table width="100%">            
              <tr>
                <td align="left">
                  <asp:Image id="LogoImage"
                    imageurl="~\images\Logo.jpg"
                    AlternateText="Our logo" 
                    runat="server"/>
                </td>
                <td align="right" valign="bottom">
                  <asp:Label id="PageNumberLabel"
                    font-size="9"
                    forecolor="DodgerBlue"
                    runat="server"/>
                </td>
              </tr>            
            </table>
          
          </headertemplate>
                    
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