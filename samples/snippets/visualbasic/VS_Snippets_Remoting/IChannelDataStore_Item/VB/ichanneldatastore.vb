' System.Runtime.Remoting.Channels.IChannelDataStore
' System.Runtime.Remoting.Channels.IChannelDataStore.ChannelUris
' System.Runtime.Remoting.Channels.IChannelDataStore.Item[object]

' The following example demonstrates 'ChannelUris', 'Item' and 'IChannelDataStore'
' class.
' In the example after registering the channel, the object is registered with remoting
' infrastructure by calling 'RemotingServices.Marshal' method. After registering the
' object the channel information is obtained. From the channel information the required
' 'IChannelInfo' is collected and displayed.
'


' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Services
Imports System.Security.Permissions

Public Class ServerProcess
   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
' <Snippet2>
' <Snippet3>
      Dim myChannel As New TcpChannel(8085)
      ChannelServices.RegisterChannel(myChannel)

      Dim myService As New MyServiceClass()

      ' After the channel is registered, register the object
      ' with remoting infrastructure by calling Marshal method.
      Dim myObjRef As ObjRef = RemotingServices.Marshal(myService, "TcpService")

      ' Get the information contributed by active channel.
      Dim myChannelInfo As IChannelInfo = myObjRef.ChannelInfo
      Dim myIChannelData As IChannelDataStore
      Dim myChannelData As Object
      For Each myChannelData In  myChannelInfo.ChannelData
         If TypeOf myChannelData Is IChannelDataStore Then
            myIChannelData = CType(myChannelData, IChannelDataStore)
            Dim myUri As String
            For Each myUri In  myIChannelData.ChannelUris
               Console.WriteLine("Channel Uris are -> " + myUri)
            Next myUri ' Add custom data.
            Dim myKey As String = "Key1"
            myIChannelData(myKey) = "My Data"
            Console.WriteLine(myIChannelData(myKey).ToString())
         End If
      Next myChannelData
' </Snippet2>
' </Snippet3>
   End Sub 'Main
End Class 'ServerProcess

' Marshal ByRef Object class.
Public Class MyServiceClass
   Inherits MarshalByRefObject

   Public Function HelloWorld() As String
      Return "Hello World"
   End Function 'HelloWorld
End Class 'MyServiceClass
' </Snippet1>