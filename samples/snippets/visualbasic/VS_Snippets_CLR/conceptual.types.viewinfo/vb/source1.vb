' <snippet1>
' This program lists all the public constructors
' of the System.String class.

Imports System
Imports System.Reflection

Class ListMembers
    Public Shared Sub Main()
        Dim t As Type = GetType(String)
        Console.WriteLine("Listing all the public constructors of the {0} type", t)
        ' Constructors.
        Dim ci As ConstructorInfo() = t.GetConstructors((BindingFlags.Public Or BindingFlags.Instance))
        Console.WriteLine("//Constructors")
        PrintMembers(ci)
    End Sub
    Public Shared Sub PrintMembers(ms() As MemberInfo)
        Dim m As MemberInfo
        For Each m In ms
            Console.WriteLine("{0}{1}", "     ", m)
        Next m
        Console.WriteLine()
    End Sub
End Class
' </snippet1>
