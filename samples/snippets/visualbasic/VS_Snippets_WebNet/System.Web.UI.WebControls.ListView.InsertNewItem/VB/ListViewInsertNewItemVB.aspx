<%-- <Snippet1> --%>
<%@ Page language="VB" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub InsertButton_Click(ByVal sender As Object, _
                                   ByVal e As EventArgs)
    
    ' Clears any existing message.
    MessageLabel.Text = ""
    
    ' Use the InsertNewItem method to programmatically insert
    ' the current record in the ListView control.
    DepartmentsListView.InsertNewItem(True)
    
  End Sub

  Protected Sub DepartmentsListView_ItemInserted(ByVal sender As Object, _
                                                 ByVal e As ListViewInsertedEventArgs)
  
    ' Handles exceptions that might occur
    ' during the insert operation.
    If Not (e.Exception Is Nothing) Then
      If e.AffectedRows = 0 Then
        e.KeepInInsertMode = True
        MessageLabel.Text = "An exception occurred inserting the new department. " & _
              "Please verify your values and try again."
      Else
        MessageLabel.Text = "An exception occurred inserting the new department. " & _
              "Please verify the values in the newly inserted item."
      End If
        
      e.ExceptionHandled = True
    End If

  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView InsertNewItem Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView InsertNewItem Example</h3>
      
      <h5>Departments</h5>

      <asp:ListView ID="DepartmentsListView" 
        DataSourceID="DepartmentsDataSource" 
        DataKeyNames="DepartmentID"
        InsertItemPosition="FirstItem"
        OnItemInserted="DepartmentsListView_ItemInserted"
        runat="server" >
        <LayoutTemplate>
          <table runat="server" id="tblDepartments" width="640px" border="1">
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Label ID="NameLabel" runat="Server" Text='<%#Eval("Name") %>' />
            </td>
            <td>
              <asp:Label ID="GroupNameLabel" runat="Server" Text='<%#Eval("GroupName") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr style="background-color:#00BFFF">
            <td>
              <asp:Label runat="server" ID="NameLabel" AssociatedControlID="NameTextBox" 
                Text="Name:" Font-Bold="true"/><br />
              <asp:TextBox ID="NameTextBox" runat="server" Text='<%#Bind("Name") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="GroupNameLabel" AssociatedControlID="GroupNameTextBox" 
                Text="Group Name:" Font-Bold="true" /><br />
              <asp:TextBox ID="GroupNameTextBox" runat="server" 
                Text='<%#Bind("GroupName") %>' MaxLength="50" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView><br />
              
      <asp:Label ID="MessageLabel"
        ForeColor="Red"
        runat="server" /> <br />

      <asp:Button ID="InsertButton"
        Text="Insert new record"
        OnClick="InsertButton_Click"
        runat="server"  />
    
      <!-- This example uses Microsoft SQL Server and connects    -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET  -->
      <!-- expression to retrieve the connection string value     -->
      <!-- from the Web.config file.                              -->            
      <asp:SqlDataSource ID="DepartmentsDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT DepartmentID, Name, GroupName FROM HumanResources.Department"
        InsertCommand="INSERT INTO HumanResources.Department(Name, GroupName) 
	            VALUES (@Name, @GroupName)">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>