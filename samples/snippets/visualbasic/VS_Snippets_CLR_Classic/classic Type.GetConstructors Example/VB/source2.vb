' <Snippet2>
Imports System
Imports System.Reflection

Public Class t
    
    Public Sub New()
    End Sub
    
    Shared Sub New()
    End Sub
    
    Public Sub New(i As Integer)
    End Sub
     
    Public Shared Sub Main()
        Dim p As ConstructorInfo() = GetType(T).GetConstructors( _
           BindingFlags.Public Or _
           BindingFlags.Static Or _
           BindingFlags.NonPublic Or _
           BindingFlags.Instance)
        Console.WriteLine(p.Length)
        
        Dim i As Integer
        For i = 0 To p.Length - 1
            Console.WriteLine(p(i).IsStatic)
        Next i
    End Sub
End Class
' </Snippet2>