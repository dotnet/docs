    Private Sub enumerateChildrenBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles enumerateChildrenBtn.Click

        Dim c As Control
        For Each c In Me.TableLayoutPanel1.Controls

            Trace.WriteLine(c.ToString())

        Next

    End Sub