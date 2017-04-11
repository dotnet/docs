Imports System
Imports System.IO
Imports System.Reflection

Public Class Sample   
    
    Public Sub Method(type As Type)
        Dim cInfo As ConstructorInfo
' <Snippet1>
cInfo = type.GetConstructor(BindingFlags.ExactBinding, _
   Nothing, Type.EmptyTypes, Nothing)
' </Snippet1>
    End Sub
End Class
