<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView AlternatingItemTemplate Example</title>
    <style type="text/css">
        body   
        {
          font-size: 10pt;
        	font-family: Trebuchet MS, Arial, Tahoma;
        	text-align:center;
        }
        .item { background-color: #E0FFFF }
        .alternatingItem { background-color: #B0E0E6 }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
      
      <h3>ListView AlternatingItemTemplate Example</h3>
      
      <asp:ListView ID="VendorsListView" 
        DataSourceID="VendorsDataSource"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" id="tblVendors" runat="server">
            <tr runat="server">
              <th runat="server">ID</th>
              <th runat="server">Account Number</th>
              <th runat="server">Name</th>
              <th runat="server">Preferred Vendor</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager ID="VendorsDataPager" runat="server" PageSize="15">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr class="item" runat="server">
            <td>
              <asp:Label ID="VendorIDLabel" runat="server" Text='<%# Eval("VendorID") %>' />
            </td>
            <td>
              <asp:Label ID="AccountNumberLabel" runat="server" Text='<%# Eval("AccountNumber") %>' />
            </td>
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td align="center">
              <asp:CheckBox ID="PreferredCheckBox" runat="server" Enabled="False"
                Checked='<%# Eval("PreferredVendorStatus") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr class="alternatingItem" runat="server">
            <td>
              <asp:Label ID="VendorIDLabel" runat="server" Text='<%# Eval("VendorID") %>' />
            </td>
            <td>
              <asp:Label ID="AccountNumberLabel" runat="server" Text='<%# Eval("AccountNumber") %>' />
            </td>
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td align="center">
              <asp:CheckBox ID="PreferredCheckBox" runat="server" Enabled="False"
                Checked='<%# Eval("PreferredVendorStatus") %>' />
            </td>
          </tr>
        </AlternatingItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="VendorsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT VendorID, AccountNumber, Name, PreferredVendorStatus 
          FROM Purchasing.Vendor WHERE (ActiveFlag = 1)" >
      </asp:SqlDataSource>
    </form>
  </body>
</html>
<%-- </Snippet1> --%>