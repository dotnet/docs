    Private Sub swapControlsBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles swapControlsBtn.Click

        Dim c1 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 1)

        If c1 IsNot Nothing And c2 IsNot Nothing Then

            Me.TableLayoutPanel1.SetColumn(c2, 0)
            Me.TableLayoutPanel1.SetColumn(c1, 1)

        End If

    End Sub