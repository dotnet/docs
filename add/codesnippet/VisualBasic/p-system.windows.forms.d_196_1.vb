        Public Overrides ReadOnly Property AdjustedTopLeftHeaderBorderStyle() _
            As DataGridViewAdvancedBorderStyle
            Get
                Dim newStyle As New DataGridViewAdvancedBorderStyle()
                With newStyle
                    .Top = DataGridViewAdvancedCellBorderStyle.None
                    .Left = DataGridViewAdvancedCellBorderStyle.None
                    .Bottom = DataGridViewAdvancedCellBorderStyle.Outset
                    .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
                End With
                Return newStyle
            End Get
        End Property