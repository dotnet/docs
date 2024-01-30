' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Public Enum VersionTime
   Earlier = -1
   Same = 0
   Later = 1
End Enum

Module Example2
    Public Sub Main()
        Dim v1 As New Version(1, 1)
        Dim v1a As New Version("1.1.0")
        ShowRelationship(v1, v1a)

        Dim v1b As New Version(1, 1, 0, 0)
        ShowRelationship(v1b, v1a)
    End Sub

    Private Sub ShowRelationship(v1 As Version, v2 As Version)
        Console.WriteLine("Relationship of {0} to {1}: {2}",
                        v1, v2, CType(v1.CompareTo(v2), VersionTime))
    End Sub
End Module
' The example displays the following output:
'       Relationship of 1.1 to 1.1.0: Earlier
'       Relationship of 1.1.0.0 to 1.1.0: Later
' </Snippet2>
