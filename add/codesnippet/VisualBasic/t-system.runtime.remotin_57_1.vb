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