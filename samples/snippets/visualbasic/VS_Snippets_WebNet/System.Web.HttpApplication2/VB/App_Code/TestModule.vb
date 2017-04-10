' <Snippet1>
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports Microsoft.VisualBasic

' Module that demonstrates one event handler for several events.
Namespace Samples

    Public Class ModuleExample
        Implements IHttpModule

        Public Sub New()
            ' Constructor
        End Sub

        Public Sub Init(ByVal app As HttpApplication) Implements IHttpModule.Init
            AddHandler app.LogRequest, AddressOf Me.App_Handler
            AddHandler app.PostLogRequest, AddressOf Me.App_Handler
        End Sub

        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub

        ' One for both the LogRequest and PostLogRequest events.
        Public Sub App_Handler(ByVal source As Object, ByVal e As EventArgs)
            Dim app As HttpApplication = CType(source, HttpApplication)
            Dim context As HttpContext = app.Context

            If (context.CurrentNotification = RequestNotification.LogRequest) Then

                If Not (context.IsPostNotification) Then

                    ' Put code here that is invoked when the LogRequest event is raised.

                Else
                    ' PostLogRequest
                    ' Put code here that runs after the LogRequest event completes.

                End If
            End If
        End Sub
    End Class

End Namespace
' </Snippet1>
