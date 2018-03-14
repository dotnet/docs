<%@ Page Language="C#" %>
<%@ Import Namespace="MS.ASPNET.Samples" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    CustomLabel cl = new CustomLabel();
    cl.Text = "text of custom label";
    Place1.Controls.Add(cl);
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test ControlBuilder</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:PlaceHolder id="Place1" runat="server">
      </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
