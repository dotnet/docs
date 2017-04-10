<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' <Snippet1>
    Response.Cache.VaryByHeaders.AcceptTypes = True
    ' </Snippet1>
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpCacheVaryByHeaders Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
