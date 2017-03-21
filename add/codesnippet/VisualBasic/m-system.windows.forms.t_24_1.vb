    Private Sub getRowBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles getRowBtn.Click

        Dim c As Control
        For Each c In Me.TableLayoutPanel1.Controls

            Trace.WriteLine(Me.TableLayoutPanel1.GetRow(c))

        Next

    End Sub