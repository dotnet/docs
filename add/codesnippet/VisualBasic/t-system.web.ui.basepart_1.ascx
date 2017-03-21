  Sub Page_Load(sender As [Object], ev As EventArgs)
     Dim c As BasePartialCachingControl = Parent 
        If Not (c Is Nothing) Then
        c.Dependency = New CacheDependency(MapPath("dep1.txt"))
     End If
  End Sub 'Page_Load