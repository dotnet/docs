        Private items As ListItemCollection

        ' Associate the ListItemsCollectionEditor with the ListItems.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            ListItemsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property ListItems() As ListItemCollection
            Get
                Return items
            End Get
        End Property ' ListItems