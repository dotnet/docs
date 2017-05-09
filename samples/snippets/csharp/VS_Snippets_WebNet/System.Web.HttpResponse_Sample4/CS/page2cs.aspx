<%--<snippet2>--%>
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    // When this page is loaded, the Pics method
    // sets the PICS-Label header for the response.
    private void Page_Load(object sender, EventArgs e)
    {
        Response.Pics( 
          "(pics-1.1 <http://www.icra.org/ratingsv02.html> " + 
          "comment <ICRAonline EN v2.0> " + 
          "l r (nz 1 vz 1 lz 1 oz 1 cz 1) " + 
          "<http://www.rsac.org/ratingsv01.html> " +
          " l r (n 0 s 0 v 0 l 0))");
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <img height="75%" src="animated.gif" width="100%" alt="An animated GIF"/>
    </form>
</body>
</html>
<%--</snippet2>--%>
