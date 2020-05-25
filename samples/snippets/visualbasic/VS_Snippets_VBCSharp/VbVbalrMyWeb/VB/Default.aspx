<!-- 
   ' 626359bc-3165-40b4-bfaf-2c610e26eb5b
    ' My.Response Object

    ' 93d5f0e2-6b60-4a2c-8652-d90216f6ad10
    ' My.Request Object
-->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<!-- <Snippet1> -->
<script runat="server">
    Public Sub ShowHeaders()
        ' Load the header collection from the Request object.
        Dim coll As System.Collections.Specialized.NameValueCollection
        coll = My.Request.Headers

        ' Put the names of all keys into a string array.
        For Each key As String In coll.AllKeys
            My.Response.Write("Key: " & key & "<br>")

            ' Get all values under this key.
            For Each value As String In coll.GetValues(key)
                My.Response.Write("Value: " & _
                    Server.HtmlEncode(value) & "<br>")
            Next
        Next
    End Sub
</script>
<!-- </Snippet1> -->
<script runat="server">
    Public Sub Method1(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowHeaders()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>My.Request and My.Response Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button id="Button1"
                Text="Show request headers"
                OnClick="Method1" 
                runat="server"/>
        </div>
    </form>
</body>
</html>
