Imports Microsoft.VisualBasic
'<Snippet2>
' friend_signed_B.vb
' Compile with: 
' Vbc /keyfile:FriendAssemblies.snk /r:friend_signed_A.dll friend_signed_B.vb
Module Sample
    Public Sub Main()
        Dim inst As New Class1
        inst.Test()
    End Sub
End Module
'</Snippet2>

