' System.Runtime.Remoting.Channels.IClientChannelSinkProvider.CreateSink()
' System.Runtime.Remoting.Channels.IClientChannelSinkProvider.Next
' System.Runtime.Remoting.Channels.ServerProcessing
' System.Runtime.Remoting.Channels.ServerProcessing.Complete
' System.Runtime.Remoting.Channels.ServerProcessing.OneWay
' System.Runtime.Remoting.Channels.ServerProcessing.Async

' The following program demonstrates the 'CreateSink()' method and 'Next'
' property of 'System.Runtime.Remoting.Channels.IClientChannelSinkProvider' interface.
' This program also demonstrates the 
' 'System.Runtime.Remoting.Channels.ServerProcessing' enum and its 
' members  'Complete','OneWay' and 'Async'.This example defines two classes 
' one for Client logging and other for Server based logging. 
' Client Requests are sent to the server and the same is reflected  
' in terms of Responses on the server end.The incoming message from the 
' client is proccessed and is handled by the 'ServerProcessing'
' enum. The output of the 'ServerProcessing' enum is displayed 
' on the server console.

Imports System
Imports System.Collections
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Metadata
Imports System.Security.Permissions

Namespace MyLogging

' <Snippet1>
' <Snippet2>
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyServerProcessingLogClientChannelSinkProviderData
      Implements IClientChannelSinkProvider

      Private myClientChannelSinkProviderNext As IClientChannelSinkProvider = Nothing

      Public Sub New()
      End Sub 'New

      Public Sub New(ByVal myIDictionaryProperties As IDictionary, ByVal _
                 myICollectionProviderData As ICollection)
      End Sub 'New

      Public Function CreateSink(ByVal myChannelSenderData As IChannelSender, ByVal url As String, _
                 ByVal myRemoteChannelData As Object) As IClientChannelSink Implements _
                 IClientChannelSinkProvider.CreateSink
         Dim myClientChannelSinkNextSink As IClientChannelSink = Nothing
         If Not (myClientChannelSinkProviderNext Is Nothing) Then
            myClientChannelSinkNextSink = myClientChannelSinkProviderNext.CreateSink _
                 (myChannelSenderData, url, myRemoteChannelData)
            If myClientChannelSinkNextSink Is Nothing Then
               Return Nothing
            End If
         End If
         Return New MyLoggingClientChannelSink(myClientChannelSinkNextSink)
      End Function 'CreateSink

      Public Property [Next]() As IClientChannelSinkProvider Implements IClientChannelSinkProvider.Next
         Get
            Return myClientChannelSinkProviderNext
         End Get
         Set(ByVal Value As IClientChannelSinkProvider)
            myClientChannelSinkProviderNext = Value
         End Set
      End Property
   End Class 'MyServerProcessingLogClientChannelSinkProviderData
