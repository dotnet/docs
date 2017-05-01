<!-- <snippet1>-->
<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  void _OnSelectedIndexChanged(Object sender, EventArgs e)
  { 
    Response.Redirect(DropDownList1.SelectedItem.Value);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DropDownList Bound to SiteMapDataSource</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="Server"
          StartFromCurrentNode="true"
          ShowStartingNode="false" />
      <asp:DropDownList ID="DropDownList1" Runat="Server" 
          DataSourceID="SiteMapDataSource1"
          AutoPostBack="True" 
          DataTextField="Title" 
          DataValueField="Url"
          OnSelectedIndexChanged="_OnSelectedIndexChanged" >
      </asp:DropDownList>
    </div>
    </form>
</body>
</html>
<!-- </snippet1>-->