' <Snippet1>
Imports System.Reflection

Class Example
    Public Shared Sub Main()
        ' Get the Type and MemberInfo.
        Dim t As Type = Type.GetType("System.Empty")
        Dim memberArray As MemberInfo() = t.GetMembers()

        ' Get and display the type that declares the member.
        Console.WriteLine("There are {0} members in {1}", 
                          memberArray.Length, t.FullName)

        For Each member In memberArray
            Console.WriteLine("Member {0} declared by {1}", 
                              member.Name, member.DeclaringType)
        Next 
    End Sub
End Class
' The example displays the following output:
'       There are 6 members in System.Empty
'       Member ToString declared by System.Empty
'       Member GetObjectData declared by System.Empty
'       Member Equals declared by System.Object
'       Member GetHashCode declared by System.Object
'       Member GetType declared by System.Object
'       Member Value declared by System.Empty
' </Snippet1>