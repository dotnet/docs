        ' Determines the number of page links in the pager row
        ' when viewed in the designer.
        Protected Overrides ReadOnly Property SampleRowCount() As Integer
            Get
                ' Render five page links in the pager row.
                Return 5
            End Get
        End Property ' SampleRowCount