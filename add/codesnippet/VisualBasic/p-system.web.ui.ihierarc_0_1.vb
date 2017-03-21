        ' DirectoryInfo returns the OriginalPath, while FileInfo returns
        ' a fully qualified path.

        Public Overridable ReadOnly Property Path() As String _
         Implements IHierarchyData.Path
            Get
                Return fileSystemObject.ToString()
            End Get
        End Property