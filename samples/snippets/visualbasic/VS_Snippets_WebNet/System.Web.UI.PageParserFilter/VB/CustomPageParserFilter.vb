Imports Microsoft.VisualBasic
Imports System.Security
Imports System.Security.Permissions
Imports System.Web.UI

'<Snippet2>
Namespace Samples.AspNet.VB
    <PermissionSet(SecurityAction.Demand, Unrestricted := true)> _
    Public Class CustomPageParserFilter
        Inherits PageParserFilter

        Public Overrides ReadOnly Property AllowCode() As Boolean
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
'</Snippet2>
