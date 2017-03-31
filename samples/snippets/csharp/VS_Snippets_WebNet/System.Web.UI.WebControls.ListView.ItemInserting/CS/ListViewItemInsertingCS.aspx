<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
    
  void Page_Load()
  {
    Message.Text = String.Empty;
  }

  //<Snippet2>
  void ContactsListView_ItemInserting(Object sender, ListViewInsertEventArgs e)
  {
    // Iterate through the values to verify if they are not empty.
    foreach (DictionaryEntry de in e.Values)
    {
      if (de.Value == null)
      {
        Message.Text = "Cannot insert an empty value.";
        e.Cancel = true;
      }
    }
  }
  //</Snippet2>

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView.ItemInserting Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView.ItemInserting Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
     
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemInserting="ContactsListView_ItemInserting"  
        InsertItemPosition="LastItem"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" border="1" runat="server" id="tblProducts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
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
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
              &nbsp;
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
              &nbsp;
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr style="background-color:#B0C4DE">
            <td valign="top">
              <asp:Label runat="server" ID="FirstNameLabel" 
                AssociatedControlID="FirstNameTextBox" Text="First Name"/>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' MaxLength="50" /><br />
              <asp:Label runat="server" ID="LastNameLabel" 
                AssociatedControlID="LastNameTextBox" Text="Last Name" />
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' MaxLength="50" /><br />
              <asp:Label runat="server" ID="EmailLabel" 
                AssociatedControlID="EmailTextBox" Text="E-mail" />
              <asp:TextBox ID="EmailTextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' MaxLength="50" /><br />
            </td>
            <td>
              <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>
            
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
          FROM Person.Contact"
        InsertCommand="INSERT INTO Person.Contact
                       ([FirstName], [LastName], [EmailAddress], [PasswordHash], [PasswordSalt]) 
                       Values(@FirstName, @LastName, @EmailAddress, '', '');
                       SELECT @ContactID = SCOPE_IDENTITY()">
        <InsertParameters>
          <asp:Parameter Name="FirstName" />
          <asp:Parameter Name="LastName" />
          <asp:Parameter Name="EmailAddress" />
          <asp:Parameter Name="ContactID" Type="Int32" Direction="Output" />
        </InsertParameters>
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>