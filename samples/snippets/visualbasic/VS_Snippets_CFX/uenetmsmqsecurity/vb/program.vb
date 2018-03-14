Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel

Namespace UEMessageSecurityMsmq
    Friend Class Program

        Shared Sub Main(ByVal args() As String)
            ' <Snippet1>
            Dim binding As New NetMsmqBinding()
            Dim security = binding.Security
            ' </Snippet1>

            ' <Snippet2>
            Dim msgSecurity = security.Message
            ' </Snippet2>

            ' <Snippet3>
            Dim secMode = security.Mode
            ' </Snippet3>

            ' <Snippet4>
            Dim trnsSecurity = security.Transport
            ' </Snippet4>

        End Sub

    End Class
End Namespace
