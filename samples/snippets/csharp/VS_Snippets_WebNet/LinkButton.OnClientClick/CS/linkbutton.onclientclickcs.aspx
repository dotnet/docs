<!--<Snippet1>-->
<%@ page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
void LinkButton1_Click (object sender, EventArgs e)
  {
    Label1.Text = "Thank you for visiting our site.";
  }
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>LinkButton.OnClientClick Example</title>
</head>
<body>
  <form id="form1" runat="server">
    
    <h3>LinkButton.OnClientClick Example</h3> 
     
      <br />
      
      <h4>Click to navigate to Microsoft.com:</h4>     
      
      <br />
        
      <asp:linkbutton id="LinkButton1"
       text="Open Web site"
       onclientclick="Navigate()"
       onclick="LinkButton1_Click"
       runat="Server" />
       
       <br /><br />
       
      <asp:label id="Label1"
        runat="Server">
      </asp:label>

    </form>
    
    <script type="text/javascript">
      function Navigate()
      {
        javascript:window.open("http://www.microsoft.com");
      }    
      
    </script>
</body>
</html>
<!--</Snippet1>-->
