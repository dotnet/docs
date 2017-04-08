' <Snippet1>
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports Microsoft.VisualBasic

' Module that sets Response.SubStatusCode in PostAuthenticateRequest event handler.
Namespace Samples

    Public Class ModuleExampleTestVB
        Implements IHttpModule

        Public Sub New()
            ' Constructor
        End Sub

        Public Sub Init(ByVal app As HttpApplication) Implements IHttpModule.Init
            AddHandler app.PostAuthenticateRequest, AddressOf Me.PostAuthenticateRequest_Handler
        End Sub

        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub

        Public Sub PostAuthenticateRequest_Handler(ByVal source As Object, ByVal e As EventArgs)
            Dim app As HttpApplication = CType(source, HttpApplication)
            Dim context As HttpContext = app.Context

            ' Set a SubStatusCode for Failed Request Tracing in IIS7.
            context.Response.SubStatusCode = 99
        End Sub
    End Class

End Namespace
' </Snippet1>
