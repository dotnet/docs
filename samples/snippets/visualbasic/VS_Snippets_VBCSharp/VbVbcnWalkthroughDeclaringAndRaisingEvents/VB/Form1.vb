' Walkthrough: Handling Events 
'   f145b3fc-5ae0-4509-a2aa-1ff6934706bd

Public Class Form1
    '<snippet4>
    Private WithEvents mWidget As Widget
    Private mblnCancel As Boolean
    '</snippet4>

    '<snippet5>
    Private Sub mWidget_PercentDone( 
        ByVal Percent As Single, 
        ByRef Cancel As Boolean 
    ) Handles mWidget.PercentDone
        lblPercentDone.Text = CInt(100 * Percent) & "%"
        My.Application.DoEvents()
        If mblnCancel Then Cancel = True
    End Sub
    '</snippet5>

    '<snippet6>
    Private Sub Button2_Click( 
        ByVal sender As Object, 
        ByVal e As System.EventArgs 
    ) Handles Button2.Click
        mblnCancel = True
    End Sub
    '</snippet6>

    '<snippet7>
    Private Sub Form1_Load( 
        ByVal sender As System.Object, 
        ByVal e As System.EventArgs 
    ) Handles MyBase.Load
        mWidget = New Widget
    End Sub
    '</snippet7>

    '<snippet8>
    Private Sub Button1_Click( 
        ByVal sender As Object, 
        ByVal e As System.EventArgs 
    ) Handles Button1.Click
        mblnCancel = False
        lblPercentDone.Text = "0%"
        lblPercentDone.Refresh()
        mWidget.LongTask(12.2, 0.33)
        If Not mblnCancel Then lblPercentDone.Text = CStr(100) & "%"
    End Sub
    '</snippet8>

    Sub extra()
        '<snippet9>
        mWidget = New Widget
        ' Create a new Widget object.
        '</snippet9>
    End Sub
End Class
