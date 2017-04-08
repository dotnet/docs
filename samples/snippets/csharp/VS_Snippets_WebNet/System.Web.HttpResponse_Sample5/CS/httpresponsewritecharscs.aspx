<%@ Page Language="C#" %>
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

        // Create a character array.
    char[] charArray = {'H', 'e', 'l', 'l', 'o', ',', ' ', 
                           'w', 'o', 'r', 'l', 'd'};

        // Write a character array to the client.
        Response.Write(charArray, 0, charArray.Length);

        // Write a single characher.
        Response.Write(';');

        // Write a sub-section of a character array to the client.
        Response.Write(charArray, 0, 5);
// <snippet6>
        // Write an object to the client.
        object obj = (object)13;
        Response.Write(obj);
// </snippet6>

    %>
<%--</snippet4>     --%>
    </form>
</body>
</html>
