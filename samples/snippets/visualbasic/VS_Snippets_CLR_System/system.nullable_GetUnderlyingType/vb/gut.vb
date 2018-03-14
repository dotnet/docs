'<snippet1>
' This code example demonstrates the 
' Nullable.GetUnderlyingType() method.

Imports System
Imports System.Reflection

Class Sample
    ' Declare a type named Example. 
    ' The MyMethod member of Example returns a Nullable of Int32.
    
    Public Class Example
        Public Function MyMethod() As Nullable(Of Integer)
            Return 0
        End Function
    End Class 'Example
    
' 
'   Use reflection to obtain a Type object for the Example type.
'   Use the Type object to obtain a MethodInfo object for the MyMethod method.
'   Use the MethodInfo object to obtain the type of the return value of 
'     MyMethod, which is Nullable of Int32.
'   Use the GetUnderlyingType method to obtain the type argument of the 
'     return value type, which is Int32.
'
    Public Shared Sub Main() 
        Dim t As Type = GetType(Example)
        Dim mi As MethodInfo = t.GetMethod("MyMethod")
        Dim retval As Type = mi.ReturnType
        Console.WriteLine("Return value type ... {0}", retval)
        Dim answer As Type = Nullable.GetUnderlyingType(retval)
        Console.WriteLine("Underlying type ..... {0}", answer)
    
    End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'Return value type ... System.Nullable`1[System.Int32]
'Underlying type ..... System.Int32
'
'</snippet1>