<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Protected Function CustomBGColor() As String
        Return ConfigurationManager.AppSettings("CustomBGColor")
    End Function
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Sample Web Application</title>
</head>
<body style="background-color:<%=CustomBGColor%>">
<form runat="server" id="Form1">
    Body background color:
    <%=CustomBGColor%>
</form>    
</body>
</html>
<!-- </snippet1> -->
