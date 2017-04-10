<%@ Page Language="VB" %>
<Script runat="server">
    Public Sub DisplayValues()
        If Not (IsNothing(Cache("key1"))) Then
            text1.InnerHtml = Cache("key1").ToString()
        Else
            text1.InnerHtml = "No value..."
        End If
 
        If Not (IsNothing(Cache("key2"))) Then
            text2.InnerHtml = Cache("key2").ToString()
        Else
            text2.InnerHtml = "No value..."
        End If
    End Sub

' <Snippet1>
    Public Sub CreateDependency(sender As Object, e As EventArgs)
        ' Create a cache entry.
        Cache("key1") = "Value 1"

        ' Make key2 dependent on key1.
        Dim dependencyKey(0) As String
        dependencyKey(0) = "key1"
        Dim dependency As new CacheDependency(Nothing, dependencyKey)

        Cache.Insert("key2", "Value 2", dependency)

        DisplayValues()
    End Sub
' </Snippet1>

    Public Sub Invalidate(sender As Object, e As EventArgs)
        Cache.Remove("key1")
        DisplayValues()
    End Sub
</Script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cache Key Dependency Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <h3>Cache Key Dependency example:</h3>
        Key 1: <b id="text1" runat="server"/><br />
        Key 2: <b id="text2" runat="server"/><br />  
        <input type="submit" id="submit1" value="Create Dependency" onserverclick="CreateDependency" runat="server" />
        <input type="submit" id="submit2" value="Invalidate Key 1" onserverclick="Invalidate" runat="server" />
    </form>
</body>
</html>
