        Private localBindings As MenuItemBindingCollection

        ' Associate the MenuBindingsEditor with the DataBindings.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuBindingsEditor), _
            GetType(UITypeEditor))> _
        Public Property DataBindings() As MenuItemBindingCollection
            Get
                Return localBindings
            End Get
            Set
                localBindings = value
            End Set
        End Property ' DataBindings