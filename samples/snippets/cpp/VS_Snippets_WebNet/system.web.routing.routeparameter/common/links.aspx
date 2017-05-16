<%--<Snippet2>--%>
<%@ Page %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Links Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Links Page
        </h1>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="<%$RouteUrl:routename=productroute,productname=LL Bottom Bracket%>">
            Product page for LL Bottom Bracket</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="<%$RouteUrl:productname=LL Bottom Bracket,culture=fr%>">
            Product page for LL Bottom Bracket (French)</asp:HyperLink>
    </div>
    </form>
</body>
</html>
<%--</Snippet2>--%>
