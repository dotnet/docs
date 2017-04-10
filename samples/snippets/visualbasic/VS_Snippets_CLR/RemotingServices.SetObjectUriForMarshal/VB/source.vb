' <Snippet1>
Imports System.Runtime.Remoting
Imports System.Security.Permissions


Public Class SetObjectUriForMarshalTest
    
    Class TestClass
        Inherits MarshalByRefObject
    End Class

    <SecurityPermission(SecurityAction.Demand, Flags:= SecurityPermissionFlag.RemotingConfiguration )> _
    Public Shared Sub Main()
        Dim obj As TestClass = New TestClass()

        RemotingServices.SetObjectUriForMarshal(obj, "testUri")
        RemotingServices.Marshal(obj)

        Console.WriteLine(RemotingServices.GetObjectUri(obj))
    End Sub

End Class
' </Snippet1>
