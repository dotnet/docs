<%-- <Snippet1> --%>
<%@ Page language="C#" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView Example</title>
    <style type="text/css">
        .EditItem { background-color:#8FBC8F;}
        .SelectedItem {	background-color:#9ACD32; }
        .InsertItem { background-color:#FFFACD;}
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
        
      <h3>ListView Example</h3>
      
      <h5>Departments</h5>

      <asp:ListView ID="DepartmentsListView" 
        DataSourceID="DepartmentsDataSource" 
        DataKeyNames="DepartmentID"
        ConvertEmptyStringToNull="true"
        InsertItemPosition="LastItem"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" runat="server" id="tblDepartments" width="640px" cellspacing="0">
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td>
              <asp:Button ID="SelectButton" runat="server" Text="Select" CommandName="Select" />
              <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
            </td>
            <td>
              <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("DepartmentID") %>' />
            </td>
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td>
              <asp:Label ID="GroupNameLabel" runat="server" Text='<%#Eval("GroupName") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr class="SelectedItem" runat="server">
            <td>
              <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" />
              <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
            </td>
            <td>
              <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("DepartmentID") %>' />
            </td>
            <td>
              <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
            </td>
            <td>
              <asp:Label ID="GroupNameLabel" runat="server" Text='<%#Eval("GroupName") %>' />
            </td>
          </tr>
        </SelectedItemTemplate>
        <EditItemTemplate>
          <tr class="EditItem">
            <td>
              <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
              <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <b>ID</b><br />
              <asp:Label ID="IDLabel" runat="server" Text='<%#Eval("DepartmentID") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="NameLabel" AssociatedControlID="NameTextBox" 
                Text="Name" Font-Bold="true"/><br />
              <asp:TextBox ID="NameTextBox" runat="server" Text='<%#Bind("Name") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="GroupNameLabel" AssociatedControlID="GroupNameTextBox" 
                Text="Group Name" Font-Bold="true" /><br />
              <asp:TextBox ID="GroupNameTextBox" runat="server" 
                Width="200px"
                Text='<%#Bind("GroupName") %>' />
              <br />
            </td>
          </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
          <tr class="InsertItem">
            <td colspan="2">
              <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
              <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </td>
            <td>
              <asp:Label runat="server" ID="NameLabel" AssociatedControlID="NameTextBox" 
                Text="Name" Font-Bold="true"/><br />
              <asp:TextBox ID="NameTextBox" runat="server" Text='<%#Bind("Name") %>' /><br />
            </td>
            <td>
              <asp:Label runat="server" ID="GroupNameLabel" AssociatedControlID="GroupNameTextBox" 
                Text="Group Name" Font-Bold="true" /><br />                
              <asp:TextBox ID="GroupNameTextBox" runat="server" Text='<%#Bind("GroupName") %>' />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->            
      <asp:SqlDataSource ID="DepartmentsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
            SelectCommand="SELECT DepartmentID, Name, GroupName FROM HumanResources.Department"
            UpdateCommand="UPDATE HumanResources.Department 
                SET Name = @Name, GroupName = @GroupName WHERE (DepartmentID = @DepartmentID)"            
	        DeleteCommand="DELETE FROM HumanResources.Department 
	            WHERE (DepartmentID = @DepartmentID)" 
	        InsertCommand="INSERT INTO HumanResources.Department(Name, GroupName) 
	            VALUES (@Name, @GroupName)">
      </asp:SqlDataSource>
      
    </form>
  </body>
</html>
<%-- </Snippet1> --%>