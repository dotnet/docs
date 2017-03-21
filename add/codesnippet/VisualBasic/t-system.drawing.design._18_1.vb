    Public Function CreateToolboxComponentsCreatedEventArgs(ByVal components() As System.ComponentModel.IComponent) As ToolboxComponentsCreatedEventArgs
        Dim e As New ToolboxComponentsCreatedEventArgs(components)
        ' The components that were just created        e.Components            
        Return e
    End Function
