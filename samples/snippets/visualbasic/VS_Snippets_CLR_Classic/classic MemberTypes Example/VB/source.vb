' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class membertypesenum

    Public Overloads Shared Function Main(ByVal args() As String) As Integer
        Console.WriteLine(ControlChars.Lf & "Reflection.MemberTypes")
        Dim Mymembertypes As MemberTypes

        ' Get the type of a chosen class.
        Dim Mytype As Type = Type.GetType("System.Reflection.ReflectionTypeLoadException")

        ' Get the MemberInfo array.
        Dim Mymembersinfoarray As MemberInfo() = Mytype.GetMembers()

        ' Get and display the name and the MemberType for each member.
        Dim Mymemberinfo As MemberInfo
        For Each Mymemberinfo In Mymembersinfoarray
            Mymembertypes = Mymemberinfo.MemberType
            Console.WriteLine("The member {0} of {1} is a {2}.", Mymemberinfo.Name, Mytype, Mymembertypes.ToString())
        Next Mymemberinfo
        Return 0
    End Function 'Main
End Class 'membertypesenum
' </Snippet1>