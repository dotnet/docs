<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' <Snippet2>
  Protected Sub ContactsListView_ItemCreated(ByVal sender As Object, ByVal e As ListViewItemEventArgs)
    
    ' Retrieve the current item.
    Dim item As ListViewItem = e.Item
    
    ' Verify if the item is a data item.
    If item.ItemType = ListViewItemType.DataItem Then
            
      ' Get the EmailAddressLabel Label control in the item.      
      Dim EmailAddressLabel As Label = CType(item.FindControl("EmailAddressLabel"), Label)
      
      ' Display the e-mail address in italics.
      EmailAddressLabel.Font.Italic = True
            
    End If

  End Sub
  ' </Snippet2>    
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListViewItem Example</title>
    <style type="text/css">
      body { text-align: center; }
      .bgcolor { background-color: #CAEEFF; }
    </style>
  </head>
  <body style="font: 10pt Trebuchet MS">
    <form id="form1" runat="server">
        
      <h3>ListViewItem Example</h3>
                       
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        InsertItemPosition="LastItem"
        OnItemCreated="ContactsListView_ItemCreated"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" width="680px" border="0">
            <tr class="bgcolor" runat="server">
              <th runat="server">First Name</th>
              <th runat="server">Last Name</th>
              <th runat="server">E-mail Address</th>
            </tr>
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager">
            <Fields>
              <asp:NumericPagerField ButtonCount="10" /> 
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server"> 
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailAddressLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr class="bgcolor">
            <td>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' MaxLength="50" />
            </td>
            <td>
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' MaxLength="50" /> <br />
            </td>
            <td>
              <asp:TextBox ID="EmailAddressTextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' MaxLength="50" /> <br />
            </td>
          </tr>
          <tr class="bgcolor" runat="server">
            <td colspan="3">
              <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
              <asp:Button ID="CancelInsertButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT FirstName, LastName, EmailAddress FROM Person.Contact"
        InsertCommand="INSERT INTO Person.Contact
         ([FirstName], [LastName], [EmailAddress], [PasswordHash], [PasswordSalt]) 
         Values(@FirstName, @LastName, @EmailAddress, '', '')">
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<%-- </Snippet1> --%>