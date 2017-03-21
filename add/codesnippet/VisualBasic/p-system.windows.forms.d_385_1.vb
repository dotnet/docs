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