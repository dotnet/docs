        Private columns As DataGridColumnCollection

        ' Associate DataGridColumnCollectionEditor with the TestColumns.
        <EditorAttribute( GetType( System.Web.UI.Design.WebControls. _
            DataGridColumnCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestColumns() As DataGridColumnCollection
            Get
                Return columns
            End Get
        End Property ' TestColumns