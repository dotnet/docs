<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  ' <Snippet2>
  Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
    
    ' Check if an item is selected to delete it.
    If ContactsListView.SelectedIndex >= 0 Then
      ContactsListView.DeleteItem(ContactsListView.SelectedIndex)
    Else
      Message.Text = "No contact was selected."
    End If
    
  End Sub
  ' </Snippet2>
    
  Protected Sub ContactsListView_ItemDeleted(ByVal sender As Object, _
    ByVal e As ListViewDeletedEventArgs)
    
    ' Check if an exception occurred to display an error message.
    If Not (e.Exception Is Nothing) Then
      Message.Text = "An exception occurred deleting the contact."
      e.ExceptionHandled = True
    Else
      ' Clear the selected index.
      ContactsListView.SelectedIndex = -1
    End If
    
  End Sub

  Protected Sub ContactsListView_PagePropertiesChanging(ByVal sender As Object, _
    ByVal e As PagePropertiesChangingEventArgs)
    
    ' Clear the selected index.
    ContactsListView.SelectedIndex = -1
    
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    ' Clear the message label.
    Message.Text = ""
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView DeleteItem Example</title>
    <style type="text/css">
      body
      {
        font-size: 10pt;
        font-family: Trebuchet MS, Arial, Tahoma;
        text-align:center;
      }
      .item { background-color: #E0FFFF }
      .selectedItem { background-color: #B0E0E6 }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView DeleteItem Example</h3>
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource"
        DataKeyNames="ContactID"
        OnItemDeleted="ContactsListView_ItemDeleted"
        OnPagePropertiesChanging="ContactsListView_PagePropertiesChanging"
        runat="server" >
        <LayoutTemplate>
          <table cellpadding="2" width="640px" id="tblProducts" runat="server">
            <tr runat="server">
              <th runat="server">&nbsp;</th>
              <th runat="server">ID</th>
              <th runat="server">Account Number</th>
              <th runat="server">LastName</th>
              <th runat="server">Preferred Vendor</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager ID="ContactsDataPager" runat="server" PageSize="15">
            <Fields>
              <asp:NextPreviousPagerField ButtonType="Button"
                ShowFirstPageButton="true"
                ShowNextPageButton="false"
                ShowPreviousPageButton="false" />
              <asp:NumericPagerField ButtonCount="10" />
              <asp:NextPreviousPagerField ButtonType="Button"
                ShowLastPageButton="true"
                ShowNextPageButton="false"
                ShowPreviousPageButton="false" />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr class="item" runat="server">
            <td>
              <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
            </td>
            <td>
              <asp:Label ID="ContactIDLabel" runat="server" Text='<%# Eval("ContactID") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr class="selectedItem" runat="server">
            <td>&nbsp;</td>
            <td>
              <asp:Label ID="ContactIDLabel" runat="server" Text='<%# Eval("ContactID") %>' />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("EmailAddress") %>' />
            </td>
          </tr>
        </SelectedItemTemplate>
      </asp:ListView>
      <br />
      <br />
           
      <asp:Button ID="DeleteButton"       
        Text="Delete Selected Contact"
        OnClick="DeleteButton_Click"
        runat="server" />
      <br />

      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"            
        SelectCommand="SELECT ContactID, FirstName, LastName, EmailAddress 
          FROM Person.Contact" 
        DeleteCommand="DELETE FROM Person.Contact WHERE (ContactID = @ContactID)" >
      </asp:SqlDataSource>      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>