<!--<Snippet1>-->
<%@ Page Language="C#" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        // Create a new HttpCookie.
        HttpCookie myHttpCookie = new HttpCookie("LastVisit", DateTime.Now.ToString());

        // By default, the HttpOnly property is set to false 
        // unless specified otherwise in configuration.

        myHttpCookie.Name = "MyHttpCookie";
        Response.AppendCookie(myHttpCookie);

        // Show the name of the cookie.
        Response.Write(myHttpCookie.Name);

        // Create an HttpOnly cookie.
        HttpCookie myHttpOnlyCookie = new HttpCookie("LastVisit", DateTime.Now.ToString());

        // Setting the HttpOnly value to true, makes
        // this cookie accessible only to ASP.NET.

        myHttpOnlyCookie.HttpOnly = true;
        myHttpOnlyCookie.Name = "MyHttpOnlyCookie";
        Response.AppendCookie(myHttpOnlyCookie);

        // Show the name of the HttpOnly cookie.
        Response.Write(myHttpOnlyCookie.Name);
    }
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