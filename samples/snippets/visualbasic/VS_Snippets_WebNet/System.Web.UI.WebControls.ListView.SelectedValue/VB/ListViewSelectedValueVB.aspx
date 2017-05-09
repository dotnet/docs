<!-- <Snippet1> -->
<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub DepartmentsListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) 
  
    MessageLabel.Text = "The key value is " & _
      DepartmentsListView.SelectedValue.ToString() & "."

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>ListView SelectedValue Example</title>
    <style type="text/css">
      .header
      {
        border: 1px solid #008080;
        background-color: #008080;
        color: White;
      }
      .item td { border: 1px solid #008080; }
      .selection td  
      {
        border: 1px solid #008080; 
        background-color: #7FFF00;
      }
    </style>
  </head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ListView SelectedValue Example</h3>
            
      <asp:ListView runat="server" 
        ID="DepartmentsListView"
        DataSourceID="DepartmentDataSource" 
        DataKeyNames="DepartmentID" 
        OnSelectedIndexChanged="DepartmentsListView_SelectedIndexChanged">
        <LayoutTemplate>
          <b>Department List</b>
          <br />
          <table width="500px" runat="server" id="tblDepartments">
            <tr class="header" runat="server">
              <th runat="server">&nbsp;</th>
              <th runat="server">Department Name</th>
              <th runat="server">Group Name</th>
            </tr>
            <tr runat="server" id="itemPlaceholder" />
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr class="item" runat="server">
            <td>
              <asp:LinkButton runat="server" 
                ID="SelectButton" 
                Text="Select"
                CommandName="Select" />
            </td>
            <td>
              <asp:Label runat="server" ID="NameLabel" Text='<%#Eval("Name") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="GroupNameLabel" Text='<%#Eval("GroupName") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
          <tr class="selection" runat="server">
            <td>&nbsp;</td>
            <td>
              <asp:Label runat="server" ID="NameLabel" Text='<%#Eval("Name") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="GroupNameLabel" Text='<%#Eval("GroupName") %>' />
            </td>
          </tr>
        </SelectedItemTemplate>
      </asp:ListView>
      <br/>
      
      <asp:Label ID="MessageLabel"
        ForeColor="Red"
        runat="server"/>

      <!-- This example uses Microsoft SQL Server and connects      -->
      <!-- to the AdventureWorks sample database. Use an ASP.NET    -->
      <!-- expression to retrieve the connection string value       -->
      <!-- from the Web.config file.                                -->
      <asp:SqlDataSource ID="DepartmentDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorks_DataConnectionString %>"
        SelectCommand="SELECT DepartmentID, Name, GroupName 
          FROM HumanResources.Department">
      </asp:SqlDataSource>
                       
    </form>
  </body>
</html>
<!-- </Snippet1> -->