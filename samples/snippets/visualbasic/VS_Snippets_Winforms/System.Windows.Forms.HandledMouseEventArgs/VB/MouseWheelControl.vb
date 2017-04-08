'<SNIPPET1>
Public Class MouseWheelControl
    Sub New()
        ' Add initialization code for the control here. 
    End Sub

    Protected Sub MouseWheelControl_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseWheel
        Dim Hme As HandledMouseEventArgs = e
        Hme.Handled = True
        ' Perform custom mouse wheel action here. 
    End Sub
End Class
'</SNIPPET1>