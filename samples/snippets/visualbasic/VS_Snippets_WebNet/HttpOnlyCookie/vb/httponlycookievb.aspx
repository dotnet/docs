<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Create a new HttpCookie.
    Dim myHttpCookie As New HttpCookie("LastVisit", DateTime.Now.ToString())

    ' By default, the HttpOnly property is set to false 
    ' unless specified otherwise in configuration.

    myHttpCookie.Name = "MyHttpCookie"
    Response.AppendCookie(myHttpCookie)

    ' Show the name of the cookie.
    Response.Write(myHttpCookie.Name)

    ' Create an HttpOnly cookie.
    Dim myHttpOnlyCookie As New HttpCookie("LastVisit", DateTime.Now.ToString())

    ' Setting the HttpOnly value to true, makes
    ' this cookie accessible only to ASP.NET.

    myHttpOnlyCookie.HttpOnly = True
    myHttpOnlyCookie.Name = "MyHttpOnlyCookie"
    Response.AppendCookie(myHttpOnlyCookie)

    ' Show the name of the HttpOnly cookie.
    Response.Write(myHttpOnlyCookie.Name)

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
<script type="text/javascript">
function getCookie(NameOfCookie)
{
  if (document.cookie.length > 0) 
  { 
    begin = document.cookie.indexOf(NameOfCookie+"="); 
    if (begin != -1)
    { 
    begin += NameOfCookie.length+1; 
      end = document.cookie.indexOf(";", begin);
      if (end == -1) end = document.cookie.length;
      return unescape(document.cookie.substring(begin, end));       
    } 
  }
  return null;  
}
</script>

<script type="text/javascript">

// This code returns the cookie name.
alert("Getting HTTP Cookie");
alert(getCookie("MyHttpCookie"));

// Because the cookie is set to HttpOnly,
// this returns null.
alert("Getting HTTP Only Cookie");
alert(getCookie("MyHttpOnlyCookie"));

</script> 

</body>
</html>

<!--</Snippet1>-->