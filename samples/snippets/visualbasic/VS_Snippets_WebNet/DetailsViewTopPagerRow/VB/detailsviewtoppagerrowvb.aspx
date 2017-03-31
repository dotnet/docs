<!-- <Snippet1> -->

<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Protected Sub CustomerDetailView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the pager row.
        Dim pagerRow As DetailsViewRow = CustomerDetailView.TopPagerRow

        ' Get the Label controls that display the current page information 
        ' from the pager row.
        Dim pageNum As Label = CType(pagerRow.Cells(0).FindControl("PageNumberLabel"), Label)
        Dim totalNum As Label = CType(pagerRow.Cells(0).FindControl("TotalPagesLabel"), Label)

        If (pageNum IsNot Nothing) And (totalNum IsNot Nothing) Then
            ' Update the Label controls with the current page values.
            Dim page As Integer = CustomerDetailView.DataItemIndex + 1
            Dim count As Integer = CustomerDetailView.DataItemCount

            pageNum.Text = Page.ToString()
            totalNum.Text = count.ToString()
        End If
    End Sub

    </script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>DetailsView TopPagerRow Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        
      <h3>DetailsView TopPagerRow Example</h3>
              
        <!-- Notice that the LinkButton controls in the pager   -->
        <!-- template have their CommandName properties set.    -->
        <!-- The DetailsView control automatically recognizes   -->
        <!-- certain command names and performs the appropriate -->
        <!-- operation. In this example, the CommandName        -->
        <!-- properties are set to "Page"                       -->
        <!-- and the CommandArgument                            -->
        <!-- properties are set to "Next" and "Prev", which     -->
        <!-- causes the DetailsView control to navigate to the  -->
        <!-- next and previous record, respectively.            -->        
        <asp:detailsview id="CustomerDetailView"
          datasourceid="DetailsViewSource"
          autogeneraterows="true" 
          allowpaging="true"
          runat="server" 
          OnDataBound="CustomerDetailView_DataBound">
               
          <fieldheaderstyle backcolor="Navy"
            forecolor="White"/>
            
          <PagerSettings Position="top" /> 
          
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
                  Page <asp:Label id="PageNumberLabel" runat="server"/> 
                  of <asp:Label id="TotalPagesLabel" runat="server"/>                
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