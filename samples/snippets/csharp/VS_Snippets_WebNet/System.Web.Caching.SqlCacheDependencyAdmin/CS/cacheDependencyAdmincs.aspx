<!-- <snippet10> -->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cacheDependencyAdmincs.aspx.cs"
  Inherits="cacheDependencyAdmincs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>Cache Dependency Administration</title>
</head>
<body>
  <form id="form1" runat="server">
    <table>
      <tr>
        <td colspan="2">
          Database support for change notifications:
        </td>
      </tr>
      <tr>
        <td align="center">
          <asp:Button ID="enableNotification" runat="server" Text="On" OnClick="enableNotification_Click" />
        </td>
        <td align="center">
          <asp:Button ID="disableNotification" runat="server" Text="Off" OnClick="disableNotification_Click" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Label ID="enabledTablesMsg" runat="server" Text="Tables enabled for change notification:" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:ListBox ID="enabledTables" runat="server" SelectionMode="multiple" /><br />
          <asp:Button ID="disableTable" runat="server" Text="Disable selected table(s)" OnClick="disableTable_Click" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:Label ID="tableEnableMsg" runat="server" Text="Enable change notification on table:" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:TextBox ID="tableName" runat="server" /><br />
          <asp:Button ID="enableTable" runat="server" Text="Enable table(s)" OnClick="enableTable_Click" />
          <asp:Label id="enableTableErrorMsg" runat="server" Visible="false" />
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
<!-- </snippet10> -->
