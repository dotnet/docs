' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Security
Imports Microsoft.VisualBasic

Public Class MyFilterNameIgnoreCaseSample
    Public Shared Sub Main()
        Try
            Dim myFilter As MemberFilter = Type.FilterNameIgnoreCase
            Dim myType As Type = GetType(System.String)
            Dim myMemberinfo1 As MemberInfo() = myType.FindMembers(MemberTypes.Constructor Or MemberTypes.Method, BindingFlags.Public Or BindingFlags.Static Or BindingFlags.Instance, myFilter, "C*")
            Dim myMemberinfo2 As MemberInfo
            For Each myMemberinfo2 In myMemberinfo1
                Console.Write((ControlChars.NewLine + myMemberinfo2.Name))
                Dim Mymembertypes As MemberTypes = myMemberinfo2.MemberType
                Console.WriteLine((" is a " + Mymembertypes.ToString()))
            Next myMemberinfo2
        Catch e As ArgumentNullException
            Console.Write("ArgumentNullException : " + e.Message.Tostring())
        Catch e As SecurityException
            Console.Write("SecurityException : " + e.Message.Tostring())
        Catch e As Exception
            Console.Write("Exception : " + e.Message.Tostring())
        End Try
    End Sub 'Main
End Class 'MyFilterNameIgnoreCaseSample
' </Snippet1>