<!-- <Snippet5> -->
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="VB_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
        DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID" 
        InsertCommand="INSERT INTO [Employees] ([LastName], [FirstName]) VALUES (@LastName, @FirstName)" 
        SelectCommand="SELECT [EmployeeID], [LastName], [FirstName] FROM [Employees]" 
        UpdateCommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName WHERE [EmployeeID] = @EmployeeID">
        <DeleteParameters>
          <asp:Parameter Name="EmployeeID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
          <asp:Parameter Name="LastName" Type="String" />
          <asp:Parameter Name="FirstName" Type="String" />
          <asp:Parameter Name="EmployeeID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
          <asp:Parameter Name="LastName" Type="String" />
          <asp:Parameter Name="FirstName" Type="String" />
        </InsertParameters>
      </asp:SqlDataSource>
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="EmployeeID" 
        DataSourceID="SqlDataSource1">
        <Columns>
          <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" 
            InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
          <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
            <EditItemTemplate>
              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:TextBox ID="LastNameTextBox" runat="server" MaxLength="20" 
                Text='<%# Bind("LastName") %>'></asp:TextBox>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
            <EditItemTemplate>
              <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:TextBox ID="FirstNameTextBox" runat="server" MaxLength="10" 
                Text='<%# Bind("FirstName") %>'></asp:TextBox>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <asp:Button ID="UpdateButton" runat="server" Height="26px" Text="Update" />
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet5> -->