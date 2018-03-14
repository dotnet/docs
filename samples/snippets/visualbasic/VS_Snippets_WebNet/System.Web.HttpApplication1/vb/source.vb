 ' <Snippet1>
Imports System
Imports System.Web

Namespace Samples.AspNet.VB
    Public Class CustomHTTPModule
        Implements IHttpModule

        Public Sub New()

            ' Class constructor.

        End Sub


        ' Classes that inherit IHttpModule 
        ' must implement the Init and Dispose methods.
        Public Sub Init(ByVal app As HttpApplication) Implements IHttpModule.Init

            AddHandler app.AcquireRequestState, AddressOf app_AcquireRequestState
            AddHandler app.PostAcquireRequestState, AddressOf app_PostAcquireRequestState

        End Sub


        Public Sub Dispose() Implements IHttpModule.Dispose

            ' Add code to clean up the
            ' instance variables of a module.

        End Sub


        ' Define a custom AcquireRequestState event handler.
        Public Sub app_AcquireRequestState(ByVal o As Object, ByVal ea As EventArgs)

            Dim httpApp As HttpApplication = CType(o, HttpApplication)
            Dim ctx As HttpContext = HttpContext.Current
            ctx.Response.Write(" Executing AcquireRequestState ")

        End Sub

        ' Define a custom PostAcquireRequestState event handler.
        Public Sub app_PostAcquireRequestState(ByVal o As Object, ByVal ea As EventArgs)

            Dim httpApp As HttpApplication = CType(o, HttpApplication)
            Dim ctx As HttpContext = HttpContext.Current
            ctx.Response.Write(" Executing PostAcquireRequestState ")

        End Sub

    End Class

End Namespace
' </Snippet1>