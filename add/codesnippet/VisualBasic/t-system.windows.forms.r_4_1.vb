    Private Sub toggleRowStylesBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleRowStylesBtn.Click

        Dim styles As TableLayoutRowStyleCollection = _
        Me.TableLayoutPanel1.RowStyles

        For Each style As RowStyle In styles

            If style.SizeType = SizeType.Absolute Then

                style.SizeType = SizeType.AutoSize

            ElseIf style.SizeType = SizeType.AutoSize Then

                style.SizeType = SizeType.Percent

                ' Set the row height to be a percentage
                ' of the TableLayoutPanel control's height.
                style.Height = 33

            Else

                ' Set the row height to 50 pixels.
                style.SizeType = SizeType.Absolute
                style.Height = 50

            End If

        Next

    End Sub