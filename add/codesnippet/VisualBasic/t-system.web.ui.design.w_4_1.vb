        Private menuItemStyles As MenuItemStyleCollection

        ' Associate the MenuItemStyleCollectionEditor with the 
        ' LevelMenuItemStyles.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuItemStyleCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property LevelMenuItemStyles() As MenuItemStyleCollection
            Get
                Return menuItemStyles
            End Get
            Set
                menuItemStyles = value
            End Set
        End Property ' LevelMenuItemStyles