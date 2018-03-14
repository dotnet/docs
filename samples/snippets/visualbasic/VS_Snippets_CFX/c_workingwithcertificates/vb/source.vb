Imports System
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Security.Cryptography.X509Certificates

Class Program
    Shared Sub Main()

        '<snippet1>
        Dim baseAddress As New Uri("http://cohowinery.com/services")
        Dim sh As New ServiceHost(GetType(CalculatorService), baseAddress)
        sh.Credentials.ServiceCertificate.SetCertificate( _
        StoreLocation.LocalMachine, StoreName.My, _
        X509FindType.FindBySubjectName, "cohowinery.com")
        '</snippet1>
    End Sub
End Class


<ServiceContract()> Public Interface ICalculator

    <OperationContract()> Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
End Interface


Public Class CalculatorService
    Implements ICalculator

    Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICalculator.Add

        Return a + b
    End Function

End Class