' </Snippet2>
' </Snippet1>
   
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Friend Class MyLoggingClientChannelSink
      Inherits BaseChannelObjectWithProperties
      Implements IClientChannelSink, ILoggingSink
      Private myNewNextSink As IClientChannelSink = Nothing
      Private myBoolEnabled As Boolean = True
      Private myTextWriterOutput As TextWriter = Console.Out 

      Public Sub New(ByVal myClientChannelSinkNextSink As IClientChannelSink)
         MyBase.New()
         myNewNextSink = myClientChannelSinkNextSink
      End Sub 'New

      Public Sub New(ByVal myChannelSenderData As IChannelSender, ByVal url As String,ByVal _
         myRemoteChannelData As Object, ByVal myClientChannelSinkNextSink As IClientChannelSink)
          MyBase.New()
         myNewNextSink = myClientChannelSinkNextSink
      End Sub 'New

      Public Sub ProcessMessage(ByVal msg As IMessage, ByVal requestHeaders As ITransportHeaders, _
                 ByVal requestStream As Stream, ByRef responseHeaders As ITransportHeaders, _
                 ByRef responseStream As Stream) Implements IClientChannelSink.ProcessMessage
         If myBoolEnabled Then
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, requestStream)
         End If
         myNewNextSink.ProcessMessage(msg, requestHeaders, requestStream, responseHeaders, responseStream)

         If myBoolEnabled  Then
            LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, responseStream)
         End If
      End Sub 'ProcessMessage

      Public Sub AsyncProcessRequest(ByVal myClientChannelSinkStack As IClientChannelSinkStack, _
                ByVal msg As IMessage, ByVal headers As ITransportHeaders, ByVal stream As Stream) _
                 Implements IClientChannelSink.AsyncProcessRequest
      End Sub 'AsyncProcessRequest


      Public Sub AsyncProcessResponse(ByVal myClientChannelSinkStack As IClientResponseChannelSinkStack, _
                ByVal state As Object, ByVal headers As ITransportHeaders, ByVal stream As Stream) _
                 Implements IClientChannelSink.AsyncProcessResponse
      End Sub 'AsyncProcessResponse


      Public Function GetRequestStream(ByVal msg As IMessage, ByVal headers As ITransportHeaders) As _
                Stream Implements IClientChannelSink.GetRequestStream
         Return Nothing
      End Function 'GetRequestStream

      Public ReadOnly Property NextChannelSink() As IClientChannelSink Implements _
                 IClientChannelSink.NextChannelSink
         Get
            Return myNewNextSink
         End Get
      End Property

      Public Property Enabled() As Boolean Implements MyLogging.ILoggingSink.Enabled
         Get
            Return myBoolEnabled
         End Get
         Set(ByVal Value As Boolean)
            myBoolEnabled = Value
         End Set
      End Property

      Public WriteOnly Property Out() As TextWriter Implements MyLogging.ILoggingSink.Out
         Set(ByVal Value As TextWriter)
            myTextWriterOutput = Value
         End Set
      End Property

      Default Public Overrides Property Item(ByVal key As Object) As Object
         Get
            If key Is GetType(LoggingSinkKey) Then
               Return Me
            End If
            Return Nothing
         End Get

         Set(ByVal Value As Object)
            Throw New NotSupportedException()
         End Set
      End Property

      Public Overrides ReadOnly Property Keys() As ICollection
         Get
            Dim myArrayListKeys As New ArrayList(0)
            myArrayListKeys.Add(GetType(LoggingSinkKey))
            Return myArrayListKeys
         End Get
      End Property

      Public Overrides ReadOnly Property Properties() As System.Collections.IDictionary Implements _
                  System.Runtime.Remoting.Channels.IClientChannelSink.Properties
         Get

         End Get
      End Property
   End Class 'MyLoggingClientChannelSink
 
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyServerProcessingLogServerChannelSinkProviderData
      Implements IServerChannelSinkProvider
      Private myServerChannelSinkProviderNext As IServerChannelSinkProvider = Nothing

      Public Sub New()
      End Sub 'New

      Public Sub New(ByVal myIDictionaryProperties As IDictionary, ByVal myICollectionProviderData As _
                 ICollection)
      End Sub 'New

      Public Sub GetChannelData(ByVal channelData As IChannelDataStore) Implements _
                 IServerChannelSinkProvider.GetChannelData
      End Sub 'GetChannelData

      Public Function CreateSink(ByVal myChannelReceiverData As IChannelReceiver) As _
                IServerChannelSink Implements IServerChannelSinkProvider.CreateSink
         Dim myServerChannelSinkNextSink As IServerChannelSink = Nothing
         If Not (myServerChannelSinkProviderNext Is Nothing) Then
            myServerChannelSinkNextSink = myServerChannelSinkProviderNext.CreateSink(myChannelReceiverData)
         End If
         Return New LoggingServerChannelSink(myServerChannelSinkNextSink)
      End Function 'CreateSink

      Public Property [Next]() As IServerChannelSinkProvider Implements IServerChannelSinkProvider.Next
         Get
            Return myServerChannelSinkProviderNext
         End Get
         Set(ByVal Value As IServerChannelSinkProvider)
            myServerChannelSinkProviderNext = Value
         End Set
      End Property
   End Class 'MyServerProcessingLogServerChannelSinkProviderData

   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Friend Class LoggingServerChannelSink
      Inherits BaseChannelObjectWithProperties
      Implements IServerChannelSink, ILoggingSink 
      Private myNewNextSink As IServerChannelSink = Nothing
      Private myBoolEnabled As Boolean = True
      Private myTextWriterOutput As TextWriter = Console.Out

      Public Sub New(ByVal myServerChannelSinkNextSink As IServerChannelSink)
          MyBase.New()
          myNewNextSink = myServerChannelSinkNextSink
      End Sub 'New

      Public Sub New(ByVal myChannelReceiverData As IChannelReceiver, ByVal _
                 myServerChannelSinkNextSink As IServerChannelSink)
         MyBase.New()
         myNewNextSink =  myServerChannelSinkNextSink
      End Sub 'New
