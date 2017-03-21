        ' Determines the number of design-time links in the pager row.
        Protected Overrides ReadOnly Property SampleRowCount() As Integer
            Get
                ' Render four links in the pager row.
                Return 4
            End Get
        End Property ' SampleRowCount