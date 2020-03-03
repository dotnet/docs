<%--<Snippet9>--%>
<%@ Page %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Meaningful Link Text</title>
    <style type="text/css">
        #leftColumn
        {
            float: left;
            width: 45%;
            border: 1px solid black;
            padding: 10px;
        }
        
        #rightColumn
        {
            float: right;
            width: 45%;
            border: 1px solid black;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="leftColumn">
        <strong>Providing Skip-Navigation Links</strong><br />
        With a simple modification to a navigation bar, 
        you can dramatically improve the
        accessibility of your Web pages.
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Default.aspx">
            Read more.
        </asp:HyperLink>
        <br />
        <br />
        <strong>Providing Meaningful Link Text</strong><br />
        Providing complete and accurate text for hyperlinks 
        is an important navigational
        aid for all users of a Web page and is an important 
        search engine optimization technique.
        However, it is also important for users of screen readers.
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/Default.aspx">
            Read more.
        </asp:HyperLink>
    </div>
    <div id="rightColumn">
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/Default.aspx">
            <strong>Providing Skip-Navigation Links</strong>
        </asp:HyperLink><br />
        With a simple modification to a navigation bar, 
        you can dramatically improve the
        accessibility of your Web pages.
        <br />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/Default.aspx">
            <strong>Providing Meaningful Link Text</strong>
        </asp:HyperLink><br />
        Providing complete and accurate text for hyperlinks 
        is an important navigational
        aid for all users of a Web page and is an important 
        search engine optimization technique.
        However, it is also important for users of screen readers.
    </div>
    </form>
</body>
</html>
<%--</Snippet9>--%>
