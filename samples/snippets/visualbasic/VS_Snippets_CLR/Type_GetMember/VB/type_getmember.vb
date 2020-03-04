' <Snippet1>

Imports System.Security
Imports System.Reflection

Public Class MyMemberSample

    Public Shared Sub Main()
        Dim [myClass] As New MyMemberSample()
        Try
            [myClass].GetMemberInfo()
            [myClass].GetPublicStaticMemberInfo()
            [myClass].GetPublicInstanceMethodMemberInfo()
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException occurred.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        Catch e As NotSupportedException
            Console.WriteLine("NotSupportedException occurred.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        Catch e As SecurityException
            Console.WriteLine("SecurityException occurred.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception occurred.")
            Console.WriteLine(("Source: " + e.Source))
            Console.WriteLine(("Message: " + e.Message))
        End Try
    End Sub


    Public Sub GetMemberInfo()
        Dim myString As [String] = "GetMember_String"
        Dim myType As Type = myString.GetType()
        ' Get the members for myString starting with the letter C.
        Dim myMembers As MemberInfo() = myType.GetMember("C*")
        If myMembers.Length > 0 Then
            Console.WriteLine(ControlChars.Cr + "The member(s) starting with the letter C for type {0}:", myType)
            Dim index As Integer
            For index = 0 To myMembers.Length - 1
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers(index).ToString())
            Next index
        Else
            Console.WriteLine("No members match the search criteria.")
        End If
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Public Sub GetPublicStaticMemberInfo()
        Dim myString As [String] = "GetMember_String_BindingFlag"

        Dim myType As Type = myString.GetType()
        ' Get the public static members for the class myString starting with the letter C.
        Dim myMembers As MemberInfo() = myType.GetMember("C*", BindingFlags.Public Or BindingFlags.Static)

        If myMembers.Length > 0 Then
            Console.WriteLine(ControlChars.Cr + "The public static member(s) starting with the letter C for type {0}:", myType)
            Dim index As Integer
            For index = 0 To myMembers.Length - 1
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers(index).ToString())
            Next index
        Else
            Console.WriteLine("No members match the search criteria.")
        End If
    End Sub
    ' </Snippet2>

    ' <Snippet3>
    Public Sub GetPublicInstanceMethodMemberInfo()
        Dim myString As [String] = "GetMember_String_MemberType_BindingFlag"

        Dim myType As Type = myString.GetType()
        ' Get the public instance methods for myString starting with the letter C.
        Dim myMembers As MemberInfo() = myType.GetMember("C*", MemberTypes.Method, BindingFlags.Public Or BindingFlags.Instance)
        If myMembers.Length > 0 Then
            Console.WriteLine(ControlChars.Cr + "The public instance method(s) starting with the letter C for type {0}:", myType)
            Dim index As Integer
            For index = 0 To myMembers.Length - 1
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers(index).ToString())
            Next index
        Else
            Console.WriteLine("No members match the search criteria.")
        End If
    End Sub
End Class
' </Snippet3>
