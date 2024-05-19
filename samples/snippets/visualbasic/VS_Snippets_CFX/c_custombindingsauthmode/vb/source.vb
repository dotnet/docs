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

    NotInheritable Public Class CustomBindingCreator

        Private Sub New()

        End Sub

        '<snippet2>
        ' These public methods create custom bindings based on the built-in 
        ' authentication modes that use the static methods of 
        ' the System.ServiceModel.Channels.SecurityBindingElement class.
        Public Shared Function CreateAnonymousForCertificateBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateAnonymousForCertificateBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function


        Public Shared Function CreateAnonymousForSslNegotiatedBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateSslNegotiationBindingElement(False))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateCertificateOverTransportBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateCertificateOverTransportBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpsTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateIssuedTokenBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateIssuedTokenBindingElement( _
                    New IssuedSecurityTokenParameters()))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateIssuedTokenForCertificateBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateIssuedTokenForCertificateBindingElement( _
                New IssuedSecurityTokenParameters()))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateIssuedTokenForSslNegotiatedBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateIssuedTokenForSslBindingElement( _
                New IssuedSecurityTokenParameters()))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateIssuedTokenOverTransportBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
               CreateIssuedTokenOverTransportBindingElement( _
                  New IssuedSecurityTokenParameters()))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpsTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateKerberosBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateKerberosBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateKerberosOverTransportBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateKerberosOverTransportBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpsTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateMutualCertificateBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateMutualCertificateBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateMutualCertificateDuplexBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateMutualCertificateDuplexBindingElement())
            bec.Add(New CompositeDuplexBindingElement())
            bec.Add(New OneWayBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateMutualSslNegotiatedBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateSslNegotiationBindingElement(True))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateSecureConversationBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateSecureConversationBindingElement( _
                SecurityBindingElement.CreateSspiNegotiationBindingElement()))
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateSspiNegotiatedBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateSspiNegotiationBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function


        Public Shared Function CreateSspiNegotiatedOverTransportBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement. _
                CreateSspiNegotiationOverTransportBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpsTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateUserNameForCertificateBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateUserNameForCertificateBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)
        End Function

        Public Shared Function CreateUserNameForSslNegotiatedBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateUserNameForSslBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpTransportBindingElement())
            Return New CustomBinding(bec)

        End Function 'CreateUserNameForSslNegotiatedBinding


        Public Shared Function CreateUserNameOverTransportBinding() As Binding
            Dim bec As New BindingElementCollection()
            bec.Add(SecurityBindingElement.CreateUserNameOverTransportBindingElement())
            bec.Add(New TextMessageEncodingBindingElement())
            bec.Add(New HttpsTransportBindingElement())
            Return New CustomBinding(bec)

        End Function
        '</snippet2>
    End Class
End Namespace
'</snippet0>

Namespace samples2

    Public Class Test

        Shared Sub Main()

        End Sub

        Public Shared Function CreateCustomBinding() As Binding

            '<snippet3>
            Dim b As SymmetricSecurityBindingElement = _
            SecurityBindingElement.CreateAnonymousForCertificateBindingElement()
            '</snippet3>

            '<snippet4>
            Dim outputBindings As New BindingElementCollection()
            '</snippet4>

            '<snippet5>
            b.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128
            b.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt
            b.ProtectionTokenParameters = New KerberosSecurityTokenParameters()
            '<snippet5>

            '<snippet6>
            outputBindings.Add(b)
            outputBindings.Add(New TextMessageEncodingBindingElement())
            outputBindings.Add(New HttpTransportBindingElement())
            '</snippet6>

            '<snippet7>
            Return New CustomBinding(outputBindings)
            '</snippet7>
        End Function
    End Class
End Namespace
