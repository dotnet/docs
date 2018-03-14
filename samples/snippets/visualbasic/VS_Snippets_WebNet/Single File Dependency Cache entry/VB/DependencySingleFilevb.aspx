<%@ Page Language="VB" %>
<Script runat="server">
    Public Sub Page_Load(sender As Object, e As EventArgs)
        If (Not IsNothing(Cache("key1"))) Then
            text1.InnerHtml = Cache("key1").ToString()
        Else
            text1.InnerHtml = "No value..."
' <Snippet1>
            ' Make key1 dependent on a file.
            Dim dependency as new CacheDependency(Server.MapPath("isbn.xml"))

            Cache.Insert("key1", "Value 1", dependency)
        End If
' </Snippet1>
    End Sub
</Script>
Cache key dependency example:<BR>
Key 1: <B id="text1" runat="server"/><BR>
