        Private rows As TableRowCollection

        ' Associate the TableRowsCollectionEditor with the TestRows.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            TableRowsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestRows() As TableRowCollection
            Get
                Return rows
            End Get
        End Property ' TestRows