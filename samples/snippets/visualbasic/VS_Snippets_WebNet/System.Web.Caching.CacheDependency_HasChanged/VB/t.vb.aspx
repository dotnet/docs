<%@ page language="VB" %>
<%@ import namespace="System.Web.Caching" %>
<%@ import namespace="System.IO"%>
<%@ import namespace="System.Globalization"%>
<%@ import namespace="System.Threading"%>
<%@ import namespace="System.Reflection"%>
<%@ import namespace="Microsoft.Win32"%>

<%
Dim myCache As System.Web.Caching.Cache = HttpRuntime.Cache
Dim dt As DateTime = DateTime.Now

' write to the dependent file
Dim fileName As [String] = Server.MapPath("CachingCacheInsert701.txt")
Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
Dim writer As TextWriter = TextWriter.Synchronized(New StreamWriter(fs))
fs.Seek(0, SeekOrigin.End)
writer.WriteLine("{0}", DateTime.Now)
writer.WriteLine("key -> [{0}]", "key")
writer.WriteLine("value -> [{0:r}]", "value")
writer.Close()
fs.Close()

' <snippet1>
' Insert the cache item.
Dim dep As New CacheDependency(fileName, dt)
myCache.Insert("key", "value", dep)

' Check whether CacheDependency.HasChanged is true.
If dep.HasChanged Then
   Response.Write("<p>The dependency has changed.")
Else
   Response.Write("<p>The dependency has not changed.")
End If 
' </snippet1>

' <snippet2>
' Retrieve the cached item.
Dim obj As [Object] = myCache.Get("key")
If obj Is Nothing Then
   Response.Output.WriteLine("<p>The dependency changed. The cache item returns Nothing.")
Else
   Response.Output.WriteLine("<p>Insert701-value: {0:r}", CType(obj, DateTime))
End If
' </snippet2>
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
