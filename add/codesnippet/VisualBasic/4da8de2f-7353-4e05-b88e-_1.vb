    ' This method can signal whether to enable or disable the specified
    ' ToolboxItem when the component associated with this designer is selected.
    Function GetToolSupported(ByVal tool As ToolboxItem) As Boolean Implements IToolboxUser.GetToolSupported
        ' Search the blocked type names array for the type name of the tool
        ' for which support for is being tested. Return false to indicate the
        ' tool should be disabled when the associated component is selected.
        Dim i As Integer
        For i = 0 To blockedTypeNames.Length - 1
            If tool.TypeName = blockedTypeNames(i) Then
                Return False
            End If
        Next i ' Return true to indicate support for the tool, if the type name of the
        ' tool is not located in the blockedTypeNames string array.
        Return True
    End Function