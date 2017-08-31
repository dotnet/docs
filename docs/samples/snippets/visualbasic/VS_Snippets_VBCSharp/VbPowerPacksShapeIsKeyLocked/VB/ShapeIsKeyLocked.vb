Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeIsKeyLocked

    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click
        GetCapsLocked(OvalShape1)
    End Sub
    ' <Snippet1>
    Private Sub GetCapsLocked(ByVal shape As Shape)
        ' You can test for the CAPS LOCK, NUM LOCK, OR SCROLL LOCK key
        ' by changing the value of Keys.
        If shape.IsKeyLocked(Keys.CapsLock) Then
            MsgBox("The Caps Lock key is ON.")
        Else
            MsgBox("The Caps Lock key is OFF.")
        End If
    End Sub
    ' </Snippet1>
End Class
