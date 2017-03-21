' Insert the cache item.
Dim dep As New CacheDependency(fileName, dt)
myCache.Insert("key", "value", dep)

' Check whether CacheDependency.HasChanged is true.
If dep.HasChanged Then
   Response.Write("<p>The dependency has changed.")
Else
   Response.Write("<p>The dependency has not changed.")
End If 