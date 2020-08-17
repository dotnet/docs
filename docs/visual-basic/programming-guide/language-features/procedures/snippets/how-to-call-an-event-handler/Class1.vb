    '****************************************************************************
    ' Special Form class to test Snippet5 -- changed Sub catchClose from Public to Protected 9/29/2005 for FxCop
    ' Changed Protected catchClose to Private 4/6/2006 for FxCop -- jcooke
    Public Class SpecialForm : Inherits System.Windows.Forms.Form
        '<Snippet5>
        ' Place these procedures inside a Form class definition.
        Private Sub catchClose(sender As Object, e As System.ComponentModel.CancelEventArgs)
            ' Insert code to deal with impending closure of this form.
        End Sub
        Public Sub formOpened()
            AddHandler Me.FormClosing, AddressOf catchClose
        End Sub
        '</Snippet5>
    End Class


    '****************************************************************************
    '<Snippet4>
    Public Class raisesEvent
        Public Event somethingHappened()
        Dim WithEvents happenObj As New raisesEvent
        Public Sub processHappen() Handles happenObj.somethingHappened
            ' Insert code to handle somethingHappened event.
        End Sub
    End Class
    '</Snippet4>