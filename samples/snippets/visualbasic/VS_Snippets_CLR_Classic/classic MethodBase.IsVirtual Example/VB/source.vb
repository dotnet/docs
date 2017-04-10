' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class MyClass1
    
    Public Sub MyMethod()
    End Sub
    
    Public Shared Sub Main()
        Dim m As MethodBase = GetType(MyClass1).GetMethod("MyMethod")
        Console.WriteLine("The IsFinal property value of MyMethod is {0}.", m.IsFinal)
        Console.WriteLine("The IsVirtual property value of MyMethod is {0}.", m.IsVirtual)
    End Sub
End Class
' </Snippet1>