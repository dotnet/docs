<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

   ' <Snippet2>
  Protected Sub PreferredCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) 
  
    ' Gets the CheckBox object that fired the event.
    Dim chkBox As CheckBox = CType(sender, CheckBox)
    
    ' Gets the item that contains the CheckBox object. 
    Dim item As ListViewDataItem = CType(chkBox.Parent.Parent, ListViewDataItem)
    
    ' Update the database with the changes.
    VendorsListView.UpdateItem(item.DisplayIndex, False)    

  End Sub
  ' </Snippet2>
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView UpdateItem Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView UpdateItem Example</h3>
      
      <asp:ListView ID="VendorsListView" 
        DataSourceID="VendorsDataSource"
        DataKeyNames="VendorID"
        runat="server">
        <LayoutTemplate>
          Select your preferred vendors:
          <ul runat="server" id="lstVendors" style="text-align:left">
            <li runat="server" id="itemPlaceholder" />
          </ul>
          <asp:DataPager ID="VendorsDataPager" runat="server" PageSize="15">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <li runat="server">
            <asp:CheckBox runat="server" ID="PreferredCheckBox" AutoPostBack="True" 
              Checked='<%# Bind("PreferredVendorStatus") %>' 				        
              OnCheckedChanged="PreferredCheckBox_CheckedChanged" />
            <asp:Label runat="server" ID="NameLabel" text='<%# Eval("Name") %>' /><br/>
          </li>
        </ItemTemplate>
      </asp:ListView>
      
      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->
      <asp:SqlDataSource ID="VendorsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT VendorID, Name, PreferredVendorStatus
          FROM Purchasing.Vendor WHERE (ActiveFlag = 1)" 
        UpdateCommand="UPDATE Purchasing.Vendor 
          SET PreferredVendorStatus = @PreferredVendorStatus 
          WHERE (VendorID = @VendorID)" >
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<%-- </Snippet1> --%>