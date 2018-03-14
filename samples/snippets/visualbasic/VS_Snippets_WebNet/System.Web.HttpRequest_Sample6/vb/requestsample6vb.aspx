<%@ Page Language="VB" Debug="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
     
  Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' <snippet1>
    Request.SaveAs("c:\\temp\\HttpRequest.txt", True)
    ' </snippet1>
    
  End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>

</body>
</html>

