<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Example</h3>
                       
      <asp:ListView ID="VendorsListView"
        DataSourceID="VendorsDataSource"
        DataKeyNames="VendorID"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="640px" border="1" ID="tbl1" runat="server">
            <tr runat="server" style="background-color: #98FB98">
              <th runat="server">ID</th>
              <th runat="server">Account Number</th>
              <th runat="server">Name</th>
              <th runat="server">Preferred Vendor</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager ID="DataPager1" runat="server">
            <Fields>
              <asp:NumericPagerField />
            </Fields>
          </asp:DataPager>
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
              <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></td>
            <td>
              <asp:CheckBox ID="PreferredCheckBox" runat="server" 
                Checked='<%# Eval("PreferredVendorStatus") %>' Enabled="False" />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects   -->
      <!-- to the AdventureWorks sample database. Add a LINQ     -->
      <!-- to SQL class to the project to map to a table in      -->
      <!-- the database.                                         -->
      <asp:LinqDataSource ID="VendorsDataSource" runat="server" 
        ContextTypeName="AdventureWorksClassesDataContext" 
        Select="new (VendorID, AccountNumber, Name, PreferredVendorStatus)" 
        TableName="Vendors" Where="ActiveFlag == @ActiveFlag">
        <WhereParameters>
          <asp:Parameter DefaultValue="true" Name="ActiveFlag" Type="Boolean" />
        </WhereParameters>
      </asp:LinqDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>