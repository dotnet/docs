<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NumericPagerField Example</title>
    <style type="text/css">
      .PagerNormal
      {
        font: 9pt Verdana;
        color: #0066CF;
        border: solid 1px #778899;
        padding: 1px 4px;
        text-decoration:none;
      }
      .PagerCurrent
      {
      	font: 9pt Verdana;
      	border: solid 1px #778899;
        padding: 1px 4px;
        background-color: #FFD700;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>NumericPagerField Example</h3>
          
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        runat="server">
        <LayoutTemplate>        
          <table cellpadding="2" width="640px" border="1" runat="server" id="tblContacts">
            <tr runat="server">
              <th runat="server">ID</th>
              <th runat="server">First Name</th>
              <th runat="server">Last Name</th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
          <br />
          <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="ContactsListView">
            <Fields>
              <asp:NumericPagerField
                ButtonCount="10"
                CurrentPageLabelCssClass="PagerCurrent"
                NextPreviousButtonCssClass="PagerNormal" 
                NumericButtonCssClass="PagerNormal"
                NextPageText=">>"
                PreviousPageText="<<" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="ContactIDLabel" runat="server" Text='<%# Eval("ContactID") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

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