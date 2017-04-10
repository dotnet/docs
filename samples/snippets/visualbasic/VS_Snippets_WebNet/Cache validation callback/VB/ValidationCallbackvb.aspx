<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ OutputCache VaryByParam="none" Duration="600" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
   shared validationstate As String

   Public Sub Page_Load(sender As Object, e As EventArgs)
      Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(AddressOf Me.ValidateCache), nothing)
      stamp.InnerHtml = DateTime.Now.ToString("r")
   End Sub

   Public Shared Sub ValidateCache(context As HttpContext, data As Object, ByRef status as HttpValidationStatus)
      If (context.Request.QueryString("Valid") = "false") Then
         status = HttpValidationStatus.Invalid
      Elseif (context.Request.QueryString("Valid") = "ignore") Then
         status = HttpValidationStatus.IgnoreThisRequest
      Else
         status = HttpValidationStatus.Valid
      End If
   End Sub

</script>
<!--</Snippet1>-->

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b id="stamp" runat="server"/>
    </div>
    </form>
</body>
</html>
