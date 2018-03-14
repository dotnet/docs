' <Snippet1>
Imports System
Imports System.Reflection

Module Example

    Sub Main()

        Dim m1 As MemberInfo = GetType(Object).GetMethod("ToString")
        Dim m2 As MemberInfo = GetType(MemberInfo).GetMethod("ToString")

        Console.WriteLine("m1.DeclaringType: {0}", m1.DeclaringType)
        Console.WriteLine("m1.ReflectedType: {0}", m1.ReflectedType)
        Console.WriteLine()
        Console.WriteLine("m2.DeclaringType: {0}", m2.DeclaringType)
        Console.WriteLine("m2.ReflectedType: {0}", m2.ReflectedType)

        'Console.ReadLine()
    End Sub
End Module

' This code example produces the following output:
'
' m1.DeclaringType: System.Object
' m1.ReflectedType: System.Object
'
' m2.DeclaringType: System.Object
' m2.ReflectedType: System.Reflection.MemberInfo
'
' </Snippet1>
