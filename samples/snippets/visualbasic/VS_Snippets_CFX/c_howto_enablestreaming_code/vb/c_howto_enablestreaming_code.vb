'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions
'</snippet1>
Namespace Samples
    Public NotInheritable Class EnableStreaming
        Private Sub New()
        End Sub

        '<snippet2>
        Public Shared Function CreateStreamingBinding() As Binding
            Dim b As New BasicHttpBinding()
            b.TransferMode = TransferMode.Streamed
            Return b
        End Function
        '</snippet2>

    End Class
    Public NotInheritable Class EnableStreamingCustom

        Private Sub New()
        End Sub

        '<snippet3>
        Public Shared Function CreateStreamingBinding() As Binding
            Dim transport As New TcpTransportBindingElement()
            transport.TransferMode = TransferMode.Streamed
            Dim binding As New CustomBinding(New BinaryMessageEncodingBindingElement(), _
                                             transport)
            Return binding
        End Function
        '</snippet3>

    End Class
End Namespace
'</snippet0>
