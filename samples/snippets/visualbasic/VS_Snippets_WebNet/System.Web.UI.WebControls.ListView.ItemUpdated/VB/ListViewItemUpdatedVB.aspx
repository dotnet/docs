<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

    Sub Page_Load()
        Message.Text = String.Empty
    End Sub

    '<Snippet2>
    Sub ContactsListView_ItemUpdated(sender As Object, e As ListViewUpdatedEventArgs)
        If e.Exception IsNot Nothing Then
            If e.AffectedRows = 0 Then
                e.KeepInEditMode = True
                Message.Text = "An exception occurred updating the contact. " & _
                                    "Please verify your values and try again."
            Else
                Message.Text = "An exception occurred updating the contact. " & _
                                    "Please verify the values in the recently updated item."
            End If

            e.ExceptionHandled = True
        End If
    End Sub
   '</Snippet2>
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView.ItemUpdated Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ListView.ItemUpdated Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
      <br/>

      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemUpdated="ContactsListView_ItemUpdated"  
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" border="1" runat="server" id="tblContacts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
             <Fields>
               <asp:NextPreviousPagerField 
                ShowFirstPageButton="True" ShowLastPageButton="True"
                    FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                    NextPageText=" &gt; " PreviousPageText=" &lt; " />
             </Fields>
           </asp:DataPager>
         </LayoutTemplate>
         <ItemTemplate>
            <tr>
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
                <asp:TextBox ID="FirstNameTextBox" runat="server"
                  Text='<%# Bind("FirstName") %>' MaxLength="50" Width="200px" /><br />
                <asp:Label runat="server" ID="LastNameLabel" 
                  AssociatedControlID="LastNameTextBox" Text="Last Name" />
                <asp:TextBox ID="LastNameTextBox" runat="server" 
                  Text='<%# Bind("LastName") %>' MaxLength="50" Width="200px" /><br />
                <asp:Label runat="server" ID="EmailLabel" 
                  AssociatedControlID="EmailTextBox" Text="E-mail" />
                <asp:TextBox ID="EmailTextBox" runat="server" 
                  Text='<%# Bind("EmailAddress") %>' MaxLength="50" Width="200px" />
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