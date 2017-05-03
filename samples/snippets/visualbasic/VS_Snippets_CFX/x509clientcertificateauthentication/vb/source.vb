Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates

Public Class Test
    
    Shared Sub Main() 
        Dim t As New Test()
        t.Snippet7()
        Console.ReadLine()
    End Sub

    Private Sub Snippet1() 
        '<snippet1>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)
        
        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication
        
        ' Configure peer trust.
        myAuthProperties.CertificateValidationMode = X509CertificateValidationMode.PeerTrust
        ' Configure chain trust.
        myAuthProperties.CertificateValidationMode = X509CertificateValidationMode.ChainTrust
        ' Configure custom certificate validation.
        myAuthProperties.CertificateValidationMode = X509CertificateValidationMode.Custom
        ' Specify a custom certificate validator (not shown here) that inherits 
        ' from the X509CertificateValidator class. 
        ' creds.ClientCertificate.Authentication.CustomCertificateValidator = _
        '    new MyCertificateValidator()
        '</snippet1>
    End Sub

    Private Sub Snippet2()
        '<snippet2>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication

        ' Configure custom certificate validation.
        myAuthProperties.CertificateValidationMode = X509CertificateValidationMode.Custom
        ' Specify a custom certificate validator (not shown here) that inherits 
        ' from the X509CertificateValidator class.
        ' creds.ClientCertificate.Authentication.CustomCertificateValidator = _
        '    new MyCertificateValidator()
        '</snippet2>

    End Sub


    Private Sub Snippet3()
        '<snippet3>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)
        ' Create a binding that uses a certificate.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate


        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication
        ' Configure IncludeWindowsGroups.
        myAuthProperties.IncludeWindowsGroups = True
        '</snippet3>
    End Sub


    Private Sub Snippet4()
        '<snippet4>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses Windows security.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = MessageCredentialType.Windows

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication
        ' Configure IncludeWindowsGroups.
        myAuthProperties.IncludeWindowsGroups = True
        '</snippet4>
    End Sub


    Private Sub Snippet5()
        '<snippet5>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses a certificate.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = _
        MessageCredentialType.Certificate

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication

        ' Configure ChainTrust with no revocation check.
        myAuthProperties.CertificateValidationMode = _
        X509CertificateValidationMode.ChainTrust
        myAuthProperties.RevocationMode = X509RevocationMode.NoCheck
        '</snippet5>
    End Sub

    Private Sub Snippet6()
        '<snippet6>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses a certificate.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = _
        MessageCredentialType.Certificate

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication
        ' Configure peer trust.
        myAuthProperties.CertificateValidationMode = _
        X509CertificateValidationMode.PeerTrust
        myAuthProperties.TrustedStoreLocation = StoreLocation.LocalMachine
        '</snippet6>
    End Sub

    Private Sub Snippet7()
        '<snippet7>
        ' Create a service host.
        Dim httpUri As New Uri("http://localhost/Calculator")
        Dim sh As New ServiceHost(GetType(Calculator), httpUri)

        ' Create a binding that uses a certificate.
        Dim b As New WSHttpBinding(SecurityMode.Message)
        b.Security.Message.ClientCredentialType = _
        MessageCredentialType.Certificate

        ' Get a reference to the authentication object.
        Dim myAuthProperties As X509ClientCertificateAuthentication = _
        sh.Credentials.ClientCertificate.Authentication()

        Select Case myAuthProperties.CertificateValidationMode
            Case X509CertificateValidationMode.ChainTrust
                Console.WriteLine("ChainTrust")
            Case X509CertificateValidationMode.Custom
                Console.WriteLine("Custom")
            Case X509CertificateValidationMode.None
                Console.WriteLine("ChainTrust")
            Case X509CertificateValidationMode.PeerOrChainTrust
                Console.WriteLine("PeerOrChainTrust")
            Case X509CertificateValidationMode.PeerTrust
                Console.WriteLine("PeerTrust")
            Case Else
                Console.WriteLine("Default")
        End Select
        '</snippet7>
    End Sub
End Class

<ServiceContract()>  _
Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal a As Double, ByVal b As Double) As Double 
End Interface

Public Class Calculator
    Implements ICalculator
    
    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b
    
    End Function
End Class