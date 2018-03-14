<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub LoginLink_OnClick(sender As Object, args As EventArgs)
  FormsAuthentication.SignOut()
  FormsAuthentication.RedirectToLoginPage(GetQueryString())
End Sub

Private Function GetQueryString() As String
  Dim queryString As String = ""

  Dim qs As NameValueCollection = Request.QueryString

  For Each key As String In qs.AllKeys
    For Each value As String In qs.GetValues(key)
      queryString &= Server.UrlEncode(key) & "=" & Server.UrlEncode(value) & "&"
    Next
  Next

  Return queryString.TrimEnd("&")  
End Function

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<form id="form1" runat="server">
Welcome <b><%=User.Identity.Name%></b>. Not <b><%=User.Identity.Name%></b>? 
Click <asp:LinkButton id="LoginLink" Text="here" 
                      OnClick="LoginLink_OnClick" runat="server" />
to sign in.

<!-- Page Contents -->

</form>



</body>
</html>
<!-- </Snippet3> -->