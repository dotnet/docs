' System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.CreateSink

Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class MyClientProvider
    Implements IClientChannelSinkProvider
    Private nextProvider As IClientChannelSinkProvider = Nothing

    Public Sub New()
    End Sub 'New

    Public Sub New(ByVal properties As IDictionary, ByVal providerData As ICollection)
    End Sub 'New

    Public Function CreateSink(ByVal channel As IChannelSender, ByVal myUrl As String, _
               ByVal remoteChannelData As Object) As IClientChannelSink Implements _
                                              IClientChannelSinkProvider.CreateSink
        Dim nextSink As IClientChannelSink = Nothing
        If Not (nextProvider Is Nothing) Then
            nextSink = nextProvider.CreateSink(channel, myUrl, remoteChannelData)
            If nextSink Is Nothing Then
                Return Nothing
            End If
        End If
        Return New MyClientChannelSink(nextSink)
    End Function 'CreateSink

    Public Property [Next]() As IClientChannelSinkProvider Implements IClientChannelSinkProvider.Next
        Get
            Return nextProvider
        End Get
        Set(ByVal Value As IClientChannelSinkProvider)
            nextProvider = Value
        End Set
    End Property
End Class 'MyClientProvider

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Friend Class MyClientChannelSink
    Inherits BaseChannelObjectWithProperties
    Implements IClientChannelSink
    Private nextClientSink As IClientChannelSink = Nothing

    Public Sub New(ByVal nextSink As IClientChannelSink)
      MyBase.New()
        nextClientSink = nextSink
    End Sub 'New

    Public Sub New(ByVal channel As IChannelSender, ByVal url As String, ByVal remoteChannelData As _
                                                   Object, ByVal nextSink As IClientChannelSink)
        MyBase.New()
        nextClientSink = nextSink
    End Sub 'New

    Public Sub ProcessMessage(ByVal msg As IMessage, ByVal requestHeaders As ITransportHeaders, _
                     ByVal requestStream As Stream, ByRef responseHeaders As ITransportHeaders, _
                      ByRef responseStream As Stream) Implements IClientChannelSink.ProcessMessage
        nextClientSink.ProcessMessage(msg, requestHeaders, requestStream, responseHeaders, _
                                                                           responseStream)
    End Sub 'ProcessMessage

    Public Sub AsyncProcessRequest(ByVal sinkStack As IClientChannelSinkStack, ByVal msg As IMessage, _
                                    ByVal headers As ITransportHeaders, ByVal stream As Stream) _
                                    Implements IClientChannelSink.AsyncProcessRequest
        sinkStack.Push(Me, Nothing)
        nextClientSink.AsyncProcessRequest(sinkStack, msg, headers, stream)
    End Sub 'AsyncProcessRequest

    Public Sub AsyncProcessResponse(ByVal sinkStack As IClientResponseChannelSinkStack, _
               ByVal state As Object, ByVal headers As ITransportHeaders, ByVal stream As Stream) _
                  Implements IClientChannelSink.AsyncProcessResponse
        sinkStack.AsyncProcessResponse(headers, stream)
    End Sub 'AsyncProcessResponse

    Public Function GetRequestStream(ByVal msg As IMessage, ByVal headers As ITransportHeaders) As _
                                             Stream Implements IClientChannelSink.GetRequestStream
        Return Nothing
    End Function 'GetRequestStream

    Public ReadOnly Property NextChannelSink() As IClientChannelSink Implements _
                                                         IClientChannelSink.NextChannelSink
        Get
            Return nextClientSink
        End Get
    End Property

    Default Public Overrides Property Item(ByVal key As Object) As Object
        Get
            If key Is GetType(MyKey) Then
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
            Dim myKeys As New ArrayList(0)
            myKeys.Add(GetType(MyKey))
            Return myKeys
        End Get
    End Property

    Public Overrides ReadOnly Property Properties() As System.Collections.IDictionary Implements _
                                                                  IClientChannelSink.Properties
        Get

        End Get
    End Property
