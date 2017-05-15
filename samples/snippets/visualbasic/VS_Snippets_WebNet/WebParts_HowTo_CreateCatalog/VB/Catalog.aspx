<%@ Page Language="VB"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Catalog Sample Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:WebPartManager ID="WebPartManager1" runat="server">
        </asp:WebPartManager>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate></ZoneTemplate>
        </asp:WebPartZone>
        <%--<snippet1>--%>
        <asp:CatalogZone ID="CZ1" runat="server">
            <ZoneTemplate>
                <asp:DeclarativeCatalogPart ID="DCP1" runat="server">
                    <WebPartsTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Label" />
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                    </WebPartsTemplate>
                </asp:DeclarativeCatalogPart>
            </ZoneTemplate>
        </asp:CatalogZone>
        <%--</snippet1>--%>
    </form>
</body>
</html>
