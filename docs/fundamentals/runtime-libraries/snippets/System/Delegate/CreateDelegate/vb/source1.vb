' Showing all the things D(A) can bind to.
'
'<Snippet1>
Imports System.Reflection
Imports System.Security.Permissions

' Declare a delegate type. The object of this code example
' is to show all the methods this delegate can bind to.
'
Public Delegate Sub D(ByVal c As C) 

' Declare two sample classes, C and F. Class C has an ID
' property so instances can be identified.
'
Public Class C

    Private _id As Integer

    Public ReadOnly Property ID() As Integer 
        Get
            Return _id
        End Get
    End Property

    Public Sub New(ByVal newId As Integer) 
        Me._id = newId
    End Sub
    
    Public Sub M1(ByVal c As C) 
        Console.WriteLine("Instance method M1(c As C) on C:  this.id = {0}, c.ID = {1}", _
            Me.id, c.ID)
    End Sub
    
    Public Sub M2() 
        Console.WriteLine("Instance method M2() on C:  this.id = {0}", Me.id)
    End Sub
    
    Public Shared Sub M3(ByVal c As C) 
        Console.WriteLine("Shared method M3(c As C) on C:  c.ID = {0}", c.ID)
    End Sub
    
    Public Shared Sub M4(ByVal c1 As C, ByVal c2 As C) 
        Console.WriteLine("Shared method M4(c1 As C, c2 As C) on C:  c1.ID = {0}, c2.ID = {1}", _
            c1.ID, c2.ID)
    End Sub
End Class


Public Class F
    
    Public Sub M1(ByVal c As C) 
        Console.WriteLine("Instance method M1(c As C) on F:  c.ID = {0}", c.ID)
    End Sub
    
    Public Shared Sub M3(ByVal c As C) 
        Console.WriteLine("Shared method M3(c As C) on F:  c.ID = {0}", c.ID)
    End Sub
    
    Public Shared Sub M4(ByVal f As F, ByVal c As C) 
        Console.WriteLine("Shared method M4(f As F, c As C) on F:  c.ID = {0}", c.ID)
    End Sub
End Class

Public Class Example5

    Public Shared Sub Main()

        Dim c1 As New C(42)
        Dim c2 As New C(1491)
        Dim f1 As New F()

        Dim d As D

        ' Instance method with one argument of type C.
        Dim cmi1 As MethodInfo = GetType(C).GetMethod("M1")
        ' Instance method with no arguments.
        Dim cmi2 As MethodInfo = GetType(C).GetMethod("M2")
        ' Shared method with one argument of type C.
        Dim cmi3 As MethodInfo = GetType(C).GetMethod("M3")
        ' Shared method with two arguments of type C.
        Dim cmi4 As MethodInfo = GetType(C).GetMethod("M4")

        ' Instance method with one argument of type C.
        Dim fmi1 As MethodInfo = GetType(F).GetMethod("M1")
        ' Shared method with one argument of type C.
        Dim fmi3 As MethodInfo = GetType(F).GetMethod("M3")
        ' Shared method with an argument of type F and an 
        ' argument of type C.
        Dim fmi4 As MethodInfo = GetType(F).GetMethod("M4")

        Console.WriteLine(vbLf & "An instance method on any type, with an argument of type C.")
        ' D can represent any instance method that exactly matches its
        ' signature. Methods on C and F are shown here.
        '
        d = CType([Delegate].CreateDelegate(GetType(D), c1, cmi1), D)
        d(c2)
        d = CType([Delegate].CreateDelegate(GetType(D), f1, fmi1), D)
        d(c2)

        Console.WriteLine(vbLf & "An instance method on C with no arguments.")
        ' D can represent an instance method on C that has no arguments;
        ' in this case, the argument of D represents the hidden first
        ' argument of any instance method. The delegate acts like a 
        ' Shared method, and an instance of C must be passed each time
        ' it is invoked.
        '
        d = CType([Delegate].CreateDelegate(GetType(D), Nothing, cmi2), D)
        d(c1)

        Console.WriteLine(vbLf & "A Shared method on any type, with an argument of type C.")
        ' D can represent any Shared method with the same signature.
        ' Methods on F and C are shown here.
        '
        d = CType([Delegate].CreateDelegate(GetType(D), Nothing, cmi3), D)
        d(c1)
        d = CType([Delegate].CreateDelegate(GetType(D), Nothing, fmi3), D)
        d(c1)

        Console.WriteLine(vbLf & "A Shared method on any type, with an argument of")
        Console.WriteLine("    that type and an argument of type C.")
        ' D can represent any Shared method with one argument of the
        ' type the method belongs and a second argument of type C.
        ' In this case, the method is closed over the instance of
        ' supplied for the its first argument, and acts like an instance
        ' method. Methods on F and C are shown here.
        '
        d = CType([Delegate].CreateDelegate(GetType(D), c1, cmi4), D)
        d(c2)
        Dim test As [Delegate] =
            [Delegate].CreateDelegate(GetType(D), f1, fmi4, False)

        ' This final example specifies False for throwOnBindFailure 
        ' in the call to CreateDelegate, so the variable 'test'
        ' contains Nothing if the method fails to bind (for 
        ' example, if fmi4 happened to represent a method of  
        ' some class other than F).
        '
        If test IsNot Nothing Then
            d = CType(test, D)
            d(c2)
        End If

    End Sub
End Class

' This code example produces the following output:
'
'An instance method on any type, with an argument of type C.
'Instance method M1(c As C) on C:  this.id = 42, c.ID = 1491
'Instance method M1(c As C) on F:  c.ID = 1491
'
'An instance method on C with no arguments.
'Instance method M2() on C:  this.id = 42
'
'A Shared method on any type, with an argument of type C.
'Shared method M3(c As C) on C:  c.ID = 42
'Shared method M3(c As C) on F:  c.ID = 42
'
'A Shared method on any type, with an argument of
'    that type and an argument of type C.
'Shared method M4(c1 As C, c2 As C) on C:  c1.ID = 42, c2.ID = 1491
'Shared method M4(f As F, c As C) on F:  c.ID = 1491
'
'</Snippet1>
