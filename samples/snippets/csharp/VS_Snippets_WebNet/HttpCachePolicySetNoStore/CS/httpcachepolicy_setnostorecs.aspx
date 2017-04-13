<!-- <Snippet1> -->
<%@ Page language="c#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpCachePolicy - SetNoStore - C# Example</title>
    <script runat="server">
      void Page_Load(Object sender, EventArgs e) 
      {
        // Prevent the browser from caching the ASPX page
        Response.Cache.SetNoStore();
        
        // Display the DateTime value.
        Label1.Text = DateTime.Now.ToLongTimeString();
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>HttpCachePolicy - SetNoStore - C# Example</h3>
      
      <p>Click the Submit button a few times, and then click the Browser's Back button.<br />
      You should get a "Warning: Page has Expired" error message.</p>
      
      <p>Time:  <asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red" /></p>
      
      <asp:Button id="Button1" runat="server" Text="Submit" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
