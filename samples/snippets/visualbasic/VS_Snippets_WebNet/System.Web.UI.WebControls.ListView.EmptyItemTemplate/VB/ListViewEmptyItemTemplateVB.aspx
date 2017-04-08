<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView EmptyItemTemplate Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView EmptyItemTemplate Example</h3>
       
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        GroupItemCount="4"
        runat="server">
        <LayoutTemplate>
          <table runat="server" id="tblProducts">
            <tr runat="server" id="groupPlaceholder" />
          </table>
         </LayoutTemplate>
         <GroupTemplate>
            <tr runat="server" id="ProductsRow" align="center">
              <td runat="server" id="itemPlaceholder" />
            </tr>
         </GroupTemplate>
         <ItemTemplate>
            <td runat="server">
              <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("FirstName") %>' /><br />
              <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("LastName") %>' />
            </td>
         </ItemTemplate>
         <ItemSeparatorTemplate>
            <td runat="server" style="border-right: 1px solid #ccc">&nbsp;</td>
         </ItemSeparatorTemplate>
         <GroupSeparatorTemplate>
            <tr runat="server">
              <td colspan="7"><hr /></td>
            </tr>
         </GroupSeparatorTemplate>
         <EmptyItemTemplate>
            <td runat="server">***</td>
         </EmptyItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      
      <!-- The select query for the following SqlDataSource     -->
      <!-- control is intentionally set to return less results  -->
      <!-- to demonstrate the empty item template               -->       
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] 
            FROM Person.Contact 
            WHERE [ContactID]<10">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>