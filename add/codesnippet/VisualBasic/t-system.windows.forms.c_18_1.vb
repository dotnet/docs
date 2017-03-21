    Private Sub CheckEveryOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEveryOther.Click
        ' Cycle through every item and check every other.
        Dim i As Integer

        ' Set flag to true to know when this code is being executed. Used in the ItemCheck
        ' event handler.
        insideCheckEveryOther = True

        For i = 0 To CheckedListBox1.Items.Count - 1
            ' For every other item in the list, set as checked.

            If ((i Mod 2) = 0) Then
                ' But for each other item that is to be checked, set as being in an
                ' indeterminate checked state.

                If ((i Mod 4) = 0) Then
                    CheckedListBox1.SetItemCheckState(i, CheckState.Indeterminate)
                Else
                    CheckedListBox1.SetItemChecked(i, True)
                End If
            End If
        Next

        insideCheckEveryOther = False

    End Sub