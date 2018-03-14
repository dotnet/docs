<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="Links"  Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<Snippet70>--%>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/salesreportsummary/2010">
            Sales Report - All locales, 2010
        </asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/salesreport/WA/2011">
            Sales Report - WA, 2011
        </asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/expensereport">
            Expense Report - Default Locale and Year (US, current year)
        </asp:HyperLink>
        <br />
        <%--</Snippet70>--%>
        <%--<Snippet80>--%>
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="<%$RouteUrl:year=2011%>">
            Sales Report - All locales, 2011
        </asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="<%$RouteUrl:locale=CA,year=2009,routename=salesroute%>">
            Sales Report - CA, 2009
        </asp:HyperLink>
        <br />
        <%--</Snippet80>--%>
        <%--<Snippet100>--%>
        <asp:HyperLink ID="HyperLink6" runat="server">
            Expense Report - CA, 2008
        </asp:HyperLink>
        <br />
        <%--</Snippet100>--%>
    </div>
    </form>
</body>
</html>
