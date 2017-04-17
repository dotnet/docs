<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  //<Snippet3>
  void ContactsListView_ItemInserted(Object sender, ListViewInsertedEventArgs e)
  {
    if (e.Exception != null)
    {
      if (e.AffectedRows == 0)
      {
        e.KeepInInsertMode = true;
        Message.Text = "An exception occurred inserting the new Contact. " +
          "Please verify your values and try again.";
      }
      else
        Message.Text = "An exception occurred inserting the new Contact. " +
          "Please verify the values in the newly inserted item.";

      e.ExceptionHandled = true;
    }
  }
  //</Snippet3>

  protected void Page_Load(object sender, EventArgs e)
  {
    Message.Text = "";
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView.ItemInserted Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListViewItemInserted Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>
      
      <%-- <Snippet2> --%>
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemInserted="ContactsListView_ItemInserted"  
        InsertItemPosition="LastItem"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" border="1" runat="server" id="tblContacts" width="640px">
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
            </td>
            <td>&nbsp;
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr style="background-color:#D3D3D3">
            <td valign="top">
              <asp:Label runat="server" ID="FirstNameLabel" 
                AssociatedControlID="FirstNameTextBox" Text="First Name"/>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' /><br />
              <asp:Label runat="server" ID="LastNameLabel" 
                AssociatedControlID="LastNameTextBox" Text="Last Name" />
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' /><br />
              <asp:Label runat="server" ID="EmailLabel" 
                AssociatedControlID="EmailTextBox" Text="E-mail" />
              <asp:TextBox ID="EmailTextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' />
            </td>
            <td>
              <asp:LinkButton ID="InsertButton" runat="server" 
                CommandName="Insert" Text="Insert" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>
      <%-- </Snippet2> --%>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
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