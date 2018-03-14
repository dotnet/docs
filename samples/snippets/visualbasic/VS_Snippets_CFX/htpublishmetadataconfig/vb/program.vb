'<Snippet0>
Imports System
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


Module Program

    Sub Main()
        Dim host As New ServiceHost(GetType(SimpleService))
        Try
            'Open the service host to accept incoming calls
            host.Open()

            'The service can now be accessed.
            Console.WriteLine("The service is ready.")
            Console.WriteLine("Press <ENTER> to terminate service.")
            Console.WriteLine()
            Console.ReadLine()

            'Close the ServiceHostBase to shutdown the service.
            host.Close()
        Catch commProblem As CommunicationException
            Console.WriteLine("There was a communication problem. " + commProblem.Message)
            Console.Read()
        End Try
    End Sub

End Module

