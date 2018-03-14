<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    ' <Snippet1>

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Show success or failure of page load.
        If Response.StatusCode <> 200 Then
            Response.Write("There was a problem accessing the web resource." & _
                "<br />" & Response.StatusDescription)
        End If

    End Sub
    ' </Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Page For HttpResponse.StatusCode</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
