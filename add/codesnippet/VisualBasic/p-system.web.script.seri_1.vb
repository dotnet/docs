        Public Overrides ReadOnly Property SupportedTypes() As _
            System.Collections.Generic.IEnumerable(Of System.Type)
            Get
                ' Define the ListItemCollection as a supported type.
                Return New ReadOnlyCollection(Of Type)(New List(Of Type) _
                (New Type() {GetType(ListItemCollection)}))
            End Get
        End Property