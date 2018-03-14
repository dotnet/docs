<!-- <Snippet2> -->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">

  Sub ContactsListView_ItemDeleted(sender As Object, e As ListViewDeletedEventArgs)

    ' Display the value of the key fields in the Keys property.
    KeysMessageLabel.Text = _
      "The key fields for the deleted record are: <br/>"

    For Each entry As DictionaryEntry In e.Keys
      DisplayValue(entry, KeysMessageLabel)
    Next

    ' Display the value of the non-key fields in the Values 
    ' property.
    ValuesMessageLabel.Text = _
      "The non-key fields for the deleted record are: <br/>"

    For Each entry As DictionaryEntry In e.Values
      DisplayValue(entry, ValuesMessageLabel)
    Next
  End Sub

  Sub DisplayValue(entry As DictionaryEntry, displayLabel As Label)

    ' Display the field name contained in the DictionaryEntry object.
    If entry.Key IsNot Nothing Then
      displayLabel.Text &= "Name=" & entry.Key.ToString() & ", "
    Else
      displayLabel.Text &= "Name=null, "
    End If

    ' Display the field value contained in the DictionaryEntry object.
    If entry.Value IsNot Nothing
      displayLabel.Text &= "Value=" & entry.Value.ToString() & "<br/>"
    else
      displayLabel.Text &= "Value=null<br/>"
    End If
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListViewDeletedEventArgs Keys and Values Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListViewDeletedEventArgs Keys and Values Example</h3>
            
      <asp:Label ID="Message"
        ForeColor="Red"          
        runat="server"/>
                
      <br/>
      
      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemDeleted="ContactsListView_ItemDeleted"  
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" runat="server" id="tblContacts" width="640px">
            <tr id="itemPlaceholder" runat="server"></tr>
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
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Bind("FirstName") %>' />
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Bind("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Bind("EmailAddress") %>' />
            </td>
            <td>
              <asp:LinkButton ID="DeleteButton" runat="server" 
                CommandName="Delete" 
                Text="Delete" 
                OnClientClick="return confirm('Are you sure?');" />
            </td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
                 
      <br/><br />
         
      <asp:Label ID="KeysMessageLabel"
        ForeColor="Red"
        runat="server"/>
          
      <br/>
          
      <asp:Label ID="ValuesMessageLabel"
        ForeColor="Red"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->            
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] FROM Person.Contact"
        DeleteCommand="DELETE FROM Person.Contact WHERE [ContactID] = @ContactID">
          <DeleteParameters>
              <asp:Parameter Name="ContactID" Type="Int32" />
          </DeleteParameters>
      </asp:SqlDataSource>

    </form>
  </body>
</html>
<!-- </Snippet2> -->