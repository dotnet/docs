    ' Handle the After_Select event.
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.TreeViewEventArgs) _
            Handles TreeView1.AfterSelect

        ' Vary the response depending on which TreeViewAction
        ' triggered the event. 
        Select Case (e.Action)
            Case TreeViewAction.ByKeyboard
                MessageBox.Show("You like the keyboard!")
            Case TreeViewAction.ByMouse
                MessageBox.Show("You like the mouse!")
        End Select
    End Sub