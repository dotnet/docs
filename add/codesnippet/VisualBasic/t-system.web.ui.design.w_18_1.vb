        Private menuItems As MenuItemCollection

        ' Associate the MenuItemCollectionEditor with the Items.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuItemCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property Items() As MenuItemCollection
            Get
                If menuItems Is Nothing Then
                    menuItems = New MenuItemCollection()
                End If
                Return menuItems
            End Get
            Set
                menuItems = value
            End Set
        End Property ' Items