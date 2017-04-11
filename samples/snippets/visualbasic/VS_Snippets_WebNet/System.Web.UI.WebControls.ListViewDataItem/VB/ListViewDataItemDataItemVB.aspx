<%-- <Snippet1> --%>
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
        
  '<Snippet2>
  Protected Sub ContactsListView_ItemDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) 
      
    'Verify there is an item being edited.
    If ContactsListView.EditIndex >= 0 Then
      
      'Get the item object.
      Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
      
      ' Check for an item in edit mode.
      If dataItem.DisplayIndex = ContactsListView.EditIndex Then
          
        ' Preselect the DropDownList control with the Title value
        ' for the current item.
        ' Retrieve the underlying data item. In this example
        ' the underlying data item is a DataRowView object.        
        Dim rowView As DataRowView = CType(dataItem.DataItem, DataRowView)
        
        ' Retrieve the Title value for the current item. 
        Dim title As String = rowView("Title").ToString()
        
        ' Retrieve the DropDownList control from the current row. 
        Dim list As DropDownList = CType(dataItem.FindControl("TitlesList"), DropDownList)
        
        ' Find the ListItem object in the DropDownList control with the 
        ' title value and select the item.
        Dim item As ListItem = list.Items.FindByText(title)
        list.SelectedIndex = list.Items.IndexOf(item)
      End If 
    End If

  End Sub
  '</Snippet2>
  
  Sub ContactsListView_ItemUpdating(ByVal sender As Object, ByVal e As ListViewUpdateEventArgs) 
  
    ' Retrieve the row being edited.
    Dim item As ListViewItem = ContactsListView.Items(ContactsListView.EditIndex)
    
    ' Retrieve the DropDownList control from the row.
    Dim list As DropDownList = CType(item.FindControl("TitlesList"), DropDownList)
    
    ' Add the selected value of the DropDownList control to 
    ' the NewValues collection. The NewValues collection is
    ' passed to the data source control, which then updates the 
    ' data source.
    e.NewValues("Title") = list.SelectedValue

  End Sub 'ContactsListView_ItemUpdating
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView DataItem Example</title>
    <link type="text/css" rel="stylesheet" href="StyleSheet.css" />
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListViewDataItem Example</h3>

      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemUpdating="ContactsListView_ItemUpdating"         
      	OnItemDataBound="ContactsListView_ItemDataBound"
      	runat="server" >
        <LayoutTemplate>
          <table cellpadding="2" runat="server" id="tblContacts" width="640px">
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
          <tr class="DataItem" runat="server">
            <td>
              <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
            </td>
            <td>
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
            </td>
            <td>
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>
              <asp:Label ID="TitleLabel" runat="server" Text='<%#Eval("Title", "{0:d}") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <EditItemTemplate>
          <tr class="EditItem">
            <td>
              <asp:LinkButton ID="UpdateButton" runat="server" 
                CommandName="Update" Text="Update" /><br />
              <asp:LinkButton ID="CancelButton" runat="server" 
                CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <asp:Label runat="server" ID="FirstNameLabel" 
                AssociatedControlID="FirstNameTextBox" Text="First Name:"/>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' MaxLength="50" />
            </td>
            <td>
              <asp:Label runat="server" ID="LastNameLabel" 
                AssociatedControlID="LastNameTextBox" Text="Last Name:" />
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' MaxLength="50" /><br />
            </td>              
            <td>
              <asp:Label runat="server" ID="TitleLabel" 
                AssociatedControlID="TitlesList" Text="Title:"/>
              <asp:DropDownList ID="TitlesList" 
                DataSourceID="TitlesSqlDataSource" 
                DataTextField="Title"
                runat="server">
              </asp:DropDownList>
            </td>
          </tr>
        </EditItemTemplate>
      </asp:ListView>
            
      <asp:SqlDataSource ID="TitlesSqlDataSource"  
        SelectCommand="SELECT Distinct [Title] FROM Person.Contact ORDER BY [Title]"
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        runat="server">
      </asp:SqlDataSource>
              
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
            SelectCommand="SELECT [ContactID], [FirstName], [LastName], [Title] FROM Person.Contact"
            UpdateCommand="UPDATE Person.Contact
                             SET FirstName = @FirstName, LastName = @LastName, Title = @Title
                             WHERE ContactID = @ContactID">
        <UpdateParameters>
          <asp:Parameter ConvertEmptyStringToNull="true" Name="Title" />
        </UpdateParameters>                             
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>