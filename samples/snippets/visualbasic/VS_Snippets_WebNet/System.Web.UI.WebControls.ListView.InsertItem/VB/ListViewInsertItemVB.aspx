<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub CountriesListView_ItemInserting(ByVal sender As Object, _
                                                ByVal e As ListViewInsertEventArgs)
    
    ' Get the controls that are contained in the insert item.
    Dim countryCodeTextBox As TextBox = _
      CType(CountriesListView.InsertItem.FindControl("CountryCodeTextBox"), TextBox)
    Dim nameTextBox As TextBox = _
      CType(CountriesListView.InsertItem.FindControl("NameTextBox"), TextBox)
    
    'Check if the controls are empty.
    If countryCodeTextBox.Text.Trim().Length = 0 _
    OrElse nameTextBox.Text.Trim().Length = 0 Then
      MessageLabel.Text = "The system could not insert the item. All fields are required."
      e.Cancel = True
      Return
    End If

  End Sub
 
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) 
    'Clear the message label.
    MessageLabel.Text = ""
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView InsertItem Example</title>
    <style type="text/css">
      body  { font: 10pt Trebuchet MS, Arial, Tahoma; }
      th { background: #8FBC8F; }
      .item td { border: 1px solid #8FBC8F; }
      .insertItem td  { background: #D3D3D3; }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
       
      <h3>ListView InsertItem Example</h3>
      
      <asp:ListView ID="CountriesListView" 
        DataSourceID="CountryDataSource"
        DataKeyNames="CountryRegionCode"
        InsertItemPosition="LastItem"
        runat="server" 
        oniteminserting="CountriesListView_ItemInserting">
        <LayoutTemplate>
          <table cellpadding="4" width="500" runat="server" id="tblCountries">
            <tr runat="server">
              <th runat="server">Code</th>
              <th runat="server">Name</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager ID="CountriesPager" runat="server" PageSize="20">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" />
            </Fields>
          </asp:DataPager>          
        </LayoutTemplate>
        <ItemTemplate>
          <tr class="item" runat="server">
            <td>
              <asp:Label ID="CountryCodeLabel" runat="server" 
                Text='<%# Eval("CountryRegionCode")%>' />
            </td>          
            <td>
              <asp:Label ID="NameLabel" runat="server" 
                Text='<%# Eval("Name")%>' />
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr class="insertItem">
            <td align="right">Code:</td>
            <td align="left">
              <asp:TextBox ID="CountryCodeTextBox" runat="server" 
                Text='<%# Bind("CountryRegionCode")%>' 
                MaxLength="3" />
            </td>
          </tr>
          <tr class="insertItem">
            <td align="right">Name:</td>
            <td align="left">
              <asp:TextBox ID="NameTextBox" runat="server" 
                Text='<%# Bind("Name")%>' 
                MaxLength="50" />
            </td>
          </tr>
          <tr class="insertItem" runat="server">
            <td colspan="2" align="center">
              <asp:Button ID="InsertButton" runat="server" 
                CommandName="Insert" Text="Insert" />
              <asp:Button ID="CancelButton" runat="server" 
                CommandName="Cancel" Text="Clear" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>
      <br /><br />
                
      <asp:Label ID="MessageLabel"
        ForeColor="Red"
        runat="server" />

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->      
      <asp:SqlDataSource ID="CountryDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [CountryRegionCode], [Name]
          FROM [Person].[CountryRegion]"
        InsertCommand="INSERT INTO Person.CountryRegion(CountryRegionCode, Name) 
          VALUES (@CountryRegionCode, @Name)">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>