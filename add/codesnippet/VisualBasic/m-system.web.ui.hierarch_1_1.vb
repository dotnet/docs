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