        Protected Overrides Function Commit(dataSource As System.Windows.Forms.CurrencyManager, rowNum As Integer) As Boolean
            SetColumnValueAtRow(dataSource, rowNum, currentValue)
            isEditing = False
            Invalidate
            Commit = True
        End Function