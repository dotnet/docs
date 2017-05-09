<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageButton.PostBackUrl Example</title>
</head>
<body>    
  <form id="form1" runat="server">
    
    <h3>ImageButton.PostBackUrl Example</h3>

    Enter a value to post:
    <asp:textbox id="TextBox1" 
      runat="Server">
    </asp:textbox>

    <br /><br />

    <asp:imagebutton id="ImageButton1"
      imageUrl=""
      alternatetext="Post back to this page"
      runat="Server">
    </asp:imagebutton>

    <br /><br />

    <asp:imagebutton id="ImageButton2"
      imageUrl=""
      alternatetext="Post value to another page" 
      postbackurl="ImageButton.PostBackUrlPage2cs.aspx" 
      runat="Server">
    </asp:imagebutton>

  </form>
</body>
</html>
<!--</Snippet1>-->

