Public Class SpecialForm : Inherits System.Windows.Forms.Form
    '<Snippet5>
    Sub New()
        AddHandler Me.FormClosing, AddressOf OnFormClosing
    End Sub

    Private Sub OnFormClosing(sender As Object, e As System.ComponentModel.CancelEventArgs)
        ' Insert code to deal with impending closure of this form.
    End Sub
    '</Snippet5>
End Class

'<Snippet4>
Public Class RaisesEvent
    Public Event SomethingHappened()
    Dim WithEvents happenObj As New RaisesEvent
    Public Sub ProcessHappen() Handles happenObj.SomethingHappened
        ' Insert code to handle somethingHappened event.
    End Sub
End Class
'</Snippet4>
