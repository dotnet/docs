<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>NextPreviousPagerField Example</title>
    <style type="text/css">
      .header
      {
      	background-color:Gray;
      	color:White;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>NextPreviousPagerField Example</h3>
          
      <asp:ListView ID="VendorsListView" 
        DataSourceID="VendorsDataSource"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" border="1" runat="server" id="tblVendor">
            <tr align="center" class="header" runat="server">
              <th runat="server">ID</th>
              <th runat="server">Vendor Name</th>
              <th runat="server">Active</th>
            </tr>
            <tr id="itemPlaceholder" runat="server">
            </tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="VendorIDLabel" runat="server" Text='<%#Eval("VendorID") %>' />
            </td>
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td align="center">
              <asp:CheckBox ID="ActiveFlagCheck" runat="server" 
                Checked='<%#Eval("ActiveFlag") %>' 
                Enabled="false" />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

      <asp:DataPager runat="server" ID="ContactsDataPager" 
        PagedControlID="VendorsListView" 
        PageSize="15">
        <Fields>
          <asp:NextPreviousPagerField 
            ShowFirstPageButton="true" 
            ShowLastPageButton="true"
            FirstPageImageUrl="~/images/first.gif" 
            LastPageImageUrl="~/images/last.gif"
            NextPageImageUrl="~/images/next.gif" 
            PreviousPageImageUrl="~/images/previous.gif"
            ButtonType="Image" />
        </Fields>
      </asp:DataPager>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="VendorsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [VendorID], [Name], [ActiveFlag] FROM Purchasing.Vendor">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>