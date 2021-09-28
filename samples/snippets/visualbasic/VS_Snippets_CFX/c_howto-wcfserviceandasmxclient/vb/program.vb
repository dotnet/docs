' <snippet0>

Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Description

<ServiceContract()> _
Public Interface IEcho

    <OperationContract()> _
    Function Echo(ByVal s As String) As String

End Interface

Public Class MyService
    Implements IEcho

    Public Function Echo(ByVal s As String) As String Implements IEcho.Echo
        Return s
    End Function

End Class

Friend Class Program

    Shared Sub Main(ByVal args() As String)
        Dim baseAddress = "http://localhost:8080/wcfselfhost/"
        Dim host As New ServiceHost(GetType(MyService), _
                                    New Uri(baseAddress))

        ' Add a service endpoint using the created binding
        With host
            .AddServiceEndpoint(GetType(IEcho), _
                                New BasicHttpBinding(), _
                                "echo1")
            .Open()
            Console.WriteLine("Service listening on {0} . . .", _
                              baseAddress)
            Console.ReadLine()
            .Close()
        End With
    End Sub
End Class
' </snippet0>

