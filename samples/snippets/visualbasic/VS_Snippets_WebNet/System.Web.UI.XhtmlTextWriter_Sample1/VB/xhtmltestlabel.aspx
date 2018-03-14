<!-- <Snippet4> -->
<%@ Page Language="VB"   %>
<%@ Import Namespace="AspNet.Samples" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim tl As TestLabel = New TestLabel()
    tl.ID = "TestLabel1"
    PlaceHolder1.Controls.Add(tl)
    
  End Sub
  
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