        Public Overrides Function AdjustRowHeaderBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal singleVerticalBorderAdded As Boolean, _
            ByVal singleHorizontalBorderAdded As Boolean, _
            ByVal isFirstDisplayedRow As Boolean, _
            ByVal isLastDisplayedRow As Boolean) As DataGridViewAdvancedBorderStyle

            ' Customize the top border of the first row header and the
            ' right border of all the row headers. Use the input style for 
            ' all other borders.
            If isFirstDisplayedRow Then
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.InsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
                .Left = dataGridViewAdvancedBorderStyleInput.Left
                .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class