'<snippet0>
Imports System.Collections
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.ServiceModel.Description
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Namespace Replay
    Public Class Test

        Public Sub New()
        End Sub

        Shared Sub Main()
            Try
                Dim t As New Test()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        '<snippet1>
        Private Function CreateSymmetricBindingForClient() As SecurityBindingElement
            Dim b = SecurityBindingElement.CreateKerberosBindingElement()
            With b.LocalClientSettings
                .DetectReplays = True
                .MaxClockSkew = New TimeSpan(0, 3, 0)
                .ReplayWindow = New TimeSpan(0, 2, 0)
                .ReplayCacheSize = 10000
            End With
            Return b
        End Function
        '</snippet1>

    End Class
End Namespace