End Class 'MyClientChannelSink

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class MyServerProvider
    Implements IServerChannelSinkProvider 
    Private nextProvider As IServerChannelSinkProvider = Nothing

    Public Sub New()
    End Sub 'New

    Public Sub New(ByVal properties As IDictionary, ByVal providerData As ICollection)
    End Sub 'New

    Public Sub GetChannelData(ByVal channelData As IChannelDataStore) Implements _
                                                IServerChannelSinkProvider.GetChannelData
    End Sub 'GetChannelData

    Public Function CreateSink(ByVal channel As IChannelReceiver) As IServerChannelSink Implements _
                                                            IServerChannelSinkProvider.CreateSink
' <Snippet3>
        Dim nextSink As IServerChannelSink = Nothing
        If Not (nextProvider Is Nothing) Then
            Console.WriteLine("The next server provider is:" + CType(nextProvider,Object).ToString())
            ' Create a sink chain calling the 'SaopServerFormatterProvider'
            ' 'CreateSink' method.
            nextSink = nextProvider.CreateSink(channel)
        End If
        Return New MyServerChannelSink(nextSink)
' </Snippet3>
    End Function 'CreateSink 

    Public Property [Next]() As IServerChannelSinkProvider Implements IServerChannelSinkProvider.Next
        Get
            Return nextProvider
        End Get
        Set(ByVal Value As IServerChannelSinkProvider)
            nextProvider = Value
        End Set
    End Property
End Class 'MyServerProvider

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Friend Class MyServerChannelSink
    Inherits BaseChannelObjectWithProperties
    Implements IServerChannelSink 
    Private nextServerSink As IServerChannelSink = Nothing

    Public Sub New(ByVal nextSink As IServerChannelSink)
        MyBase.New()
        nextServerSink = nextSink
    End Sub 'New

    Public Sub New(ByVal channel As IChannelReceiver, ByVal nextSink As IServerChannelSink)
        MyBase.New()
        nextServerSink = nextSink
    End Sub 'New


    Public Function ProcessMessage(ByVal sinkStack As IServerChannelSinkStack, ByVal requestMsg As IMessage , _
        ByVal requestHeaders As ITransportHeaders, ByVal requestStream As Stream, ByRef msg As IMessage, ByRef _
         responseHeaders As ITransportHeaders, ByRef responseStream As Stream) As ServerProcessing _
                                       Implements IServerChannelSink.ProcessMessage
        sinkStack.Push(Me, Nothing)
        Dim processing As ServerProcessing = nextServerSink.ProcessMessage(sinkStack, requestMsg , requestHeaders, _
            requestStream, msg, responseHeaders, responseStream)

        Select Case processing

            Case ServerProcessing.Complete
                sinkStack.Pop(Me)

            Case ServerProcessing.OneWay
                sinkStack.Pop(Me)

            Case ServerProcessing.Async
                sinkStack.Store(Me, Nothing)
        End Select
        Return processing
    End Function 'ProcessMessage


    Public Sub AsyncProcessResponse(ByVal sinkStack As IServerResponseChannelSinkStack, _
         ByVal state As Object, ByVal msg As IMessage, ByVal headers As ITransportHeaders, ByVal _
                           stream As Stream) Implements IServerChannelSink.AsyncProcessResponse
        sinkStack.AsyncProcessResponse(msg, headers, stream)
    End Sub 'AsyncProcessResponse

    Public Function GetResponseStream(ByVal sinkStack As IServerResponseChannelSinkStack, ByVal state _
            As Object, ByVal msg As IMessage, ByVal headers As ITransportHeaders) As Stream _
                                             Implements IServerChannelSink.GetResponseStream
        Return Nothing
    End Function 'GetResponseStream

    Public ReadOnly Property NextChannelSink() As IServerChannelSink Implements _
                                                   IServerChannelSink.NextChannelSink
        Get
            Return nextServerSink
        End Get
    End Property

    Default Public Overrides Property Item(ByVal key As Object) As Object
        Get
            If key Is GetType(MyKey) Then
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
            Dim myKeys As New ArrayList(1)
            myKeys.Add(GetType(MyKey))
            Return myKeys
        End Get
    End Property

    Public Overrides ReadOnly Property Properties() As System.Collections.IDictionary _
                                                Implements IServerChannelSink.Properties
        Get

        End Get
    End Property
End Class 'MyServerChannelSink

Public Class MyKey
End Class 'MyKey