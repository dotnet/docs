<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="true" %>
<%@ Register Namespace="UpdatePanelTutorialCustom.VB" TagPrefix="sample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Browse Products</title>
    <script runat="server">
        Protected Sub ProductsView1_RowCommand(ByVal sender As Object, ByVal e As EventArgs)
            ShoppingCartList.DataSource = ProductsView1.Cart
            ShoppingCartList.DataBind()
        End Sub
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="false" />
        <h2>Browse Products</h2>
        <sample:ProductsView runat="server" ID="ProductsView1" PageSize="5" OnRowCommand="ProductsView1_RowCommand" />
                                 
        <asp:UpdatePanel runat="server" ID="CartUpdatePanel">
          <ContentTemplate>
            <h3>Selected Items</h3>
            <asp:BulletedList BulletStyle="numbered" runat="server" ID="ShoppingCartList" />
          </ContentTemplate>
        </asp:UpdatePanel>
     </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
