<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NextPreviousPagerField Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>NextPreviousPagerField Example</h3>
          
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" border="1" runat="server" id="tblContacts">
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="ContactIDLabel" runat="server" Text='<%#Eval("ContactID") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

      <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="ContactsListView">
        <Fields>
          <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true" />
        </Fields>
      </asp:DataPager>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] FROM Person.Contact">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>