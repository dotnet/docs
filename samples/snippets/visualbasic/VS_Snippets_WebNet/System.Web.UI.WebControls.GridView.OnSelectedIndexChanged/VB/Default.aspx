<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub ContactsGridView_SelectedIndexChanged()
    If ContactsGridView.SelectedIndex >= 0 Then
      ViewState("SelectedKey") = ContactsGridView.SelectedValue
    Else
      ViewState("SelectedKey") = Nothing
    End If
  End Sub

  Protected Sub ContactsGridView_DataBound()
    For i As Integer = 0 To ContactsGridView.Rows.Count - 1
      ' Ignore values that cannot be cast as integer.
      Try
        If Convert.ToInt32(ContactsGridView.DataKeys(i).Value) = Convert.ToInt32(ViewState("SelectedKey")) Then _
          ContactsGridView.SelectedIndex = i
      Catch
      End Try
    Next
  End Sub

  Protected Sub ContactsGridView_Sorting()
    ContactsGridView.SelectedIndex = -1
  End Sub

  Protected Sub ContactsGridView_PageIndexChanging()
    ContactsGridView.SelectedIndex = -1
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>GridView OnSelectedIndexChanged Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView OnSelectedIndexChanged Example</h3>
      
      <asp:GridView ID="ContactsGridView"
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"        
        AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="ContactsGridView_SelectedIndexChanged"        
        AllowPaging="True" AllowSorting="True" 
        OnDataBound="ContactsGridView_DataBound" 
        OnSorting="ContactsGridView_Sorting" 
        OnPageIndexChanging="ContactsGridView_PageIndexChanging"
        runat="server">
        <SelectedRowStyle BackColor="Aqua" />
      </asp:GridView>
            
      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="ContactsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT [ContactID], [FirstName], [LastName] FROM Person.Contact">
      </asp:SqlDataSource>


    </form>
  </body>
</html>
<%-- </Snippet1> --%>