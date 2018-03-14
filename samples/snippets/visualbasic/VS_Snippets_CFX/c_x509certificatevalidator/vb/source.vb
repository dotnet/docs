
Imports System
Imports System.IdentityModel.Selectors
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.IdentityModel.Tokens
Imports System.Security.Permissions


<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 

<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface 'ICalculator


Public Class CalculatorService
    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
        Dim result As Double = n1 + n2
        Return result

    End Function 'Add
End Class 'CalculatorService


Class Program

    Shared Sub Main()
        Dim serviceHost As New ServiceHost(GetType(CalculatorService))
        serviceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom
        serviceHost.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = New MyX509CertificateValidator("CN=Contoso.com")

        serviceHost.Open()
        Console.WriteLine("Service started, press ENTER to stop ...")
        Console.ReadLine()

        serviceHost.Close()

    End Sub 'Main
End Class 'Program

'<snippet1>

Public Class MyX509CertificateValidator
    Inherits X509CertificateValidator
    Private allowedIssuerName As String

    ' <snippet3>
    Public Sub New(ByVal allowedIssuerName As String)
        If allowedIssuerName Is Nothing Then
            Throw New ArgumentNullException("allowedIssuerName")
        End If

        Me.allowedIssuerName = allowedIssuerName

    End Sub 'New

    ' </snippet3>
    ' <snippet2>
    Public Overrides Sub Validate(ByVal certificate As X509Certificate2)
        ' Check that there is a certificate.
        If certificate Is Nothing Then
            Throw New ArgumentNullException("certificate")
        End If

        ' Check that the certificate issuer matches the configured issuer
        If allowedIssuerName <> certificate.IssuerName.Name Then
            Throw New SecurityTokenValidationException("Certificate was not issued by a trusted issuer")
        End If

    End Sub 'Validate
End Class 'MyX509CertificateValidator
' </snippet2>
'</snippet1>
