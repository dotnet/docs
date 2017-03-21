        ' This property exists only to demonstrate the 
        ' DisplayName attribute. When this control 
        ' is attached to a PropertyGrid control, the
        ' property will be appear as "RenamedProperty"
        ' instead of "MisnamedProperty".
        <Description("Demonstrates DisplayNameAttribute."), _
        DisplayName("RenamedProperty")> _
        Public ReadOnly Property MisnamedProperty() As Boolean
            Get
                Return True
            End Get
        End Property