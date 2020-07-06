'<snippet8>
Imports System.Reflection

Class Asminfo1
    Public Shared Sub Main()
        Console.WriteLine("\nReflection.MemberInfo")

        ' Get the Type and MemberInfo.
        ' Insert the fully qualified class name inside the quotation marks in the
        ' following statement.
        Dim MyType As Type = Type.GetType("System.IO.BinaryReader")
        Dim Mymemberinfoarray() As MemberInfo = MyType.GetMembers(BindingFlags.Public Or
            BindingFlags.NonPublic Or BindingFlags.Static Or
            BindingFlags.Instance Or BindingFlags.DeclaredOnly)

        ' Get and display the DeclaringType method.
        Console.Write("\nThere are {0} documentable members in ", Mymemberinfoarray.Length)
        Console.Write("{0}.", MyType.FullName)

        For Each Mymemberinfo As MemberInfo in Mymemberinfoarray
            Console.Write("\n" + Mymemberinfo.Name)
        Next
    End Sub
End Class
'</snippet8>
