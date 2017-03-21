    ' This method override returns an type array containing the type of 
    ' each component editor page to display.
    Protected Overrides Function GetComponentEditorPages() As Type()
        Return New Type() {GetType(ExampleComponentEditorPage), GetType(ExampleComponentEditorPage)}
    End Function