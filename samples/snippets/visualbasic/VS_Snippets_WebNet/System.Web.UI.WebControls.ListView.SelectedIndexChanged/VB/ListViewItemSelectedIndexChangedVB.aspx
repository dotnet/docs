<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
    
  '<Snippet2>
  Sub ContactsListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    If ContactsListView.SelectedIndex >= 0 Then
      ViewState("SelectedKey") = ContactsListView.SelectedDataKey.Value
    Else
      ViewState("SelectedKey") = Nothing
    End If
  End Sub

  Sub ContactsListView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    For i As Integer = 0 To ContactsListView.Items.Count - 1
      ' Ignore values that cannot be cast as integer.
      Try
        If Convert.ToInt32(ContactsListView.DataKeys(i).Value) = Convert.ToInt32(ViewState("SelectedKey")) Then _
          ContactsListView.SelectedIndex = i
      Catch
      End Try
    Next
  End Sub
  '</Snippet2>

  Sub ContactsListView_PagePropertiesChanged(ByVal sender As Object, ByVal e As EventArgs)
    ContactsListView.SelectedIndex = -1
  End Sub

  Sub ContactsListView_Sorting(ByVal sender As Object, ByVal e As ListViewSortEventArgs)
    ContactsListView.SelectedIndex = -1
  End Sub

  Sub ClearButton_Click(ByVal sender As Object, ByVal e As EventArgs)
    ViewState("SelectedKey") = Nothing
    ContactsListView.SelectedIndex = -1
  End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView SelectedIndex Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView SelectedIndex Example</h3>

      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnDataBound="ContactsListView_DataBound"
        OnSelectedIndexChanged="ContactsListView_SelectedIndexChanged"  
        OnPagePropertiesChanged="ContactsListView_PagePropertiesChanged"
        OnSorting="ContactsListView_Sorting"
        runat="server">
        <LayoutTemplate>
          <asp:Button runat="server" ID="SortButton" 
            CommandArgument="LastName" CommandName="Sort" Text="Sort" />
          <asp:Button runat="server" ID="ClearButton" 
            OnClick="ClearButton_Click" Text="Clear Selection" /><br />
          <table cellpadding="2" border="1" runat="server" id="tblContacts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="20">
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
              <asp:LinkButton ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr runat="server" style="background-color:#B0C4DE">
            <td valign="top">
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
            <td>&nbsp;</td>
          </tr>
        </SelectedItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName], [EmailAddress] 
          FROM Person.Contact">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>