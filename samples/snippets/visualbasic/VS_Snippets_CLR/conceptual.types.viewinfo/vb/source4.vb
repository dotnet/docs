' <snippet4>
' This program lists all the members of the
' System.IO.BufferedStream class.
Imports System.IO
Imports System.Reflection

Class ListMembers
    Public Shared Sub Main()
        ' Specifies the class.
        Dim t As Type = GetType(System.IO.BufferedStream)
        Console.WriteLine("Listing all the members (public and non public) of the {0} type", t)
        ' Lists static fields first.
        Dim fi As FieldInfo() = t.GetFields((BindingFlags.Static Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Static Fields")
        PrintMembers(fi)
        ' Static properties.
        Dim pi As PropertyInfo() = t.GetProperties((BindingFlags.Static Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Static Properties")
        PrintMembers(pi)
        ' Static events.
        Dim ei As EventInfo() = t.GetEvents((BindingFlags.Static Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Static Events")
        PrintMembers(ei)
        ' Static methods.
        Dim mi As MethodInfo() = t.GetMethods((BindingFlags.Static Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Static Methods")
        PrintMembers(mi)
        ' Constructors.
        Dim ci As ConstructorInfo() = t.GetConstructors((BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Constructors")
        PrintMembers(ci)
        ' Instance fields.
        fi = t.GetFields((BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Instance Fields")
        PrintMembers(fi)
        ' Instance properties.
        pi = t.GetProperties((BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Instance Properties")
        PrintMembers(pi)
        ' Instance events.
        ei = t.GetEvents((BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Instance Events")
        PrintMembers(ei)
        ' Instance methods.
        mi = t.GetMethods((BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public))
        Console.WriteLine("// Instance Methods")
        PrintMembers(mi)
        Console.WriteLine(ControlChars.CrLf & "Press ENTER to exit.")
        Console.Read()
    End Sub

    Public Shared Sub PrintMembers(ms() As MemberInfo)
        Dim m As MemberInfo
        For Each m In ms
            Console.WriteLine("{0}{1}", "     ", m)
        Next m
        Console.WriteLine()
    End Sub
End Class
' </snippet4>
