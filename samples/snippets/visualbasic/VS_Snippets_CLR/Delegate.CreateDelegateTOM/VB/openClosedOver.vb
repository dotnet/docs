' REDMOND\glennha
' All four permutations of instance/Shared with open/closed.
'
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Security.Permissions

' Declare three delegate types for demonstrating the combinations
' of Shared versus instance methods and open versus closed
' delegates.
'
Public Delegate Sub D1(ByVal c As C, ByVal s As String) 
Public Delegate Sub D2(ByVal s As String) 
Public Delegate Sub D3() 

' A sample class with an instance method and a Shared method.
'
Public Class C
    Private id As Integer
    Public Sub New(ByVal id As Integer) 
        Me.id = id
    End Sub 'New

    Public Sub M1(ByVal s As String) 
        Console.WriteLine("Instance method M1 on C:  id = {0}, s = {1}", _
            Me.id, s)
    End Sub
    
    Public Shared Sub M2(ByVal s As String) 
        Console.WriteLine("Shared method M2 on C:  s = {0}", s)
    End Sub
End Class

Public Class Example
    
    Public Shared Sub Main() 

        Dim c1 As New C(42)
        
        ' Get a MethodInfo for each method.
        '
        Dim mi1 As MethodInfo = GetType(C).GetMethod("M1", _
            BindingFlags.Public Or BindingFlags.Instance)
        Dim mi2 As MethodInfo = GetType(C).GetMethod("M2", _
            BindingFlags.Public Or BindingFlags.Static)
        
        Dim d1 As D1
        Dim d2 As D2
        Dim d3 As D3
        
        
        Console.WriteLine(vbLf & "An instance method closed over C.")
        ' In this case, the delegate and the
        ' method must have the same list of argument types; use
        ' delegate type D2 with instance method M1.
        '
        Dim test As [Delegate] = _
            [Delegate].CreateDelegate(GetType(D2), c1, mi1, False)

        ' Because False was specified for throwOnBindFailure 
        ' in the call to CreateDelegate, the variable 'test'
        ' contains Nothing if the method fails to bind (for 
        ' example, if mi1 happened to represent a method of 
        ' some class other than C).
        '
        If test IsNot Nothing Then
            d2 = CType(test, D2)

            ' The same instance of C is used every time the
            ' delegate is invoked.
            d2("Hello, World!")
            d2("Hi, Mom!")
        End If
        
        
        Console.WriteLine(vbLf & "An open instance method.")
        ' In this case, the delegate has one more 
        ' argument than the instance method; this argument comes
        ' at the beginning, and represents the hidden instance
        ' argument of the instance method. Use delegate type D1
        ' with instance method M1.
        '
        d1 = CType([Delegate].CreateDelegate(GetType(D1), Nothing, mi1), D1)
        
        ' An instance of C must be passed in each time the 
        ' delegate is invoked.
        '
        d1(c1, "Hello, World!")
        d1(New C(5280), "Hi, Mom!")
        
        
        Console.WriteLine(vbLf & "An open Shared method.")
        ' In this case, the delegate and the method must 
        ' have the same list of argument types; use delegate type
        ' D2 with Shared method M2.
        '
        d2 = CType([Delegate].CreateDelegate(GetType(D2), Nothing, mi2), D2)
        
        ' No instances of C are involved, because this is a Shared
        ' method. 
        '
        d2("Hello, World!")
        d2("Hi, Mom!")
        
        
        Console.WriteLine(vbLf & "A Shared method closed over the first argument (String).")
        ' The delegate must omit the first argument of the method.
        ' A string is passed as the firstArgument parameter, and 
        ' the delegate is bound to this string. Use delegate type 
        ' D3 with Shared method M2. 
        '
        d3 = CType([Delegate].CreateDelegate(GetType(D3), "Hello, World!", mi2), D3)
        
        ' Each time the delegate is invoked, the same string is
        ' used.
        d3()
    
    End Sub
End Class

' This code example produces the following output:
'
'An instance method closed over C.
'Instance method M1 on C:  id = 42, s = Hello, World!
'Instance method M1 on C:  id = 42, s = Hi, Mom!
'
'An open instance method.
'Instance method M1 on C:  id = 42, s = Hello, World!
'Instance method M1 on C:  id = 5280, s = Hi, Mom!
'
'An open Shared method.
'Shared method M2 on C:  s = Hello, World!
'Shared method M2 on C:  s = Hi, Mom!
'
'A Shared method closed over the first argument (String).
'Shared method M2 on C:  s = Hello, World!
' 
'</Snippet1>