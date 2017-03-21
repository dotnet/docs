    Public Function CreateToolboxComponentsCreatingEventArgs(ByVal host As System.ComponentModel.Design.IDesignerHost) As ToolboxComponentsCreatingEventArgs
        Dim e As New ToolboxComponentsCreatingEventArgs(host)
        ' The designer host of the document receiving the components        e.DesignerHost            
        Return e
    End Function