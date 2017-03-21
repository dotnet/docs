    Private Sub getcontrolFromPosBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles getcontrolFromPosBtn.Click

        Dim i As Integer = 0
        Dim j As Integer = 0
        Trace.WriteLine(Me.TableLayoutPanel1.ColumnCount)
        Trace.WriteLine(Me.TableLayoutPanel1.RowCount)

        For i = 0 To Me.TableLayoutPanel1.ColumnCount
            For j = 0 To Me.TableLayoutPanel1.RowCount

                Dim c As Control = Me.TableLayoutPanel1.GetControlFromPosition(i, j)

                If c IsNot Nothing Then

                    Trace.WriteLine(c.ToString())

                End If
            Next
        Next

    End Sub