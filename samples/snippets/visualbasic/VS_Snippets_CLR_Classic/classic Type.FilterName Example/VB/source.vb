Imports System
Imports System.Reflection

Public Class Sample
    
    Public Sub Method()
' <Snippet1>
 ' Get the set of methods associated with the type
 Dim mi As MemberInfo() = _
    GetType(Application).FindMembers( _
    MemberTypes.Constructor Or MemberTypes.Method, _
    BindingFlags.DeclaredOnly, _
    Type.FilterName, "*")
 Console.WriteLine("Number of methods (includes constructors): " & _
    mi.Length.ToString())
' </Snippet1>
    End Sub
End Class

' Class added so sample will compile
Public Class Application    
    Public Sub Method()
    End Sub
End Class
