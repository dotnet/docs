<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  Protected Sub ContactsListView_Sorted(ByVal sender As Object, ByVal e As EventArgs)
    
    SortExpressionLabel.Text = "Sort Column = " & ContactsListView.SortExpression
    SortDirectionLabel.Text = "Sort Order = " & ContactsListView.SortDirection.ToString()
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView SortDirection and SortExpression Example</title>
    <style type="text/css">
      body  { font: 10pt Trebuchet MS, Arial, Tahoma; }
      td { border: 1px solid #E6E6FA; }
      .header {	background: #B0C4DE; }
      .alternatingItem { background: #edf5fd; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
              
    <h3>SortDirection and SortExpression Example</h3>
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        OnSorted="ContactsListView_Sorted"
        runat="server">
        <LayoutTemplate>
          <table width="640px" runat="server" id="tblContacts">
            <tr class="header" align="center" runat="server">
              <td>
                <asp:LinkButton runat="server" ID="SortByFirstNameButton"
                  CommandName="Sort" Text="First Name" 
                  CommandArgument="FirstName"/>
              </td>
              <td>
                <asp:LinkButton runat="server" ID="SortByLastNameButton"
                  CommandName="Sort" Text="Last Name"
                  CommandArgument="LastName" />
              </td>
              <td>
                <asp:LinkButton runat="server" ID="SortByEmailButton"
                  CommandName="Sort" Text="E-mail Address" 
                  CommandArgument="EmailAddress" />
              </td>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" 
                ShowLastPageButton="true" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr class="alternatingItem" runat="server">
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </AlternatingItemTemplate>
      </asp:ListView> <br /><br />

      <asp:Label ID="SortExpressionLabel"
        ForeColor="SteelBlue"
        runat="server"/> <br />
      
      <asp:Label ID="SortDirectionLabel"
        ForeColor="SteelBlue"
        runat="server"/>
        
      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
                       FROM Person.Contact" >
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>