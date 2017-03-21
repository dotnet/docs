        ' This property exists only to demonstrate the 
        ' PasswordPropertyText attribute. When this control 
        ' is attached to a PropertyGrid control, the returned 
        ' string will be displayed with obscuring characters
        ' such as asterisks. This property has no other effect.
        <Category("Security"), _
        Description("Demonstrates PasswordPropertyTextAttribute."), _
        PasswordPropertyText(True)> _
        Public ReadOnly Property Password() As String
            Get
                Return "This is a demo password."
            End Get
        End Property