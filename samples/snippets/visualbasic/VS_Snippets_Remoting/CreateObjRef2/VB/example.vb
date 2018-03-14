' <Snippet2>
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
' </Snippet2>


' <Snippet1>
' a custom ObjRef class that outputs its status
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class MyObjRef
   Inherits ObjRef

   ' only instantiate using marshaling or deserialization
   Private Sub New()
   End Sub

   Public Sub New(ByVal o As MarshalByRefObject, ByVal t As Type)
      MyBase.New(o, t)
      Console.WriteLine("Created MyObjRef.")
      ORDump()
   End Sub

   Public Sub New(ByVal i As SerializationInfo, ByVal c As StreamingContext)
      MyBase.New(i, c)
      Console.WriteLine("Deserialized MyObjRef.")
   End Sub

   Public Overrides Sub GetObjectData(ByVal s As SerializationInfo, ByVal c As StreamingContext)
      ' After calling the base method, change the type from ObjRef to MyObjRef
      MyBase.GetObjectData(s, c)
      s.SetType([GetType]())
      Console.WriteLine("Serialized MyObjRef.")
   End Sub

   Public Overrides Function GetRealObject(ByVal context As StreamingContext) As [Object]
      If IsFromThisAppDomain() Or IsFromThisProcess() Then
         Console.WriteLine("Returning actual object referenced by MyObjRef.")
         Return MyBase.GetRealObject(context)
      Else
         Console.WriteLine("Returning proxy to remote object.")
         Return RemotingServices.Unmarshal(Me)
      End If
   End Function

   Public Sub ORDump()
      Console.WriteLine(" --- Reporting MyObjRef Info --- ")
      Console.WriteLine("Reference to {0}.", TypeInfo.TypeName)
      Console.WriteLine("URI is {0}.", URI)

      Console.WriteLine(ControlChars.Cr + "Writing EnvoyInfo: ")
      If Not (EnvoyInfo Is Nothing) Then
         Dim EISinks As IMessageSink = EnvoyInfo.EnvoySinks
         Dim count As Integer = 0
         While Not (EISinks Is Nothing)
            Console.WriteLine(ControlChars.Tab + "Interated through sink #{0}", (count = count + 1))
            EISinks = EISinks.NextSink
         End While
      Else
         Console.WriteLine(ControlChars.Tab + " {no sinks}")
      End If
      Console.WriteLine(ControlChars.Cr + "Writing ChannelInfo: ")
      Dim i As Integer
      For i = 0 To ChannelInfo.ChannelData.Length - 1
         Console.WriteLine(ControlChars.Tab + "Channel: {0}", ChannelInfo.ChannelData(i))
      Next i
      Console.WriteLine(" ----------------------------- ")
   End Sub
   
End Class


' a class that uses MyObjRef
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class LocalObject
   Inherits MarshalByRefObject

   ' overriding CreateObjRef will allow us to return a custom ObjRef
   Public Overrides Function CreateObjRef(ByVal t As Type) As ObjRef
      Return New MyObjRef(Me, t)
   End Function

End Class
' </Snippet1>
