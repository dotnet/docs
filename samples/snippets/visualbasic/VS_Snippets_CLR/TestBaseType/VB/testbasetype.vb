' <Snippet1>
Class TestType
   
    Public Shared Sub Main()
        Dim t As Type = GetType(Integer)
        Console.WriteLine("{0} inherits from {1}.", t, t.BaseType)
    End Sub
End Class
' </Snippet1>