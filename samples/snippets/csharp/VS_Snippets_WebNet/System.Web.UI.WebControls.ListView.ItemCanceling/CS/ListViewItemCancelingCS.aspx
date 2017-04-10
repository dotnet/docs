<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  void Page_Load()
  {
    Message.Text = String.Empty;
  }

  // <Snippet2>
  protected void ContactsListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
  {
    //Check the operation that raised the event
    if (e.CancelMode == ListViewCancelMode.CancelingEdit)
    {
      // The update operation was canceled. Display the 
      // primary key of the item.
      Message.Text = "Update for the ContactID " + 
        ContactsListView.DataKeys[e.ItemIndex].Value.ToString()  + " canceled.";
    }
    else
    {
      Message.Text = "Insert operation canceled."; 
    }
  }
  // </Snippet2>

  protected void ContactsListView_PagePropertiesChanging(object sender, 
    PagePropertiesChangingEventArgs e)
  {
    // Clears the edit index selection when paging.
    ContactsListView.EditIndex = -1;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView ItemCanceling Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView ItemCanceling Example</h3>
      
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
                 
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        ConvertEmptyStringToNull="true"
        InsertItemPosition="LastItem"
        runat="server" 
        OnItemCanceling="ContactsListView_ItemCanceling" 
        OnPagePropertiesChanging="ContactsListView_PagePropertiesChanging" >
        <LayoutTemplate>
          <table cellpadding="2" width="680px" border="1" runat="server" id="tblContacts">
            <tr runat="server">
              <th runat="server">&nbsp;</th>
              <th runat="server">ID</th>
              <th runat="server">First Name</th>
              <th runat="server">Last Name</th>
              <th runat="server">E-mail Address</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td valign="top">
              <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" /><br />
            </td>
            <td valign="top">
              <asp:Label ID="Label1" runat="server" Text='<%#Eval("ContactID") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td valign="top">
              <asp:Label ID="EmailAddressLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
              &nbsp;
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr style="background-color: #ADD8E6">
            <td valign="top">
              <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" /><br />
              <asp:LinkButton ID="CancelEditButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <asp:Label ID="Label1" runat="server" Text='<%#Eval("ContactID") %>' />
            </td>
            <td>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' MaxLength="50" /><br />
            </td>
            <td>
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' MaxLength="50" /><br />
            </td>
            <td>
              <asp:TextBox ID="EmailAddressTextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' MaxLength="50" /><br />
            </td>
          </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
          <tr style="background-color:#90EE90">
            <td colspan="2">
              <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" /><br />
              <asp:LinkButton ID="CancelInsertButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>              
            <td>
              <asp:TextBox ID="FirstNameITextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' MaxLength="50" />
            </td>
            <td>
              <asp:TextBox ID="LastNameITextBox" runat="server" 
                Text='<%#Bind("LastName") %>' MaxLength="50" />
            </td>
            <td>
              <asp:TextBox ID="EmailAddressITextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' MaxLength="50" />
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
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] FROM Person.Contact"
        InsertCommand="INSERT INTO Person.Contact
                         ([FirstName], [LastName], [EmailAddress], [PasswordHash], [PasswordSalt]) 
                         Values(@FirstName, @LastName, @EmailAddress, '', '')"
        UpdateCommand="UPDATE Person.Contact
                         SET FirstName = @FirstName, LastName = @LastName,
                         EmailAddress = @EmailAddress
                         WHERE ContactID = @ContactID">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>