' <Snippet1>

Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Class MyFindMembersClass

    Public Shared Sub Main()
        Dim objTest As New Object()
        Dim objType As Type = objTest.GetType()
        Dim arrayMemberInfo() As MemberInfo
        Try
            'Find all static or public methods in the Object 
            'class that match the specified name.
            arrayMemberInfo = objType.FindMembers(MemberTypes.Method, _
                              BindingFlags.Public Or BindingFlags.Static _
                              Or BindingFlags.Instance, _
                              New MemberFilter(AddressOf DelegateToSearchCriteria), _
                              "ReferenceEquals")

            Dim index As Integer
            For index = 0 To arrayMemberInfo.Length - 1
                Console.WriteLine("Result of FindMembers -" + ControlChars.Tab + _
                               arrayMemberInfo(index).ToString() + ControlChars.Cr)
            Next index
        Catch e As Exception
            Console.WriteLine("Exception : " + e.ToString())
        End Try
    End Sub 'Main

    Public Shared Function DelegateToSearchCriteria _
                            (ByVal objMemberInfo As MemberInfo, _
                             ByVal objSearch As Object) As Boolean
        ' Compare the name of the member function with the filter criteria.
        If objMemberInfo.Name.ToString() = objSearch.ToString() Then
            Return True
        Else
            Return False
        End If
    End Function 'DelegateToSearchCriteria 
End Class 'MyFindMembersClass
' </Snippet1>