' <Snippet3>
      Public Function ProcessMessage(ByVal myServerChannelSinkStack As IServerChannelSinkStack, _
                  ByVal requestMsg As IMessage, ByVal requestHeaders As ITransportHeaders, ByVal requestStream As Stream, ByRef _
                  msg As IMessage, ByRef responseHeaders As ITransportHeaders, ByRef responseStream _
                  As Stream) As ServerProcessing Implements IServerChannelSink.ProcessMessage
         If myBoolEnabled Then
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, requestStream)
         End If
         myServerChannelSinkStack.Push(Me, Nothing)
' <Snippet4>
' <Snippet5>
' <Snippet6>
         Dim myServerProcessing As ServerProcessing = myNewNextSink.ProcessMessage( _
          myServerChannelSinkStack, requestMsg, requestHeaders, requestStream, msg, responseHeaders, responseStream)

         Console.WriteLine("ServerProcessing.Complete value is:   " + ServerProcessing.Complete.Tostring())
         Console.WriteLine("ServerProcessing.OneWay Value is:     " + ServerProcessing.OneWay.Tostring())
         Console.WriteLine("ServerProcessing.Async value is:      " + ServerProcessing.Async.Tostring())

         Select Case myServerProcessing
            Case ServerProcessing.Complete
               myServerChannelSinkStack.Pop(Me)
               If myBoolEnabled Then
                  LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, responseStream)
               End If

            Case ServerProcessing.OneWay
               myServerChannelSinkStack.Pop(Me)

            Case ServerProcessing.Async
               myServerChannelSinkStack.Store(Me, Nothing)

         End Select
         Return myServerProcessing
' </Snippet6>
' </Snippet5>
' </Snippet4>
      End Function 'ProcessMessage

