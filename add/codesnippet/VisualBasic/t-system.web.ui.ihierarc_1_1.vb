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