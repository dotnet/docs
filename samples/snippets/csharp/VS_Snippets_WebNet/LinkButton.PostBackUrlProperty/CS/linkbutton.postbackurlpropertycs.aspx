<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>LinkButton.PostBackUrl Example</title>
</head>
<body>    
  <form id="form1" runat="server">
    
    <h3>LinkButton.PostBackUrl Example</h3>

    Enter a value to post:
    <asp:textbox id="TextBox1" 
      runat="Server">
    </asp:textbox>

    <br /><br />

    <asp:linkbutton id="LinkButton1" 
      text="Post back to this page"
      runat="Server">
    </asp:linkbutton>

    <br /><br />

    <asp:linkbutton id="LinkButton2"
      text="Post value to another page" 
      postbackurl="LinkButton.PostBackUrlPage2cs.aspx" 
      runat="Server">
    </asp:linkbutton>

  </form>
</body>
</html>
<!--</Snippet1>-->

