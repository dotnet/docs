<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
<%--<snippet4>--%>
      <%
         Dim charArray As Char() = {"H"c, "e"c, "l"c, "l"c, "o"c, ","c, " "c, _
                                 "w"c, "o"c, "r"c, "l"c, "d"c}
         ' Write a character array to the client.
         Response.Write(charArray, 0, charArray.Length)

         ' Write a single character.
         Response.Write(";"c)

         ' Write a sub-section of a character array to the client.
         Response.Write(charArray, 0, 5)
' <snippet6>
         ' Write an object to the client.
         Dim obj As Object
         obj = CType(13, Object)
         Response.Write(obj)
' </snippet6>
      %>

<%--</snippet4>--%>
    </form>
</body>
</html>
