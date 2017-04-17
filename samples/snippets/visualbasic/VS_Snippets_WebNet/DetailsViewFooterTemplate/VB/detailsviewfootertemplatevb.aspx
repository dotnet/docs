<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Protected Sub CustomerDetailView_DataBound(ByVal sender As Object, _
        ByVal e As EventArgs)
        ' Get the footer row.
        Dim footerRow As DetailsViewRow = CustomerDetailView.FooterRow

        ' Get the Label control that displays the current page 
        ' information from the footer row.
        Dim pageNum As Label = _
            CType(footerRow.Cells(0).FindControl("PageNumberLabel"), Label)

        If pageNum IsNot Nothing Then
            ' Update the Label control with the current page number.
            Dim page As Integer = CustomerDetailView.DataItemIndex + 1
            pageNum.Text = "Page " + page.ToString()
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>DetailsView FooterTemplate Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView FooterTemplate Example</h3>
                
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          datakeynames="CustomerID"
          autogeneraterows="true"
          allowpaging="true"
          runat="server" 
          OnDataBound="CustomerDetailView_DataBound">
               
          <headerstyle backcolor="Navy"
            forecolor="White"/>
            
          <pagersettings Mode="NextPreviousFirstLast"/>  
            
          <FooterTemplate>
          
            <table width="100%">            
              <tr>
                <td align="left">
                  <asp:Image id="LogoImage"
                    AlternateText="Our logo" 
                    imageurl="~\images\Logo.jpg"
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
          
          </FooterTemplate>
                    
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