<%--<Snippet8>--%>
<%@ Page %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html >
<head id="Head1" runat="server">
  <title>Skip Navigation</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
  
  <asp:Menu 
    id="Menu1"
    Runat="server">
    <Items>
      <asp:MenuItem Text="Home" NavigateUrl="Home.aspx" />
      <asp:MenuItem Text="Products" NavigateUrl="Products.aspx" />
      <asp:MenuItem Text="Services" NavigateUrl="Services.aspx" />
      <asp:MenuItem Text="About" NavigateUrl="About.aspx" />
    </Items>
  </asp:Menu>

  <hr />

  Here is the main content of the page...

  </div>
  </form>
</body>
</html>
<%--</Snippet8>--%>
