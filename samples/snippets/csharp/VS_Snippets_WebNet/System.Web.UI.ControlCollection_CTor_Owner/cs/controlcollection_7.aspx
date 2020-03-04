<%@ Page Language="C#" Trace="true" %>
<%@ Register Namespace="ASPNET.Samples.CS" TagPrefix="CustomControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <CustomControl:ParentControl ID="ParentControl1" runat="server">
       </CustomControl:ParentControl>
    </div>
    </form>
</body>
</html>
