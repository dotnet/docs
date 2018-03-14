    Public Class raisesEvent
        Public Event somethingHappened()
        Dim WithEvents happenObj As New raisesEvent
        Public Sub processHappen() Handles happenObj.somethingHappened
            ' Insert code to handle somethingHappened event.
        End Sub
    End Class