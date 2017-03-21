    Private Sub toggleColumnStylesBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleColumnStylesBtn.Click

        Dim styles As TableLayoutColumnStyleCollection = _
        Me.TableLayoutPanel1.ColumnStyles

        For Each style As ColumnStyle In styles

            If style.SizeType = SizeType.Absolute Then

                style.SizeType = SizeType.AutoSize

            ElseIf style.SizeType = SizeType.AutoSize Then

                style.SizeType = SizeType.Percent

                ' Set the column width to be a percentage
                ' of the TableLayoutPanel control's width.
                style.Width = 33

            Else

                ' Set the column width to 50 pixels.
                style.SizeType = SizeType.Absolute
                style.Width = 50

            End If

        Next

    End Sub