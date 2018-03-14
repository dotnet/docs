' <Snippet1>
Imports System.IO
Imports System.Reflection

Module Example
    Public Sub Main()
        'Get the Type and MemberInfo.
        Dim t As Type = Type.GetType("System.IO.File")
        Dim members As MemberInfo() = t.GetMembers()
        'Get and display the DeclaringType method.
        Console.WriteLine("There are {0} members in {1}.",
                          members.Length, t.FullName)
        Console.WriteLine("Is {0} non-public? {1}",
                          t.FullName, t.IsNotPublic)
    End Sub
End Module
' The example displays output like the following:
'       There are 60 members in System.IO.File.
'       Is System.IO.File non-public? False
' </Snippet1>

' <Snippet2>
Public Class A
    Public Class B
    End Class
    Private Class C
    End Class
End Class
' </Snippet2>