<!-- <Snippet1> -->
<%@ Page language="c#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpCachePolicy - SetAllowResponseInBrowserHistory - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e) 
      {
        // When HttpCacheability is set to NoCache or ServerAndNoCache 
        // the Expires HTTP header is set to -1 by default. This instructs 
        // the client to not cache responses in the History folder. Thus, 
        // each time you use the back/forward buttons, the client requests 
        // a new version of the response. 
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        
        // Override the ServerAndNoCache behavior by setting the SetAllowInBrowserHistory 
        // method to true. This directs the client browser to store responses in  
        // its History folder.
        HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true);
        
        // Display the DateTime value.
        Label1.Text = DateTime.Now.ToLongTimeString();
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>HttpCachePolicy - SetAllowResponseInBrowserHistory - C# Example</h3>
      
      <p>Click the Submit button a few times, and then click the Browser's Back button.<br />
        The page should be stored in the Browser's History folder</p>
        
      <p>Time: <asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red" /></p>
      
      <asp:Button id="Button1" runat="server" Text="Submit" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
