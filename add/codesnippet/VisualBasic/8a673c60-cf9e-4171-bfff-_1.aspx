    Public Sub CreateDependency(sender As Object, e As EventArgs)
    ' Create a DateTime object.
    Dim dt as DateTime = DateTime.Now.AddSeconds(10)        

    ' Create a cache entry.
        Cache("key1") = "Value 1"

        ' Make key2 dependent on key1.
        Dim dependencyKey(0) As String
        dependencyKey(0) = "key1"
        Dim dependency As new CacheDependency(Nothing, dependencyKey, dt)

        Cache.Insert("key2", "Value 2", dependency)

        DisplayValues()
    End Sub