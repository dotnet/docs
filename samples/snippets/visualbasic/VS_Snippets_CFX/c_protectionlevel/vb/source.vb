'<snippet0>
Imports System.ServiceModel
Imports System.Net.Security
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.Serialization

'</snippet0>

Namespace Microsoft.WCF.Samples1

    '<snippet2>
    '<snippet1>
    ' Set the ProtectionLevel on the whole service to Sign.
    <ServiceContract(ProtectionLevel:=ProtectionLevel.Sign)> _
    Public Interface ICalculator
        '</snippet1>

        ' Set the ProtectionLevel on this operation to Sign.
        <OperationContract(ProtectionLevel:=ProtectionLevel.Sign)> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface
    '</snippet2>
End Namespace

Namespace Samples2
    '<snippet3>
    <DataContract()> _
    Public Class MathFault
        <DataMember()> _
        Public operation As String
        <DataMember()> _
        Public description As String
    End Class
    '</snippet3>

    '<snippet4>
    Public Interface ICalculator
        ' Set the ProtectionLevel on a FaultContractAttribute.
        <OperationContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign), _
         FaultContract(GetType(MathFault), ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface
    '</snippet4> 

End Namespace

Namespace Samples3
    '<snippet6>
    <ServiceContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
    Public Interface ICalculator
        <OperationContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double


        <OperationContract(), _
           FaultContract _
           (GetType(MathFault), _
           Action:="http://localhost/Add", _
           Name:="AddFault", _
           Namespace:="http://contoso.com", _
           ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
        Function Subtract(ByVal a As Double, ByVal b As Double) As Double

        <OperationContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
        Function GetCompanyInfo() As Company
    End Interface


    <DataContract()> _
    Public Class MathFault
        <DataMember()> _
        Public operation As String
        <DataMember()> _
        Public description As String
    End Class

    '<snippet5>
    <MessageContract(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
    Public Class Company
        <MessageHeader(ProtectionLevel:=ProtectionLevel.Sign)> _
        Public CompanyName As String

        <MessageBodyMember(ProtectionLevel:=ProtectionLevel.EncryptAndSign)> _
        Public CompanyID As String
    End Class
    '</snippet5>

    <MessageContract(ProtectionLevel:=ProtectionLevel.Sign)> _
    Public Class Calculator
        Implements ICalculator

        Public Function Add(ByVal a As Double, ByVal b As Double) As Double _
          Implements ICalculator.Add
            Return a + b

        End Function

        Public Function Subtract(ByVal a As Double, ByVal b As Double) As Double _
           Implements ICalculator.Subtract
            Return a - b

        End Function

        Public Function GetCompanyInfo() As Company Implements ICalculator.GetCompanyInfo
            Dim co As New Company()
            co.CompanyName = "www.cohowinery.com"
            Return co
        End Function
    End Class


    Public Class Test

        Shared Sub Main()
            Dim t As New Test()
            Try
                t.Run()
            Catch inv As System.InvalidOperationException
                Console.WriteLine(inv.Message)
            End Try
        End Sub


        Private Sub Run()
            ' Create a binding and set the security mode to Message.
            Dim b As New WSHttpBinding()
            b.Security.Mode = SecurityMode.Message

            Dim contractType As Type = GetType(ICalculator)
            Dim implementedContract As Type = GetType(Calculator)
            Dim baseAddress As New Uri("http://localhost:8044/base")

            ' Create the ServiceHost and add an endpoint.
            Dim sh As New ServiceHost(implementedContract, baseAddress)
            sh.AddServiceEndpoint(contractType, b, "Calculator")

            Dim sm As New ServiceMetadataBehavior()
            sm.HttpGetEnabled = True
            sh.Description.Behaviors.Add(sm)
            sh.Credentials.ServiceCertificate.SetCertificate( _
               StoreLocation.CurrentUser, StoreName.My, _
               X509FindType.FindByIssuerName, "ValidCertificateIssuer")

            Dim se As ServiceEndpoint
            For Each se In sh.Description.Endpoints
                Dim cd As ContractDescription = se.Contract
                Console.WriteLine(vbLf + "ContractDescription: ProtectionLevel = {0}", _
                   cd.Name, cd.ProtectionLevel)
                Dim od As OperationDescription
                For Each od In cd.Operations
                    Console.WriteLine(vbLf + "OperationDescription: Name = {0}", od.Name, od.ProtectionLevel)
                    Console.WriteLine("ProtectionLevel = {1}", od.Name, od.ProtectionLevel)
                    Dim m As MessageDescription
                    For Each m In od.Messages
                        Console.WriteLine(vbTab + " {0}: {1}", m.Action, m.ProtectionLevel)
                        Dim mh As MessageHeaderDescription
                        For Each mh In m.Headers
                            Console.WriteLine(vbTab + vbTab + " {0}: {1}", mh.Name, mh.ProtectionLevel)

                            Dim mp As MessagePropertyDescription
                            For Each mp In m.Properties
                                Console.WriteLine("{0}: {1}", mp.Name, mp.ProtectionLevel)
                            Next mp
                        Next mh
                    Next m
                Next od
            Next se
            sh.Open()
            Console.WriteLine("Listening")
            Console.ReadLine()
            sh.Close()

        End Sub
    End Class
    '</snippet6>

    '<snippet7>
    <ServiceContract()> _
    Public Interface IPurchaseOrder
        <OperationContract(ProtectionLevel:=ProtectionLevel.Sign)> _
        Function Price() As Integer
    End Interface
    '</snippet7>
End Namespace

Namespace NewIPurchaseOrder

    '<snippet8>
    <ServiceContract()> _
    Public Interface IPurchaseOrder
        <OperationContract()> _
        Function Tax() As Integer

        <OperationContract(ProtectionLevel:=ProtectionLevel.Sign)> _
        Function Price() As Integer
    End Interface
    '</snippet8>
End Namespace
