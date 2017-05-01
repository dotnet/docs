<%@ debug="true" language="VB" %>
<%@ OutputCache Duration="100" varybyparam="none" %>
<script runat="server">
' <snippet1>
  Sub Page_Load(sender As [Object], ev As EventArgs)
     Dim c As BasePartialCachingControl = Parent 
        If Not (c Is Nothing) Then
' <snippet2>
        c.Dependency = New CacheDependency(MapPath("dep1.txt"))
' </snippet2>
     End If
  End Sub 'Page_Load
' </snippet1> 
</script>

The date and time on the user control is: <%= DateTime.Now %><br />
