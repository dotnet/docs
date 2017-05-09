'<SnippetHandleStartupCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace VisualBasic
    Partial Public Class App
        Inherits Application
        Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
            ' Parse command line arguments for "/SafeMode"
            Me.Properties("SafeMode") = False
            Dim i As Integer = 0
            Do While i <> e.Args.Length
                If e.Args(i).ToLower() = "/safemode" Then
                    Me.Properties("SafeMode") = True
                    Exit Do
                End If
                i += 1
            Loop
        End Sub
    End Class
End Namespace
'</SnippetHandleStartupCODEBEHIND>