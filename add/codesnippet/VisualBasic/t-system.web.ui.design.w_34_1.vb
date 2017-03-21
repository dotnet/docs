        Private cells As TableCellCollection

        ' Associate the TableCellsCollectionEditor with the TestCells.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            TableCellsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestCells() As TableCellCollection
            Get
                Return cells
            End Get
        End Property ' TestCells