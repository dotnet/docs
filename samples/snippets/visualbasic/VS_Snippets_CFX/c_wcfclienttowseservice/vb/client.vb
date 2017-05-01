' Copyright (c) Microsoft Corporation.  All Rights Reserved.
' <snippet0>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Channels
Imports Microsoft.VisualBasic

Namespace Microsoft.ServiceModel.Samples

    ' The service contract is defined in generatedClient.vb, generated from the service by

    ' the svcutil tool.
    Class Program

        Public Shared Sub Main(ByVal args As String())

            CallWseService(True)

        End Sub

        ' <snippet4> 
        Private Shared Sub CallWseService(ByVal usePolicyFile As Boolean)

            Dim address As New EndpointAddress(New Uri("http://localhost/WSSecurityAnonymousPolicy/WSSecurityAnonymousService.asmx"), EndpointIdentity.CreateDnsIdentity("WSE2QuickStartServer"))

            Dim binding As New WseHttpBinding()
            If Not usePolicyFile Then

                binding.SecurityAssertion = WseSecurityAssertion.AnonymousForCertificate
                binding.EstablishSecurityContext = True
                binding.RequireDerivedKeys = True
                binding.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt

            Else
                binding.LoadPolicy("..\wse3policyCache.config", "ServerPolicy")
            End If

            Dim client As New WSSecurityAnonymousServiceSoapClient(binding, address)
            ' </snippet4>

            ' Need to supply the credentials depending on the type of WseSecurityAssertion used.
            ' Anonymous only requires server certificate. UsernameForCertificate would also require
            ' a username and password to be supplied.
            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectDistinguishedName, "CN=WSE2QuickStartServer")
            Dim symbols As String() = New String() {"FABRIKAM", "CONTOSO"}
            Dim quotes As StockQuote() = client.StockQuoteRequest(symbols)

            client.Close()

            ' Success!
            For Each quote As StockQuote In quotes

                Console.WriteLine("")
                Console.WriteLine("Symbol: " + quote.Symbol)
                Console.WriteLine("" & Chr(9) & "Name:" & Chr(9) & "" & Chr(9) & "" & Chr(9) & "" + quote.Name)
                Console.WriteLine("" & Chr(9) & "Last Price:" & Chr(9) & "" & Chr(9) & "" & quote.Last)
                Console.WriteLine("" & Chr(9) & "Previous Change:" & Chr(9) & "" & quote.PreviousChange & "%")

            Next

            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()

        End Sub

    End Class

End Namespace
' </snippet0>