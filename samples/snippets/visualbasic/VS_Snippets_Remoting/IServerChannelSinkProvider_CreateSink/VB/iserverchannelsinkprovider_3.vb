' System.Runtime.Remoting.Channels.IServerChannelSinkProvider.CreateSink()
' System.Runtime.Remoting.Channels.IServerChannelSinkProvider.GetChannelData()
' System.Runtime.Remoting.Channels.IServerChannelSinkProvider.Next

' The following program demonstrates 'CreateSink', 'GetChannelData' 
' methods and 'Next' property of 
' 'System.Runtime.Remoting.Channels.ServerChannelSinkStack' class.
' It chains together two different sink providers using the 'Next'
' property. The return value of 'GetChannelData()' is displayed on
' the console.

Imports System
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Class MyServerChannelSinkStack
   Private myIServerChannelSinkProvider As IServerChannelSinkProvider
   Private myIServerChannelSinkProvider1 As IServerChannelSinkProvider
   Private myIServerChannelSink As IServerChannelSink
   Private myIServerChannelSink1 As IServerChannelSink
   
   Shared Sub Main()
      Dim myNewServerChannelSinkStack As New MyServerChannelSinkStack()
      myNewServerChannelSinkStack.MyCreateSinkMethod()
      myNewServerChannelSinkStack.MyGetChannelDataMethod()
   End Sub 'Main
   
   Public Sub MyCreateSinkMethod()
      Console.Write("Press Enter to set sink providers and create sinks")
      Console.ReadLine()
' <Snippet1>
' <Snippet3>
      ' Create the sink providers.
      myIServerChannelSinkProvider = New SoapServerFormatterSinkProvider()
      myIServerChannelSinkProvider1 = New BinaryServerFormatterSinkProvider()
      ' Create the channel sinks.
      myIServerChannelSink = myIServerChannelSinkProvider.CreateSink(New HttpChannel())
      myIServerChannelSinkProvider.Next = myIServerChannelSinkProvider1

      myIServerChannelSink1 = myIServerChannelSinkProvider.Next.CreateSink(New HttpChannel())
' </Snippet3>
' </Snippet1>
      Console.WriteLine("Two sink providers have been set")
   End Sub 'MyCreateSinkMethod
   
   Public Sub MyGetChannelDataMethod()
' <Snippet2>
      Dim channelUri() As String = New String(4) {}
      Dim myIChannelDataStore = New ChannelDataStore(channelUri)
      Dim myIChannelDataStore1 = New ChannelDataStore(channelUri)
      myIServerChannelSinkProvider.GetChannelData(myIChannelDataStore)
      myIServerChannelSinkProvider1.GetChannelData(myIChannelDataStore1)
' </Snippet2>
      Console.WriteLine("Number of Uris in first IChannelDataStore: " + _ 
                                                myIChannelDataStore.ChannelUris.Length.ToString())
      Console.WriteLine("Number of Uris in second IChannelDataStore: " + _ 
                                               myIChannelDataStore1.ChannelUris.Length.ToString())
   End Sub 'MyGetChannelDataMethod
End Class 'MyServerChannelSinkStack