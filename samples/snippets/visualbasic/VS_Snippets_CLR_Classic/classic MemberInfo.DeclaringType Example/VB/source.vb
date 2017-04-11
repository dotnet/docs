' <Snippet1>
Imports System
Imports System.IO
Imports System.Reflection
Imports Microsoft.VisualBasic

Namespace MyNamespace1

    Interface i
        Function MyVar() As Integer
    End Interface
    ' DeclaringType for MyVar is i.

    Class A
        Implements i
        Function MyVar() As Integer Implements i.MyVar
            Return 0
        End Function
    End Class
    ' DeclaringType for MyVar is A.

    Class B
        Inherits A
        Function MyVars() As Integer
            Return 0
        End Function
    End Class
    ' DeclaringType for MyVar is B.

    Class C
        Inherits A
    End Class
    ' DeclaringType for MyVar is A.
End Namespace

Namespace MyNamespace2

    Class A
        Public Overridable Sub M()
        End Sub
    End Class

    Class B
        Inherits A
        Public Overrides Sub M()
        End Sub
    End Class
End Namespace
Class Mymemberinfo

    Public Shared Sub Main()

        Console.WriteLine(ControlChars.Cr & "Reflection.MemberInfo")

        'Get the Type and MemberInfo.
        Dim MyType As Type = Type.GetType("System.IO.BufferedStream")

        Dim Mymemberinfoarray As MemberInfo() = MyType.GetMembers()

        'Get and display the DeclaringType method.
        Console.WriteLine(ControlChars.Cr & "There are {0} members in {1}.", Mymemberinfoarray.Length, MyType.FullName)

        Dim Mymemberinfo As MemberInfo
        For Each Mymemberinfo In Mymemberinfoarray
            Console.WriteLine("The declaring type of {0} is {1}.", Mymemberinfo.Name, Mymemberinfo.DeclaringType.ToString())
        Next Mymemberinfo
    End Sub
End Class
' </Snippet1>

