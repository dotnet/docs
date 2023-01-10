'<snippet0>
Imports System.ServiceModel
Imports System.Net.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.Serialization
'</snippet0>

Namespace Samples1

    <ServiceContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
    Public Interface ICalculator

        <OperationContract(ProtectionLevel:=ProtectionLevel.Sign)> _
        Function Add(ByVal a As Double, _
                     ByVal b As Double) As Double
    End Interface

    <MessageContract(ProtectionLevel:=ProtectionLevel.Sign)> _
    Public Class Calculator
        Implements ICalculator

        Public Function Add(ByVal a As Double, _
                            ByVal b As Double) As Double Implements ICalculator.Add
            Return a + b
        End Function

    End Class

    Public Class Test
        Shared Sub Main()
            Dim t As New Test()
            Try
                t.Run()
            Catch inv As System.InvalidOperationException
                Console.WriteLine(inv.Message)
                Console.ReadLine()

            Catch exc As System.Exception
                Console.WriteLine(exc.Message)
                Console.ReadLine()
            End Try
        End Sub

        Private Sub Run()
            '<snippet9>
            '<snippet1>
            ' Create a binding and set the security mode to Message.
            Dim b As New WSHttpBinding(SecurityMode.Message)
            '</snippet1>

            '<snippet2>
            Dim contractType = GetType(ICalculator)
            Dim implementedContract = GetType(Calculator)
            '</snippet2>

            '<snippet3>
            Dim baseAddress As New Uri("http://localhost:8044/base")
            '</snippet3>

            '<snippet4>
            Dim sh As New ServiceHost(implementedContract, baseAddress)
            '</snippet4>

            '<snippet5>
            sh.AddServiceEndpoint(contractType, b, "Calculator")
            '</snippet5>

            '<snippet6>
            Dim sm As New ServiceMetadataBehavior()
            sm.HttpGetEnabled = True

            With sh
                .Description.Behaviors.Add(sm)
                '</snippet6>

                '<snippet7>
                .Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, _
                                                               StoreName.My, _
                                                               X509FindType.FindBySubjectName, _
                                                               "localhost")
                '</snippet7>

                '<snippet8>
                .Open()
                Console.WriteLine("Listening")
                Console.ReadLine()
                '</snippet8>
                .Close()
            End With
            '</snippet9>

        End Sub
    End Class
End Namespace

