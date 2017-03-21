        Public Overrides Sub PerformPreRender()
            Dim zoneStyle As Style = New Style
            zoneStyle.BackColor = Drawing.Color.Cornsilk

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, Nothing)
            Zone.MergeStyle(zoneStyle)
        End Sub