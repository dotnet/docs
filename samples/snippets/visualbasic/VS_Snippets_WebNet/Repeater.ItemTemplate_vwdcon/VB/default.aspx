<!-- <snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>ASP.NET Repeater Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
          <table>
            <tr>
              <th>
                Name</th>
              <th>
                Description</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
          <tr>
            <td style="background-color:#CCFFCC">
              <asp:Label runat="server" ID="Label1" Text='<%# Eval("CategoryName") %>' />
            </td>
            <td style="background-color:#CCFFCC">
              <asp:Label runat="server" ID="Label2" Text='<%# Eval("Description") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
          <tr>
            <td>
              <asp:Label runat="server" ID="Label3" Text='<%# Eval("CategoryName") %>' />
            </td>
            <td>
              <asp:Label runat="server" ID="Label4" Text='<%# Eval("Description") %>' />
            </td>
          </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
          </table>
        </FooterTemplate>
      </asp:Repeater>
      <asp:SqlDataSource ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        ID="SqlDataSource1" runat="server" SelectCommand="SELECT [CategoryID], [CategoryName], 
            [Description] FROM [Categories]"></asp:SqlDataSource>
    </div>
  </form>
</body>
</html>
<!-- </snippet1>-->
