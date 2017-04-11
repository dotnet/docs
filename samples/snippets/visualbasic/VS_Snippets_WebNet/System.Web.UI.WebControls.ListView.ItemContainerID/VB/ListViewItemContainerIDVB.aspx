<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView GroupContainerID and ItemContainerID Example</title>
    <style type="text/css">
      body
      {
      	  font: 10pt Trebuchet MS, Arial, Tahoma; 
      	  text-align: center;
      }
      th { background: #b7cfff; }
      .item
      {
          border: 1px dashed #a4cbf4;
          background: white;
          min-height: 19px;
          width: 33%;
      }
      .alternatingItem
      {
        border: solid 1px #a4cbf4;
        background: #edf5fd;
        width: 33%;
        min-height: 19px;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">

      <h3>ListView GroupContainerID and ItemContainerID Example</h3>
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        GroupItemCount="3"
        GroupPlaceholderID="ContactRowContainer"
        ItemPlaceholderID="ContactItemContainer"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="4" width="640px" runat="server" id="tblContacts">
            <tr id="Tr1" runat="server">
              <th id="Th1" colspan="3" runat="server">Contacts</th>
            </tr>
            <tr runat="server" id="ContactRowContainer" />
          </table>
          <asp:DataPager ID="ContactsDataPager" runat="server" PageSize="30">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <GroupTemplate>
          <tr runat="server" id="ContactRow">
            <td runat="server" id="ContactItemContainer" />
          </tr>
        </GroupTemplate>
        <ItemTemplate>
          <td id="Td1" class="item" runat="server">
            <asp:Label ID="NameLabel" runat="server" 
              Text='<%# Eval("LastName") & ", " & Eval("FirstName")%>' />
          </td>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <td id="Td2" class="alternatingItem" runat="server">
            <asp:Label ID="NameLabel" runat="server" 
              Text='<%# Eval("LastName") & ", " & Eval("FirstName")%>' />
          </td>
        </AlternatingItemTemplate>
      </asp:ListView>
      
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->      
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [FirstName], [LastName] 
          FROM Person.Contact ORDER BY [LastName], [FirstName] ">
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<%-- </Snippet1> --%>