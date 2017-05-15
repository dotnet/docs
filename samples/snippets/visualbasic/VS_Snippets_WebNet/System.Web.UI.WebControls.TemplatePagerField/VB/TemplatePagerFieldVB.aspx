<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>TemplatePagerField Example</title>    
    <style type="text/css">
      body 	
      {
      	text-align: center;
      	font: 12px Arial, Helvetica, sans-serif;
      }
      .item
      {
        border: solid 1px #458b74;
        background: #e0ffff;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>TemplatePagerField Example</h3>
          
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        runat="server">
        <LayoutTemplate>
          <table runat="server" id="tblContacts" width="350">
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
         </LayoutTemplate>
         <ItemTemplate>
            <tr runat="server">
              <td class="item">
                <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("ContactID") %>' />
              </td>            
              <td align="left" class="item">
                <asp:Label ID="NameLabel" runat="server" 
                  Text='<%#Eval("LastName") & ", " & Eval("FirstName")%>' />
              </td>
            </tr>
          </ItemTemplate>
      </asp:ListView>
      <br />

      <asp:DataPager runat="server" 
        ID="ContactsDataPager" 
        PageSize="20"          
        PagedControlID="ContactsListView">
        <Fields>
          <asp:TemplatePagerField>              
            <PagerTemplate>
            <b>
            Page
            <asp:Label runat="server" ID="CurrentPageLabel" 
              Text="<%# IIf(Container.TotalRowCount>0,  (Container.StartRowIndex / Container.PageSize) + 1 , 0) %>" />
            of
            <asp:Label runat="server" ID="TotalPagesLabel" 
              Text="<%# Math.Ceiling (System.Convert.ToDouble(Container.TotalRowCount) / Container.PageSize) %>" />
            (
            <asp:Label runat="server" ID="TotalItemsLabel" 
              Text="<%# Container.TotalRowCount%>" />
            records)
            <br />
            </b>
            </PagerTemplate>
          </asp:TemplatePagerField>
          
          <asp:NextPreviousPagerField
            ButtonType="Button"
            ShowFirstPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false" />
          
          <asp:NumericPagerField 
            PreviousPageText="&lt; Prev 10"
            NextPageText="Next 10 &gt;"
            ButtonCount="10" />
            
          <asp:NextPreviousPagerField
            ButtonType="Button"
            ShowLastPageButton="true"
            ShowNextPageButton="false"
            ShowPreviousPageButton="false" />
        </Fields>
      </asp:DataPager>

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