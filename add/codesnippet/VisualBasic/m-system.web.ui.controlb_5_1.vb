        ' Override the AppendSubBuilder method to throw an
        ' exception if the class it is applied to attempts
        ' to include child controls. 
        Public Overrides Sub AppendSubBuilder(ByVal subBuilder As ControlBuilder)
            Throw New Exception( _
               "A custom label control cannot contain other objects.")
        End Sub