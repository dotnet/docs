' <snippet2>
Imports System
Imports System.IO
Imports System.Reflection

Class Mymemberinfo
    Public Shared Sub Main()
        Console.WriteLine ("\nReflection.MemberInfo")
        ' Gets the Type and MemberInfo.
        Dim MyType As Type = Type.GetType("System.IO.File")
        Dim Mymemberinfoarray() As MemberInfo = MyType.GetMembers()
        ' Gets and displays the DeclaringType method.
        Console.WriteLine("\nThere are {0} members in {1}.",
            Mymemberinfoarray.Length, MyType.FullName)
        Console.WriteLine("{0}.", MyType.FullName)
        If MyType.IsPublic
            Console.WriteLine("{0} is public.", MyType.FullName)
        End If
    End Sub
End Class
' </snippet2>
