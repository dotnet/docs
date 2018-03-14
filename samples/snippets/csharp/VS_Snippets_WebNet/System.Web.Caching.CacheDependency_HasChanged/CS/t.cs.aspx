<%@ page language="c#" %>
<%@ import namespace="System.Web.Caching" %>
<%@ import namespace="System.IO"%>
<%@ import namespace="System.Globalization"%>
<%@ import namespace="System.Threading"%>
<%@ import namespace="System.Reflection"%>
<%@ import namespace="Microsoft.Win32"%>

<% 
Cache cache = HttpRuntime.Cache;
DateTime dt = DateTime.Now;

// write to the dependent file
String fileName = Server.MapPath("CachingCacheInsert701.txt");
FileStream fs = new FileStream(fileName, 
		    FileMode.Create, 
		    FileAccess.ReadWrite, 
		    FileShare.ReadWrite);
TextWriter writer = TextWriter.Synchronized(new StreamWriter(fs));
fs.Seek(0, SeekOrigin.End);
writer.WriteLine("{0}", DateTime.Now);
writer.WriteLine("key -> [{0}]", "key");  
writer.WriteLine("value -> [{0:r}]", "value");  
writer.Close();
fs.Close();
// <snippet1>
// Insert the cache item.
CacheDependency dep = new CacheDependency(fileName, dt);
cache.Insert("key", "value", dep);

// Check whether CacheDependency.HasChanged is true.
if (dep.HasChanged)
  Response.Write("<p>The dependency has changed.");  
else Response.Write("<p>The dependency has not changed.");
// </snippet1>

// <snippet2>
// Retrieve the cached item.
Object obj = cache.Get("key");
if (obj == null)
  Response.Output.WriteLine("<p>The dependency changed. The cache item returns null.");
else
  Response.Output.WriteLine("<p>Insert701-value: {0:r}", (DateTime) obj);
// </snippet2>  
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
