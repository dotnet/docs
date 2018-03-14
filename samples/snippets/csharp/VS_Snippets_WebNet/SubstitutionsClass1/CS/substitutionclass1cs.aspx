<!--<Snippet1>-->
<%@ outputcache duration="60" varybyparam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" language="C#">  
  
  void Page_Load(object sender, System.EventArgs e)
  {
    // Display the current date and time in the label.
    // Output caching applies to this section of the page.
    CachedDateLabel.Text = DateTime.Now.ToString();    
  }
  
  // The Substitution control calls this method to retrieve
  // the current date and time. This section of the page
  // is exempt from output caching. 
  public static string GetCurrentDateTime (HttpContext context)
  {
    return DateTime.Now.ToString ();
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Substitution Class Example</title>
</head>
<body>
  <form id="form1" runat="server">
  
    <h3>Substitution Class Example</h3>  
    
    <p>This section of the page is not cached:</p>
    
    <asp:substitution id="Substitution1"
      methodname="GetCurrentDateTime"
      runat="Server">
    </asp:substitution>
    
    <br />
    
    <p>This section of the page is cached:</p>
    
    <asp:label id="CachedDateLabel"
      runat="Server">
    </asp:label>
    
    <br /><br />
    
    <asp:button id="RefreshButton"
      text="Refresh Page"
      runat="Server">
    </asp:button>     

  </form>
</body>
</html>
<!--</Snippet1>-->
