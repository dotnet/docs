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