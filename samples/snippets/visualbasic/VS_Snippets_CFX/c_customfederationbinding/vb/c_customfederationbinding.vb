'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions

'</snippet1>




Public NotInheritable Class CustomBindingCreator

    '<snippet2>
    ' This method creates a CustomBinding based on a WSFederationHttpBinding which does not use secure conversation.
    Public Shared Function CreateFederationBindingWithoutSecureSession(ByVal inputBinding As WSFederationHttpBinding) As CustomBinding
        ' This CustomBinding starts out identical to the specified WSFederationHttpBinding.
        Dim outputBinding As New CustomBinding(inputBinding.CreateBindingElements())
        ' Find the SecurityBindingElement for message security.
        Dim security As SecurityBindingElement = outputBinding.Elements.Find(Of SecurityBindingElement)()
        ' If the security mode is message, then the secure session settings are the protection token parameters.
        Dim secureConversation As SecureConversationSecurityTokenParameters
        If WSFederationHttpSecurityMode.Message = inputBinding.Security.Mode Then
            Dim symmetricSecurity As SymmetricSecurityBindingElement = CType(security, SymmetricSecurityBindingElement)
            secureConversation = CType(symmetricSecurity.ProtectionTokenParameters, SecureConversationSecurityTokenParameters)
            ' If the security mode is message, then the secure session settings are the endorsing token parameters.
        ElseIf WSFederationHttpSecurityMode.TransportWithMessageCredential = inputBinding.Security.Mode Then
            Dim transportSecurity As TransportSecurityBindingElement = CType(security, TransportSecurityBindingElement)
            secureConversation = CType(transportSecurity.EndpointSupportingTokenParameters.Endorsing(0), SecureConversationSecurityTokenParameters)
        Else
            Throw New NotSupportedException(String.Format("Unhandled security mode {0}.", inputBinding.Security.Mode))
        End If
        ' Replace the secure session SecurityBindingElement with the bootstrap SecurityBindingElement.
        Dim securityIndex As Integer = outputBinding.Elements.IndexOf(security)
        outputBinding.Elements(securityIndex) = secureConversation.BootstrapSecurityBindingElement
        ' Return modified binding.
        Return outputBinding

    End Function

    '</snippet2>
    ' It is a good practice to create a private constructor for a class that only 
    ' defines static methods.
    Private Sub New()

    End Sub

    Shared Sub Main()

    End Sub
End Class

'</snippet0>
