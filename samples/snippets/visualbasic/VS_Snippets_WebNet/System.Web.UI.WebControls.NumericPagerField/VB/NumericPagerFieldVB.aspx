<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NumericPagerField Example</title>    
    <style type="text/css">
      body 	
      {
      	text-align: center;
      	font: 12px Arial, Helvetica, sans-serif;
      } 
      table
      {
      	padding: 2px 2px 2px 2px;
      	border: 1px solid;
      	width: 500px;
      }     
      .CurrentPage 
      {
      	padding: 2px 6px;
      	border: solid 1px #ddd; 
      	background: #2E8B57;
      	color:White;
      }
      .PrevNext,.PageNumber
      {
      	padding: 2px 6px;
      	border: solid 1px #ddd;
      	text-decoration: none;
      	color: #2E8B57;
      }
      .PageNumber:hover, .PrevNext:hover
      {
      	background-color: #FFA500;
      	color: White;
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
          <table runat="server" id="tblContacts">
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("ContactID") %>' />
            </td>
            <td align="left">
              <asp:Label ID="NameLabel" runat="server" 
                Text='<%#Eval("LastName") & ", " & Eval("FirstName")%>' />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
      <br />

      <div>
        <asp:DataPager runat="server" 
          ID="ContactsDataPager" 
          PagedControlID="ContactsListView">
          <Fields>
            <asp:NumericPagerField 
              PreviousPageText="&lt; Prev"
              NextPageText="Next &gt;"
              ButtonCount="10"
              NextPreviousButtonCssClass="PrevNext"
              CurrentPageLabelCssClass="CurrentPage"
              NumericButtonCssClass="PageNumber" />
          </Fields>
        </asp:DataPager>
      </div>
      <br />

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] 
          FROM Person.Contact">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>