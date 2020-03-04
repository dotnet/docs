' <Snippet1>
Class TestFullName
   
    Public Shared Sub Main()
        Dim t As Type = GetType(Array)
        Console.WriteLine("The full name of the Array type is {0}.", t.FullName)
    End Sub
End Class

' This example produces the following output:
'
'The full name of the Array type is System.Array.
'
' </Snippet1>