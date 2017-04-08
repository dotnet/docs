<!--<Snippet1>-->
<%@ outputcache duration="60" varybyparam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" language="C#">  
  
  // The Substitution control calls this method to retrieve
  // the name of the current user from the HttpContext object. 
  // This section of the page is exempt from output caching. 
  public static string GetUser(HttpContext context)
  {
    return context.User.Identity.Name;
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Substitution.MethodName Property Example</title>
</head>
<body>
  <form id="Form1" runat="server">
  
    <h3>Substitution.MethodName Property Example</h3>  
    
    <!--This section of the page is not cached.-->
    Welcome to the site,
    <asp:substitution id="Substitution1"
      methodname="GetUser"
      runat="Server">
    </asp:substitution>
    
    <br /><br />
    
    <!--This section of the page is cached.-->
    Product list:
    <asp:bulletedlist id="ItemsBulletedList"             
      displaymode="Text" 
      runat="server">    
        <asp:ListItem>Product 1</asp:ListItem>
        <asp:ListItem>Product 2</asp:ListItem>
        <asp:ListItem>Product 3</asp:ListItem>
    </asp:bulletedlist>        

  </form>
</body>
</html>
<!--</Snippet1>-->
