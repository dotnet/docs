        Public Overridable Function GetChildren() _
            As IHierarchicalEnumerable _
            Implements IHierarchyData.GetChildren

            Dim children As New FileSystemHierarchicalEnumerable()

            If GetType(DirectoryInfo) Is fileSystemObject.GetType() Then
                Dim temp As DirectoryInfo = _
                    CType(fileSystemObject, DirectoryInfo)
                Dim fsi As FileSystemInfo
                For Each fsi In temp.GetFileSystemInfos()
                    children.Add(New FileSystemHierarchyData(fsi))
                Next fsi
            End If
            Return children
        End Function 'GetChildren


        Public Overridable Function GetParent() As IHierarchyData _
         Implements IHierarchyData.GetParent
            Dim parentContainer As New FileSystemHierarchicalEnumerable()

            If GetType(DirectoryInfo) Is fileSystemObject.GetType() Then
                Dim temp As DirectoryInfo = _
                    CType(fileSystemObject, DirectoryInfo)
                Return New FileSystemHierarchyData(temp.Parent)
            ElseIf GetType(FileInfo) Is fileSystemObject.GetType() Then
                Dim temp As FileInfo = CType(fileSystemObject, FileInfo)
                Return New FileSystemHierarchyData(temp.Directory)
            End If
            ' If FileSystemObj is any other kind of FileSystemInfo, ignore it.
            Return Nothing
        End Function 'GetParent
    End Class 'FileSystemHierarchyData