' </Snippet3>
      Public Sub AsyncProcessResponse(ByVal myServerChannelSinkStack As IServerResponseChannelSinkStack, _
        ByVal state As Object, ByVal msg As IMessage, ByVal headers As ITransportHeaders, _
        ByVal stream As Stream) Implements IServerChannelSink.AsyncProcessResponse
      End Sub 'AsyncProcessResponse

      Public Function GetResponseStream(ByVal myServerChannelSinkStack As IServerResponseChannelSinkStack, _
        ByVal state As Object, ByVal msg As IMessage, ByVal headers As ITransportHeaders _
        ) As Stream Implements IServerChannelSink.GetResponseStream
         Return Nothing
      End Function 'GetResponseStream

      Public ReadOnly Property NextChannelSink() As IServerChannelSink Implements _
         IServerChannelSink.NextChannelSink
         Get
            Return myNewNextSink
         End Get
      End Property

      Public Property Enabled() As Boolean Implements MyLogging.ILoggingSink.Enabled
         Get
            Return myBoolEnabled
         End Get
         Set(ByVal Value As Boolean)
            myBoolEnabled = Value
         End Set
      End Property

      Public WriteOnly Property Out() As TextWriter Implements MyLogging.ILoggingSink.Out
         Set(ByVal Value As TextWriter)
            myTextWriterOutput = Value
         End Set
      End Property

      Default Public Overrides Property Item(ByVal key As Object) As Object
         Get
            If key Is GetType(LoggingSinkKey) Then
               Return Me

            Else
               Return Nothing
            End If
         End Get

         Set(ByVal Value As Object)
            Throw New NotSupportedException()
         End Set
      End Property


      Public Overrides ReadOnly Property Keys() As ICollection
         Get
            Dim myArrayListKeys As New ArrayList(0)
            myArrayListKeys.Add(GetType(LoggingSinkKey))
            Return myArrayListKeys
         End Get
      End Property

      Public Overrides ReadOnly Property Properties() As System.Collections.IDictionary Implements _
                System.Runtime.Remoting.Channels.IServerChannelSink.Properties
         Get

         End Get
      End Property
   End Class 'LoggingServerChannelSink

   Friend Class LoggingHelper

      Friend Shared Sub PrintRequest(ByVal output As TextWriter, ByVal requestHeaders As _
                 ITransportHeaders, ByRef requestStream As Stream)
         output.WriteLine("----------Request Headers-----------")
         PrintHeaders(output, requestHeaders)
         ' Print request message.
         Dim contentType As [String] = requestHeaders("Content-Type")
         If Not (contentType Is Nothing) And contentType.StartsWith("text") Then
            output.WriteLine("----------Request Message-----------")
            PrintStream(output, requestStream)
            output.WriteLine("------End of Request Message--------")
         End If
         output.Flush()
      End Sub 'PrintRequest

      Friend Shared Sub PrintResponse(ByVal output As TextWriter, ByVal responseHeaders As _
                ITransportHeaders, ByRef responseStream As Stream)
         output.WriteLine("----------Response Headers ----------")
        PrintHeaders(output, responseHeaders)
         ' Print response message.
         Dim contentType As [String] = responseHeaders("Content-Type")
         If (Not (contentType Is Nothing))  And contentType.StartsWith("text") Then
            output.WriteLine("----------Response Message----------")
            PrintStream(output, responseStream)
            output.WriteLine("------End of Response Message-------")
         End If
         output.Flush()
      End Sub 'PrintResponse

      Private Shared Sub PrintHeaders(ByVal output As TextWriter, ByVal headers As ITransportHeaders)
         Dim header As DictionaryEntry
         For Each header In headers
            output.WriteLine(header.Key + ": " + header.Value.Tostring())
         Next header
      End Sub 'PrintHeaders

      Private Shared Sub PrintStream(ByVal output As TextWriter, ByRef stream As Stream)
         If Not stream.CanSeek Then
            stream = CopyStream(stream)
         End If
         Dim startPosition As Long = stream.Position
         Dim sr As New StreamReader(stream)
         Dim line As String
         line = sr.ReadLine()
         While Not (line Is Nothing)
            output.WriteLine(line)
            line = sr.ReadLine()
         End While
         stream.Position = startPosition
      End Sub 'PrintStream

      Private Shared Function CopyStream(ByVal stream As Stream) As Stream
         Dim streamCopy = New MemoryStream()
         Const bufferSize As Integer = 1024
         Dim buffer(bufferSize) As Byte
         Dim readCount As Integer
         Do
            readCount = stream.Read(buffer, 0, bufferSize)
            If readCount > 0 Then
               streamCopy.Write(buffer, 0, readCount)
            End If
         Loop While readCount > 0
         ' Close original stream.
         stream.Close()
         streamCopy.Position = 0
         Return streamCopy
      End Function 'CopyStream
   End Class 'LoggingHelper

   Public Interface ILoggingSink

      Property Enabled() As Boolean
      WriteOnly Property Out() As TextWriter
   End Interface 'ILoggingSink

   ' This class is used as the key to get the ILoggingSink interface
   ' to one of the logging sinks.
   Public Class LoggingSinkKey
   End Class 'LoggingSinkKey

End Namespace 'MyLogging