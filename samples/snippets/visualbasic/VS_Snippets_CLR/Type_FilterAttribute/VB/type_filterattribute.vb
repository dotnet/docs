' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Security
Imports Microsoft.VisualBasic

Public Class MyFilterAttributeSample

    Public Shared Sub Main()
        Try
            Dim myFilter As MemberFilter = Type.FilterAttribute
            Dim myType As Type = GetType(System.String)
            Dim myMemberInfoArray As MemberInfo() = myType.FindMembers(MemberTypes.Constructor Or MemberTypes.Method, BindingFlags.Public Or BindingFlags.Static Or BindingFlags.Instance, myFilter, MethodAttributes.SpecialName)
            Dim myMemberinfo As MemberInfo
            For Each myMemberinfo In myMemberInfoArray
                Console.Write(ControlChars.newline + myMemberinfo.Name)
                Console.Write(" is a " + myMemberinfo.MemberType.ToString())
            Next myMemberinfo

        Catch e As ArgumentNullException
            Console.Write("ArgumentNullException : " + e.Message.ToString())
        Catch e As SecurityException
            Console.Write("SecurityException : " + e.Message.ToString())
        Catch e As Exception
            Console.Write("Exception :" + e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyFilterAttributeSample
' </Snippet1>