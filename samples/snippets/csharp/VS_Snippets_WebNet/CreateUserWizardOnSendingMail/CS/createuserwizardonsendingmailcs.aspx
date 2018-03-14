<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<%@ Import namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
private void Page_Load(object sender, EventArgs e) {    
    Placeholder1.Controls.Add(new CustomCreateUserWizard());
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>CreateUserWizard.OnSendingMail sample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:placeholder id="Placeholder1" runat="server" >
      </asp:placeholder>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->