    ' Handles drawing the ToolTip.
    Private Sub toolTip1_Draw(ByVal sender As System.Object, _
        ByVal e As DrawToolTipEventArgs) Handles toolTip1.Draw
        ' Draw the ToolTip differently depending on which 
        ' control this ToolTip is for.

        ' Draw a custom 3D border if the ToolTip is for button1.
        If (e.AssociatedControl Is button1) Then
            ' Draw the standard background.
            e.DrawBackground()

            ' Draw the custom border to appear 3-dimensional.
            e.Graphics.DrawLines( _
                SystemPens.ControlLightLight, New Point() { _
                New Point(0, e.Bounds.Height - 1), _
                New Point(0, 0), _
                New Point(e.Bounds.Width - 1, 0)})
            e.Graphics.DrawLines( _
                SystemPens.ControlDarkDark, New Point() { _
                New Point(0, e.Bounds.Height - 1), _
                New Point(e.Bounds.Width - 1, e.Bounds.Height - 1), _
                New Point(e.Bounds.Width - 1, 0)})

            ' Specify custom text formatting flags.
            Dim sf As TextFormatFlags = TextFormatFlags.VerticalCenter Or _
                                 TextFormatFlags.HorizontalCenter Or _
                                 TextFormatFlags.NoFullWidthCharacterBreak

            ' Draw standard text with customized formatting options.
            e.DrawText(sf)
        ElseIf (e.AssociatedControl Is button2) Then
            ' Draw a custom background and text if the ToolTip is for button2.

            ' Draw the custom background.
            e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds)

            ' Draw the standard border.
            e.DrawBorder()

            ' Draw the custom text.
            Dim sf As StringFormat = New StringFormat
            Try
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None
                sf.FormatFlags = StringFormatFlags.NoWrap

                Dim f As Font = New Font("Tahoma", 9)
                Try
                    e.Graphics.DrawString(e.ToolTipText, f, _
                        SystemBrushes.ActiveCaptionText, _
                        RectangleF.op_Implicit(e.Bounds), sf)
                Finally
                    f.Dispose()
                End Try
            Finally
                sf.Dispose()
            End Try
        ElseIf (e.AssociatedControl Is button3) Then
            ' Draw the ToolTip using default values if the ToolTip is for button3.
            e.DrawBackground()
            e.DrawBorder()
            e.DrawText()
        End If
    End Sub