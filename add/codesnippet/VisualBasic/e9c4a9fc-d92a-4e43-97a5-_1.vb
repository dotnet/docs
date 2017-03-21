Public Class HelloServer
    Inherits MarshalByRefObject

    Shared Sub New()
        Console.WriteLine("HelloServer activated.")
    End Sub

    <OneWay()> Public Sub SayHelloToServer(ByVal name As String)
        Console.WriteLine("Client invoked SayHelloToServer(""{0}"").", name)
    End Sub

    'IsOneWay
    ' Note the lack of the OneWayAttribute adornment on this method.
<SecurityPermission(SecurityAction.Demand)> _
    Public Function SayHelloToServerAndWait(ByVal name As String) As String
        Console.WriteLine("Client invoked SayHelloToServerAndWait(""{0}"").", name)

        Console.WriteLine( _
            "Client waiting for return? {0}", _
            IIf(RemotingServices.IsOneWay(MethodBase.GetCurrentMethod()), "No", "Yes") _
        )

        Return "Hi there, " + name + "."
    End Function

End Class