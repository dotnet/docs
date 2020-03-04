<%@ Page Language="VB" AutoEventWireup="true" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    TestLinkButton1.Text = "TestLinkButton Text"

  End Sub

  Protected Sub TestLinkButton1_Click(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)

    Label1.Text = "You clicked the link."

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div>
    
      <aspSample:TestLinkButton 
        id="TestLinkButton1" 
        runat="server" 
        onclick="TestLinkButton1_Click" />

      <br />
      <br />

      <asp:Label
        id="Label1"
        runat="server"/>

    </div>
    </form>
</body>
</html>
