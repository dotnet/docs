<!--<Snippet1>-->
<%@ page language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

void Button1_Click (object sender, EventArgs e)
  {
    Label1.Text = "Thank you for visiting our site.";

  }
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>Button.OnClientClick Example</title>
</head>
<body>
  <form id="form1" runat="server">
    
    <h3>Button.OnClientClick Example</h3> 
     
      
      <h4>Click to navigate to Microsoft.com:</h4>     
              
      <asp:button id="Button1"
       usesubmitbehavior="true"
       text="Open Web site"
       onclientclick="Navigate()"
       runat="server" onclick="Button1_Click" />
       
       <p></p>
      <asp:label id="Label1"
        runat="server">
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

