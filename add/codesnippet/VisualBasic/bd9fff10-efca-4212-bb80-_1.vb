    Private Sub swapRowsBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles swapRowsBtn.Click

        Dim c1 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.TableLayoutPanel1.GetControlFromPosition(1, 0)

        If c1 IsNot Nothing And c2 IsNot Nothing Then

            Me.TableLayoutPanel1.SetRow(c2, 0)
            Me.TableLayoutPanel1.SetRow(c1, 1)

        End If


    End Sub