Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Security

Namespace UEMessageSecurityOverMsmq
    Friend Class Program

        Shared Sub Main(ByVal args() As String)
            ' <Snippet1>
            Dim binding As New NetMsmqBinding()
            Dim security = binding.Security
            Dim msOverMsmq = security.Message
            ' </Snippet1>

            ' <Snippet2>
            With msOverMsmq
                .AlgorithmSuite = SecurityAlgorithmSuite.Basic128
                ' </Snippet2>

                ' <Snippet3>
                .ClientCredentialType = MessageCredentialType.Certificate
                ' </Snippet3>
            End With
        End Sub

    End Class
End Namespace
