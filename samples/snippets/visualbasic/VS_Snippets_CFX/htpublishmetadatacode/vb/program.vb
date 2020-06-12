'<Snippet11>
'<Snippet0>
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Description

<ServiceContract()> _
Public Interface ISimpleService
    <OperationContract()> _
    Function SimpleMethod(ByVal msg As String) As String
End Interface

Class SimpleService
    Implements ISimpleService

    Public Function SimpleMethod(ByVal msg As String) As String Implements ISimpleService.SimpleMethod
        Console.WriteLine("The caller passed in " + msg)
        Return "Hello " + msg
    End Function
End Class
'</Snippet0>

Module Module1

    Sub Main()
        '<Snippet1>
        Dim svcHost As New ServiceHost(GetType(SimpleService), New Uri("http://localhost:8001/MetadataSample"))
        '</Snippet1>
        '<Snippet2>
        Try
            '</Snippet2>
            '<Snippet4>
            'Check to see if the service host already has a ServiceMetadataBehavior
            Dim smb As ServiceMetadataBehavior = svcHost.Description.Behaviors.Find(Of ServiceMetadataBehavior)()
            'If not, add one
            If (smb Is Nothing) Then
                smb = New ServiceMetadataBehavior()
            End If
            '</Snippet4>
            '<Snippet5>
            smb.HttpGetEnabled = True
            '</Snippet5>
            '<Snippet6>
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15
            '</Snippet6>
            '<Snippet7>
            svcHost.Description.Behaviors.Add(smb)
            '</Snippet7>
            '<Snippet8>
            'Add MEX endpoint
            svcHost.AddServiceEndpoint( _
                  ServiceMetadataBehavior.MexContractName, _
                  MetadataExchangeBindings.CreateMexHttpBinding(), _
                  "mex")
            '</Snippet8>
            '<Snippet9>
            'Add application endpoint
            svcHost.AddServiceEndpoint(GetType(ISimpleService), New WSHttpBinding(), "")
            '</Snippet9>
            '<Snippet10>
            'Open the service host to accept incoming calls
            svcHost.Open()

            'The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            'Close the ServiceHostBase to shutdown the service.
            svcHost.Close()
            '</Snippet10>
            '<Snippet3>
        Catch commProblem As CommunicationException

            Console.WriteLine("There was a communication problem. " + commProblem.Message)
            Console.Read()
        End Try
        '</Snippet3>
    End Sub
End Module
'</Snippet11>
