' <Snippet1>
Imports System
Imports System.Reflection

Public MustInherit Class MyClassA

    Public MustInherit Class MyClassB

    End Class

    Public Shared Sub Main()
        Console.WriteLine("Reflected type of MyClassB is {0}", _
           GetType(MyClassB).ReflectedType)
	'Outputs MyClassA, the enclosing type.
    End Sub
End Class
' </Snippet1>