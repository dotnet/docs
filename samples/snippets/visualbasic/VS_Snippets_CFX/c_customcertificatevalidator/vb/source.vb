'<snippet3>
Imports System.IdentityModel.Selectors
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.IdentityModel.Tokens
Imports System.Security.Permissions

<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface


Public Class CalculatorService
    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
       Implements ICalculator.Add
        Dim result As Double = n1 + n2
        Return result
    End Function
End Class


Class Program

    Shared Sub Main()
        Dim serviceHost As New ServiceHost(GetType(CalculatorService))
        Try
            '<snippet1>
            serviceHost.Credentials.ClientCertificate.Authentication. _
                CertificateValidationMode = X509CertificateValidationMode.Custom
            serviceHost.Credentials.ClientCertificate.Authentication. _
               CustomCertificateValidator = New MyX509CertificateValidator("CN=Contoso.com")
            '</snippet1>
            serviceHost.Open()
            Console.WriteLine("Service started, press ENTER to stop ...")
            Console.ReadLine()

            serviceHost.Close()
        Finally
            serviceHost.Close()
        End Try

    End Sub
End Class

'<snippet2>
Public Class MyX509CertificateValidator
    Inherits X509CertificateValidator
    Private allowedIssuerName As String

    Public Sub New(ByVal allowedIssuerName As String)
        If allowedIssuerName Is Nothing Then
            Throw New ArgumentNullException("allowedIssuerName")
        End If

        Me.allowedIssuerName = allowedIssuerName

    End Sub

    Public Overrides Sub Validate(ByVal certificate As X509Certificate2)
        ' Check that there is a certificate.
        If certificate Is Nothing Then
            Throw New ArgumentNullException("certificate")
        End If

        ' Check that the certificate issuer matches the configured issuer.
        If allowedIssuerName <> certificate.IssuerName.Name Then
            Throw New SecurityTokenValidationException _
              ("Certificate was not issued by a trusted issuer")
        End If

    End Sub
End Class
'</snippet2>
'</snippet3>
