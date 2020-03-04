<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void Page_Load(Object sender, EventArgs e)
  {
    TestLinkButton1.Text = "TestLinkButton Text";
  }

  protected void TestLinkButton1_Click(object sender, EventArgs e)
  {
    Label1.Text = "You clicked the link.";
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>TestLinkButton Example</title>
  </head>

  <body>
    <form id="Form1" 
          method="post" 
          runat="server">

      <aspSample:TestLinkButton 
        id="TestLinkButton1" 
        runat="server" 
        onclick="TestLinkButton1_Click" />

      <br />
      <br />

      <asp:Label
        id="Label1"
        runat="server"/>
        
    </form>
  </body>
</html>

