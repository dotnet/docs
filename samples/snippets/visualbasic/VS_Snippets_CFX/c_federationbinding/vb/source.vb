'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions

Namespace Samples
    '</snippet1>
    Public NotInheritable Class CustomBindingCreator
        '<snippet2>
        ' This method creates a WSFederationHttpBinding.
        Public Shared Function CreateWSFederationHttpBinding(ByVal isClient As Boolean) As WSFederationHttpBinding
            ' Create an instance of the WSFederationHttpBinding.
            Dim b As New WSFederationHttpBinding()
            With b.Security
                ' Set the security mode to Message.
                .Mode = WSFederationHttpSecurityMode.Message

                With .Message
                    ' Set the Algorithm Suite to Basic256Rsa15.
                    .AlgorithmSuite = SecurityAlgorithmSuite.Basic256Rsa15

                    ' Set NegotiateServiceCredential to true.
                    .NegotiateServiceCredential = True

                    ' Set IssuedKeyType to Symmetric.
                    .IssuedKeyType = SecurityKeyType.SymmetricKey

                    ' Set IssuedTokenType to SAML 1.1
                    .IssuedTokenType = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#samlv1.1"
                End With
            End With

            ' Extract the STS certificate from the certificate store.
            Dim store As New X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadOnly)
            Dim certs = store.Certificates.Find(X509FindType.FindByThumbprint, _
                                                "0000000000000000000000000000000000000000", _
                                                False)
            store.Close()

            ' Create an EndpointIdentity from the STS certificate.
            Dim identity = EndpointIdentity.CreateX509CertificateIdentity(certs(0))

            ' Set the IssuerAddress using the address of the STS and the previously created 
            ' EndpointIdentity.
            With b.Security.Message
                .IssuerAddress = New EndpointAddress(New Uri("http://localhost:8000/sts/x509"), _
                                                                                   identity)

                ' Set the IssuerBinding to a WSHttpBinding loaded from configuration. 
                ' The IssuerBinding is only used on federated clients.
                If isClient Then
                    .IssuerBinding = New WSHttpBinding("Issuer")

                    ' Set the IssuerMetadataAddress using the metadata address of the STS and the
                    ' previously created EndpointIdentity. The IssuerMetadataAddress is only used 
                    ' on federated services.
                Else
                    .IssuerMetadataAddress = New EndpointAddress(New Uri("http://localhost:8001/sts/mex"), _
                                                                                   identity)
                End If
                ' Create a ClaimTypeRequirement.
                Dim ctr As New ClaimTypeRequirement("http://example.org/claim/c1", _
                                                    False)

                ' Add the ClaimTypeRequirement to ClaimTypeRequirements
                .ClaimTypeRequirements.Add(ctr)
            End With

            ' Return the created binding
            Return b
        End Function
        '</snippet2>
        ' It is a good practice to create a private constructor for a class that only 
        ' defines static methods.
        Private Sub New()
        End Sub

    End Class
    '</snippet0>
End Namespace
