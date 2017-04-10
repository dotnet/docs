<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView EmptyDataTemplate Example</title>
    <style type="text/css">
        .emptyTable { background-color:Aqua; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView EmptyDataTemplate Example</h3>
                 
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        runat="server">
        <LayoutTemplate>
          <table runat="server" id="tblProducts">
            <tr runat="server" id="itemPlaceholder" />
          </table>
         </LayoutTemplate>
         <ItemTemplate>
            <tr runat="server">
              <td>
                <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("FirstName") %>' />
              </td>
              <td>
                <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("LastName") %>' />
              </td>
            </tr>
          </ItemTemplate>
          <EmptyDataTemplate>
              <table class="emptyTable" cellpadding="5" cellspacing="5">
                <tr>
                  <td>
                    <asp:Image ID="NoDataImage"
                      ImageUrl="~/Images/NoDataImage.jpg" 
                      runat="server"/>
                  </td>
                  <td>
                    No records available.
                  </td>
                </tr>
              </table>
          </EmptyDataTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      
      <!-- The select query for the following SqlDataSource     -->
      <!-- control is intentionally set to return no results    -->
      <!-- to demonstrate the empty data template               -->       
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
            SelectCommand="SELECT [ContactID], [FirstName], [LastName] 
              FROM Person.Contact WHERE [ContactID]=1000">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>