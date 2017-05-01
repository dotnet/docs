<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
    
  Sub Page_Load()
    Message.Text = String.Empty
  End Sub
  
  '<Snippet2>
  Sub ContactsListView_ItemUpdating(ByVal sender As Object, ByVal e As ListViewUpdateEventArgs)
    
    ' Cancel the update operation if any of the fields is empty
    ' or null.
    For Each de As DictionaryEntry In e.NewValues
      ' Check if the value is null or empty
      If de.Value Is Nothing OrElse de.Value.ToString().Trim().Length = 0 Then
        Message.Text = "Cannot set a field to an empty value."
        e.Cancel = True
      End If
    Next
    
    ' Convert the e-mail address to lowercase.
    Dim emailValue As String = e.NewValues("EmailAddress").ToString()    
    e.NewValues("EmailAddress") = emailValue.ToLower()
    
  End Sub
  '</Snippet2>
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView.ItemUpdating Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView.ItemUpdating Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>

      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemUpdating="ContactsListView_ItemUpdating"  
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
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
            <td>
              <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr style="background-color:#ADD8E6">
            <td valign="top">
              <asp:Label runat="server" ID="FirstNameLabel" 
                AssociatedControlID="FirstNameTextBox" Text="First Name"/>
              <asp:TextBox ID="FirstNameTextBox" runat="server" Width="200px"
                Text='<%#Bind("FirstName") %>' MaxLength="50" /><br />
              <asp:Label runat="server" ID="LastNameLabel" 
                AssociatedControlID="LastNameTextBox" Text="Last Name" />
              <asp:TextBox ID="LastNameTextBox" runat="server" Width="200px"
                Text='<%#Bind("LastName") %>' MaxLength="50" /><br />
              <asp:Label runat="server" ID="EmailLabel"
                AssociatedControlID="EmailTextBox" Text="E-mail" />
              <asp:TextBox ID="EmailTextBox" runat="server" Width="200px"
                Text='<%#Bind("EmailAddress") %>' MaxLength="50" />
            </td>
            <td colspan="2" valign="top">
              <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
              <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
          </tr>
        </EditItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
          FROM Person.Contact"
        UpdateCommand="UPDATE Person.Contact
          Set [FirstName] = @FirstName, [LastName] = @LastName, [EmailAddress] = @EmailAddress 
          WHERE [ContactID] = @ContactID">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>