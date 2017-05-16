<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
<script language="VB" runat="server">

' The following example demonstrates the SetValidUntilExpires method of the
' HttpCachePolicy class. The SetValidUntilExpires method is set to true so that
' the ASP.NET cache ignores the HTTP Cache-Control headers and the page remains 
' in the cache until it expires.

Sub Page_Load(Sender As Object, e As EventArgs)
   ' Set the expiration time for the page.
   Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
   ' Set the VaryByHeaders attribute with the value Accept-Language to true.
   Response.Cache.VaryByHeaders("Accept-Language") = True
   ' ASP.NET ignores cache invalidation headers and the page remains in
   ' the cache until it expires.
   Response.Cache.SetValidUntilExpires(True)
   Response.Write("The SetValidUntilExpires method is set to true and the ASP.NET cache will " _
      & " ignore the Cache-Control headers sent by the client that invalidate the cache.")
End Sub 'Page_Load

</script>
</head>
<body></body>
</html>
<!-- </Snippet1> -->