' <Snippet2>
' <Snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet

    Public Class FileSystemDataSource
        Inherits HierarchicalDataSourceControl

        Public Sub New()
        End Sub

        Private view As FileSystemDataSourceView = Nothing

        Protected Overrides Function GetHierarchicalView( _
            ByVal viewPath As String) As HierarchicalDataSourceView

            view = New FileSystemDataSourceView(viewPath)
            Return view
        End Function

    End Class
    ' </Snippet1>
    ' <Snippet3>
    Public Class FileSystemDataSourceView
        Inherits HierarchicalDataSourceView

        Private _viewPath As String

        Public Sub New(ByVal viewPath As String)
            Dim currentRequest As HttpRequest = HttpContext.Current.Request
            If viewPath = "" Then
                _viewPath = currentRequest.MapPath(currentRequest.ApplicationPath)
            Else
                _viewPath = Path.Combine(currentRequest.MapPath(currentRequest.ApplicationPath), viewPath)
            End If
        End Sub 'New


        ' Starting with the rootNode, recursively build a list of
        ' FileSystemInfo nodes, create FileSystemHierarchyData
        ' objects, add them all to the FileSystemHierarchicalEnumerable,
        ' and return the list.
        Public Overrides Function [Select]() As IHierarchicalEnumerable
            Dim currentRequest As HttpRequest = HttpContext.Current.Request

            ' SECURITY: There are many security issues that can be raised
            ' SECURITY: by exposing the file system structure of a Web server
            ' SECURITY: to an anonymous user in a limited trust scenario such as
            ' SECURITY: a Web page served on an intranet or the Internet.
            ' SECURITY: For this reason, the FileSystemDataSource only
            ' SECURITY: shows data when the HttpRequest is received
            ' SECURITY: from a local Web server. In addition, the data source
            ' SECURITY: does not display data to anonymous users.
            If currentRequest.IsAuthenticated AndAlso _
                (currentRequest.UserHostAddress = "127.0.0.1" OrElse _
                 currentRequest.UserHostAddress = "::1") Then

                Dim rootDirectory As New DirectoryInfo(_viewPath)

                Dim fshe As New FileSystemHierarchicalEnumerable()

                Dim fsi As FileSystemInfo
                For Each fsi In rootDirectory.GetFileSystemInfos()
                    fshe.Add(New FileSystemHierarchyData(fsi))
                Next fsi
                Return fshe
            Else
                Throw New NotSupportedException( _
                    "The FileSystemDataSource only " + _
                    "presents data in an authenticated, localhost context.")
            End If
        End Function 'Select
    End Class 'FileSystemDataSourceView
    ' </Snippet3>
    ' <Snippet4>

    Public Class FileSystemHierarchicalEnumerable
        Inherits ArrayList
        Implements IHierarchicalEnumerable

        Public Sub New()
        End Sub


        Public Overridable Function GetHierarchyData( _
            ByVal enumeratedItem As Object) As IHierarchyData _
            Implements IHierarchicalEnumerable.GetHierarchyData

            Return CType(enumeratedItem, IHierarchyData)
        End Function

    End Class

    ' </Snippet4>
    ' <Snippet5>

    Public Class FileSystemHierarchyData
        Implements IHierarchyData

        Public Sub New(ByVal obj As FileSystemInfo)
            fileSystemObject = obj
        End Sub

        Private fileSystemObject As FileSystemInfo = Nothing

        Public Overrides Function ToString() As String
            Return fileSystemObject.Name
        End Function
        ' <Snippet6>

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
        ' </Snippet6>
        ' <Snippet7>
        ' DirectoryInfo returns the OriginalPath, while FileInfo returns
        ' a fully qualified path.

        Public Overridable ReadOnly Property Path() As String _
         Implements IHierarchyData.Path
            Get
                Return fileSystemObject.ToString()
            End Get
        End Property
        ' </Snippet7>
        ' <Snippet8>

        Public Overridable ReadOnly Property Item() As Object _
         Implements IHierarchyData.Item
            Get
                Return fileSystemObject
            End Get
        End Property
        ' </Snippet8>
        ' <Snippet9>

        Public Overridable ReadOnly Property Type() As String _
         Implements IHierarchyData.Type
            Get
                Return "FileSystemData"
            End Get
        End Property

        ' </Snippet9>
        ' <Snippet10>
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
    ' </Snippet10>
    ' </Snippet5>
End Namespace
' </Snippet2>