        ' Place these procedures inside a Form class definition.
        Private Sub catchClose(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            ' Insert code to deal with impending closure of this form.
        End Sub
        Public Sub formOpened()
            AddHandler Me.Closing, AddressOf catchClose
        End Sub