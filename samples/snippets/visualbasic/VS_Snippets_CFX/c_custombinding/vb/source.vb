'<snippet0>
'<snippet1>
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions

'</snippet1>
NotInheritable Public Class CustomBindingCreator

    Private Sub New()

    End Sub

    '<snippet2>
    ' This method creates a CustomBinding using a SymmetricSecurityBindingElement.
    ' It is largely equivalent to doing the following:
    ' Dim b As WSHttpBinding = new WSHttpBinding (SecurityMode.Message)
    ' b.Security.Message.ClientCredentialType = MessageCredentialType.Windows
    ' b.Security.Message.NegotiateServiceCredential = false
    ' b.Security.Message.EstablishSecureSession = false
    ' It differs in that it uses MessageProtectionOrder.SignBeforeEncrypt rather
    ' than MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature.
    ' <snippet3>
    Public Shared Function CreateCustomBinding() As Binding
        ' Create an empty BindingElementCollection to populate, 
        ' then create a custom binding from it.
        Dim outputBec As New BindingElementCollection()

        ' Create a SymmetricSecurityBindingElement.
        Dim ssbe As New SymmetricSecurityBindingElement()

        ' Set the algorithm suite to one that uses 128-bit keys.
        ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128

        ' Set MessageProtectionOrder to SignBeforeEncrypt.
        ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt

        ' Use a Kerberos token as the protection token.
        ssbe.ProtectionTokenParameters = New KerberosSecurityTokenParameters()

        ' Add the SymmetricSecurityBindingElement to the BindingElementCollection.
        outputBec.Add(ssbe)
        outputBec.Add(New TextMessageEncodingBindingElement())
        outputBec.Add(New HttpTransportBindingElement())

        ' Create a CustomBinding and return it; otherwise, return null.
        Return New CustomBinding(outputBec)

    End Function
    ' </snippet3>
    '</snippet2>
End Class
Public NotInheritable Class CustomBindingCreator2

    Private Sub New()

    End Sub

    '<snippet20>
    Public Shared Function CreateCustomBinding() As Binding
        ' Create an empty Custom Binding to populate, 
        Dim binding As New CustomBinding()
        ' Create a SymmetricSecurityBindingElement.
        Dim ssbe As SymmetricSecurityBindingElement
        ssbe = SecurityBindingElement.CreateSspiNegotiationBindingElement(True)
        ' Add the SymmetricSecurityBindingElement to the BindingElementCollection.
        binding.Elements.Add(ssbe)
        binding.Elements.Add(New TextMessageEncodingBindingElement())
        binding.Elements.Add(New HttpTransportBindingElement())
        Return New CustomBinding(binding)

    End Function
    '</snippet20>
End Class
'</snippet0>
