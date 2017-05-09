' System.Runtime.Remoting.WellKnownClientTypeEntry

' The following example demonstrates the 'WellKnownClientTypeEntry' class. 
' It registers a 'HttpChannel' object with the channel services. Then registers the 'HelloServer'
' type as well known type with the Remoting Infrastructure at the client end and activates the 
' remote object. It displays the properties of the 'WellKnownClientTypeEntry' object holding the
' values for the above well-known type and makes few method calls on the remote object.

' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class MyClient
   
   Public Shared Sub Main()
      ' Create a 'HttpChannel' object and  register with channel services.
      ChannelServices.RegisterChannel(New HttpChannel())
      Console.WriteLine(" Start calling from Client One.......")
      Dim myWellKnownClientTypeEntry As New WellKnownClientTypeEntry(GetType(HelloServer), _ 
                                                  "http://localhost:8086/SayHello")
      myWellKnownClientTypeEntry.ApplicationUrl = "http://localhost:8086/SayHello"
      RemotingConfiguration.RegisterWellKnownClientType(myWellKnownClientTypeEntry)
      ' Get the proxy object for the remote object.
      Dim myHelloServerObject As New HelloServer()
      ' Retrieve an array of object types registered on the 
      ' client end as well-known types.
      Dim myWellKnownClientTypeEntryCollection As WellKnownClientTypeEntry() = _ 
                                       RemotingConfiguration.GetRegisteredWellKnownClientTypes()
      Console.WriteLine("The Application Url to activate the Remote Object :" + _ 
                                           myWellKnownClientTypeEntryCollection(0).ApplicationUrl)
      Console.WriteLine("The 'WellKnownClientTypeEntry' object :" + _ 
                                              myWellKnownClientTypeEntryCollection(0).ToString())
      ' Make remote method calls.
      Dim i As Integer
      For i = 0 To 4
         Console.WriteLine(myHelloServerObject.HelloMethod(" Client One"))
      Next i
   End Sub 'Main
End Class 'MyClient 
' </Snippet1>