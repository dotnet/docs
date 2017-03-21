    Public Sub CreateDependency(sender As [Object], e As EventArgs)
      ' Create a cache entry.
      Cache("key1") = "Value 1"
   
      ' Make key2 dependent on key1 using double dependency.
      Dim dependencyKey(0) As [String]
      dependencyKey(0) = "key1"
      Dim dep1 As New CacheDependency(Nothing, dependencyKey)
   
      ' Make a second CacheDependency dependent on dep1.        
      Dim dep2 As New CacheDependency(Nothing, Nothing, dep1)
   
      Cache.Insert("key2", "Value 2", dep2)
   
      DisplayValues()
   End Sub 'CreateDependency