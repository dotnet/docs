        Public Overrides Function AdjustCellBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal singleVerticalBorderAdded As Boolean, _
            ByVal singleHorizontalBorderAdded As Boolean, _
            ByVal firstVisibleColumn As Boolean, _
            ByVal firstVisibleRow As Boolean) As DataGridViewAdvancedBorderStyle

            ' Customize the top border of cells in the first row and the 
            ' right border of cells in the first column. Use the input style 
            ' for all other borders.
            If firstVisibleColumn Then
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.OutsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            If firstVisibleRow Then
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.InsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Right = dataGridViewAdvancedBorderStyleInput.Right
                .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class