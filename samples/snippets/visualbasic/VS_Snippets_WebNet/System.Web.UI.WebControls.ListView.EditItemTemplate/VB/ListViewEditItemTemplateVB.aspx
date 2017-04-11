<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Templates Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Templates Example</h3>
                 
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" border="1" runat="server" id="tblProducts">
            <tr runat="server">
              <th runat="server">Action</th>
              <th runat="server">First Name</th>
              <th runat="server">Last Name</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowLastPageButton="True"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:LinkButton ID="EditButton" runat="Server" Text="Edit" CommandName="Edit" />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("LastName") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr style="background-color: #ADD8E6">
            <td>
              <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />&nbsp;
              <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' 
                MaxLength="50" /><br />
            </td>
            <td>
              <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' 
                MaxLength="50" /><br />
            </td>
          </tr>
        </EditItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] FROM Person.Contact"
        UpdateCommand="UPDATE Person.Contact
                       SET FirstName = @FirstName, LastName = @LastName
                       WHERE ContactID = @ContactID">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>