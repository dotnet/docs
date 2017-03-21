
    Public Class FileSystemHierarchyData
        Implements IHierarchyData

        Public Sub New(ByVal obj As FileSystemInfo)
            fileSystemObject = obj
        End Sub

        Private fileSystemObject As FileSystemInfo = Nothing

        Public Overrides Function ToString() As String
            Return fileSystemObject.Name
        End Function

        ' IHierarchyData implementation.
        Public Overridable ReadOnly Property HasChildren() As Boolean _
         Implements IHierarchyData.HasChildren
            Get
                If GetType(DirectoryInfo) Is fileSystemObject.GetType() Then
                    Dim temp As DirectoryInfo = _
                        CType(fileSystemObject, DirectoryInfo)
                    Return temp.GetFileSystemInfos().Length > 0
                Else
                    Return False
                End If
            End Get
        End Property
        ' DirectoryInfo returns the OriginalPath, while FileInfo returns
        ' a fully qualified path.

        Public Overridable ReadOnly Property Path() As String _
         Implements IHierarchyData.Path
            Get
                Return fileSystemObject.ToString()
            End Get
        End Property

        Public Overridable ReadOnly Property Item() As Object _
         Implements IHierarchyData.Item
            Get
                Return fileSystemObject
            End Get
        End Property

        Public Overridable ReadOnly Property Type() As String _
         Implements IHierarchyData.Type
            Get
                Return "FileSystemData"
            End Get
        End Property

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