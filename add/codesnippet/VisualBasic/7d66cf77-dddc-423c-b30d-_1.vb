        Public Overrides Function AdjustColumnHeaderBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal firstDisplayedColumn As Boolean, ByVal lastVisibleColumn As Boolean) _
            As DataGridViewAdvancedBorderStyle

            ' Customize the left border of the first column header and the
            ' bottom border of all the column headers. Use the input style for 
            ' all other borders.
            If firstDisplayedColumn Then
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.OutsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Bottom = DataGridViewAdvancedCellBorderStyle.Single
                .Right = dataGridViewAdvancedBorderStyleInput.Right
                .Top = dataGridViewAdvancedBorderStyleInput.Top
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class