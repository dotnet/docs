    Private Sub toggleSpanBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleSpanBtn.Click

        Dim c As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)

        If c IsNot Nothing Then

            Dim xSpan As Integer = Me.TableLayoutPanel1.GetColumnSpan(c)
            Dim ySpan As Integer = Me.TableLayoutPanel1.GetRowSpan(c)

            If xSpan > 1 Then

                xSpan = 1
                ySpan = 1

            Else

                xSpan = 2
                ySpan = 2

            End If

            Me.TableLayoutPanel1.SetColumnSpan(c, xSpan)
            Me.TableLayoutPanel1.SetRowSpan(c, ySpan)

        End If

    End Sub