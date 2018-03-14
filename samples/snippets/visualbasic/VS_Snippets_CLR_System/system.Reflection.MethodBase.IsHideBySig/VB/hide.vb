'<Snippet1>
Imports System
Imports System.Reflection

' The base class B contains an overloaded method M.
'
Public Class B
    Public Overridable Sub M()
        Console.WriteLine("B's M()")
    End Sub
    Public Overridable Sub M(ByVal x As Integer)
        Console.WriteLine("B's M({0})", x)
    End Sub
End Class

' The derived class D hides the inherited method M.
'
Public Class D
    Inherits B
    Shadows Public Sub M(ByVal i As Integer)
        Console.WriteLine("D's M({0})", i)
    End Sub
End Class

Public Class Test
    Public Shared Sub Main()
        Dim dinst As New D()
        ' In Visual Basic, the method in the derived class hides by
        ' name, rather than by signature.  Thus, although a list of all the 
        ' overloads of M shows three overloads, only one can be called from
        ' class D.  
        '
        Console.WriteLine("------ List the overloads of M in the derived class D ------")
        Dim t As Type = dinst.GetType()
        For Each minfo As MethodInfo In t.GetMethods()
            If minfo.Name = "M" Then Console.WriteLine( _
                "Overload of M: {0}  IsHideBySig = {1}, DeclaringType = {2}", _
                minfo, minfo.IsHideBySig, minfo.DeclaringType)
        Next

        ' The method M in the derived class hides the method in B.
        '
        Console.WriteLine("------ Call the overloads of M available in D ------")
        ' The following line causes a compile error, because both overloads
        ' in the base class are hidden.  Contrast this with C#, where only 
        ' one of the overloads of B would be hidden.
        'dinst.M()
        dinst.M(42)
        
        ' If D is cast to the base type B, both overloads of the 
        ' shadowed method can be called.
        '
        Console.WriteLine("------ Call the shadowed overloads of M ------")
        Dim binst As B = dinst
        binst.M()
        binst.M(42)         
    End Sub 'Main
End Class 'Test

' This code example produces the following output:
' ------ List the overloads of M in the derived class D ------
' Overload of M: Void M(Int32)  IsHideBySig = False, DeclaringType = B
' Overload of M: Void M()  IsHideBySig = False, DeclaringType = B
' Overload of M: Void M(Int32)  IsHideBySig = False, DeclaringType = D
' ------ Call the overloads of M available in D ------
' D's M(42)
' ------ Call the shadowed overloads of M ------
' B's M()
' B's M(42)
'</Snippet1>