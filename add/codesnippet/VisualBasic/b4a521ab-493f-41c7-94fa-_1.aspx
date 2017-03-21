    Public Sub CreateDependency(sender As [Object], e As EventArgs)
      ' Create a DateTime object.
      Dim dt as DateTime = DateTime.Now.AddSeconds(10)        

      ' Create a cache entry.
      Cache("key1") = "Value 1"
   
      ' Make key2 dependent on key1 using double dependency.
      Dim dependencyKey(0) As [String]
      dependencyKey(0) = "key1"
      Dim dep1 As New CacheDependency(Nothing, dependencyKey)
   
      ' Make a second CacheDependency dependent on dep1
      ' and use dt to start change monitoring.        
      Dim dep2 As New CacheDependency(Nothing, Nothing, dep1, dt)
   
      Cache.Insert("key2", "Value 2", dep2)
   
      DisplayValues()
   End Sub 'CreateDependency