<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="AspNet.Samples" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    SimpleLabel sl = new SimpleLabel();
    sl.ID = "SimpleLabel1";
    sl.Text = "SimpleLabel Text";
    PlaceHolder1.Controls.Add(sl);

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CHtmlTextWriter Example</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
