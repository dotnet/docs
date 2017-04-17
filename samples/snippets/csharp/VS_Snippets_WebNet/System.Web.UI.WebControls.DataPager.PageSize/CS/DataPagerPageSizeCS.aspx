<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void ResultsList_SelectedIndexChanged(object sender, EventArgs e)
  {
    // Set the page size with the value
    // selected in the DropDownList object
    VendorsDataPager.PageSize = Convert.ToInt32(ResultsList.SelectedValue);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>DataPager PageSize Example</title>
</head>
<body>
    <form id="form1" runat="server">
      
      <h3>DataPager PageSize Example</h3>
      
      <table border="0" width="640px">
        <tr>
          <td align="left">
            <asp:Label id="ResultsLabel" runat="server" 
              AssociatedControlID="ResultsList" Text="Results per page:" />            
            <asp:DropDownList runat="server" id="ResultsList" 
              OnSelectedIndexChanged="ResultsList_SelectedIndexChanged" AutoPostBack="true">              
              <asp:ListItem Value="10"  />
              <asp:ListItem Value="15" Selected="True" />
              <asp:ListItem Value="20" />
            </asp:DropDownList>
          </td>
          <td align="right">
            <asp:DataPager ID="VendorsDataPager" runat="server" 
              PagedControlID="VendorsListView" PageSize="15">
              <Fields>
                <asp:NumericPagerField />
              </Fields>
            </asp:DataPager>          
          </td>
        </tr>
      </table>
      <br />
      
      <asp:ListView ID="VendorsListView" 
        DataSourceID="VendorsDataSource"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px">
              <tr runat="server" id="itemPlaceholder"></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
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
              <asp:CheckBox ID="PreferredCheckBox" runat="server" 
                Checked='<%# Eval("PreferredVendorStatus") %>' Enabled="False" />
            </td>
          </tr>
        </ItemTemplate>
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