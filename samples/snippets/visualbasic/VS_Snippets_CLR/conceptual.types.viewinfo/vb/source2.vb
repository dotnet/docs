' <snippet2>
Imports System.IO
Imports System.Reflection

Class MyMemberInfo
    Public Shared Sub Main()
        Console.WriteLine("\nReflection.MemberInfo")
        ' Gets the Type and MemberInfo.
        Dim myType As Type = Type.GetType("System.IO.File")
        Dim myMemberInfoArray() As MemberInfo = myType.GetMembers()
        ' Gets and displays the DeclaringType method.
        Console.WriteLine("\nThere are {0} members in {1}.",
            myMemberInfoArray.Length, myType.FullName)
        Console.WriteLine("{0}.", myType.FullName)
        If myType.IsPublic
            Console.WriteLine("{0} is public.", myType.FullName)
        End If
    End Sub
End Class
' </snippet2>
