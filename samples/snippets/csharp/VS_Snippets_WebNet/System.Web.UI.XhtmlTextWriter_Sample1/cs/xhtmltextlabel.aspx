<!-- <Snippet4> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="AspNet.Samples" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    TestLabel tl = new TestLabel();
    tl.ID = "TestLabel1";
    PlaceHolder1.Controls.Add(tl);

  }
</script>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>XHtmlTextWriter Example</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->
