Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Microsoft.VisualBasic


' code that drives the example
Public Class ObjRefExample

   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Overloads Shared Sub Main()
      ChannelServices.RegisterChannel(New HttpChannel(8090))

      RemotingConfiguration.RegisterWellKnownServiceType(New WellKnownServiceTypeEntry(GetType(RemoteObject), "RemoteObject", WellKnownObjectMode.Singleton))

      Dim RObj As RemoteObject = CType(Activator.GetObject(GetType(RemoteObject), "http://localhost:8090/RemoteObject"), RemoteObject)
      Dim LObj As New LocalObject()

      RObj.Method1(LObj)

      Console.WriteLine("Press Return to exit...")

      Console.ReadLine()
   End Sub

End Class


' a simple remote object
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class RemoteObject
   Inherits MarshalByRefObject

   Public Sub Method1(ByVal param As LocalObject)
       Console.WriteLine("Invoked: Method1({0})", param)
   End Sub

End Class