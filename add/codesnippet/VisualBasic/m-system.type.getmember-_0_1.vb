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
    End Sub 'GetPublicStaticMemberInfo