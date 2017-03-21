        Private subMenuStyles As SubMenuStyleCollection

        ' Associate the SubMenuStyleCollectionEditor with the 
        ' LevelSubMenuStyles.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            SubMenuStyleCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property LevelSubMenuStyles() As SubMenuStyleCollection
            Get
                Return subMenuStyles
            End Get
            Set
                subMenuStyles = value
            End Set
        End Property ' LevelSubMenuStyles