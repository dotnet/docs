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
    End Sub 'GetPublicInstanceMethodMemberInfo 
End Class 'MyMemberSample