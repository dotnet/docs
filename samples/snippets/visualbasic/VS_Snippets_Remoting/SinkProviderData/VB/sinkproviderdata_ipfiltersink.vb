' System.Runtime.Remoting.Channels.SinkProviderData
' System.Runtime.Remoting.Channels.SinkProviderData.Children
' System.Runtime.Remoting.Channels.SinkProviderData.Name
' System.Runtime.Remoting.Channels.SinkProviderData.Properties

' The following program demonstrates the SinkProviderData class and its properties
' 'Children', 'Name', 'Properties'.The IP filter sink may be set up to be in accept
' or reject mode. In accept mode, the sink will only accept requests from ip addresses
' that matches one of the filters. In reject mode, the sink will reject requests from
' any ip address that matches one of the filters. The properties of the SinkProviderData
' class are added to an ArrayList and their outputs are displayed onto the console.
'

Imports System
Imports System.IO
Imports System.Collections
Imports System.Net
Imports System.Reflection
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions
Imports Microsoft.VisualBasic

Namespace IPFilter
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>

   Public Class MySinkProviderData
      Implements IServerChannelSinkProvider
      Private myIServerChannelSinkProviderNew As IServerChannelSinkProvider

      Private myAcceptMode As Boolean = True
      Private myCollectionData As ICollection = Nothing

      Public Sub New()
      End Sub 'New

      Public Sub New(properties As IDictionary, providerData As ICollection)
         Dim myMode As String = CType(properties("mode"), String)
         If String.Compare(myMode, "accept", True) = 0 Then
            myAcceptMode = True
         Else
            If String.Compare(myMode, "reject", True) = 0 Then
               myAcceptMode = False
            End If
         End If
         myCollectionData = providerData
      End Sub 'New

<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Sub GetChannelData(myLocalChannelData As IChannelDataStore) Implements _
                                       IServerChannelSinkProvider.GetChannelData
      End Sub 'GetChannelData

<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Function CreateSink(myChannel As IChannelReceiver) As IServerChannelSink Implements _
                                                         IServerChannelSinkProvider.CreateSink
         Dim myIServerChannelSink_nextSink As IServerChannelSink = Nothing
         If Not (myIServerChannelSinkProviderNew Is Nothing) Then
            myIServerChannelSink_nextSink = myIServerChannelSinkProviderNew.CreateSink(myChannel)
         End If
         Dim mySink As New MyIPFilterChannelSink(myAcceptMode, myIServerChannelSink_nextSink)
         ' Create and initialize a new ArrayList.
         Dim myArrayList As New ArrayList()

         ' Add filters.
         Dim mySinkData As SinkProviderData
         For Each mySinkData In  myCollectionData
            ' The SinkProviderData properties are added to the ArrayList.
            myArrayList.Add(mySinkData.Children)
            myArrayList.Add(mySinkData.Name)

            Dim myMaskString As String = CType(mySinkData.Properties("mask"), String)
            Dim myIPString As String = CType(mySinkData.Properties("ip"), String)
            Dim myMachineString As String = CType(mySinkData.Properties("machine"), String)

            Dim mask As IPAddress = Nothing
            Dim ip As IPAddress = Nothing

            If Not (myIPString Is Nothing) Then
               mask = IPAddress.Parse(myMaskString)
               ip = IPAddress.Parse(myIPString)
            Else
               mask = IPAddress.Parse("255.255.255.255")
               ip = Dns.Resolve(myMachineString).AddressList(0)
            End If

            mySink.AddFilter(mask, ip)
         Next mySinkData
         Console.WriteLine("The Count of the ArrayList is  :" + myArrayList.Count.ToString())
         Console.WriteLine("The values in the SinkProviderData collection are:")

         ' Call the PrintValues function to enumerate and print values to the console.
         PrintValues(myArrayList)

         Return mySink
      End Function 'CreateSink

      Public Property [Next]() As IServerChannelSinkProvider Implements _
                                                            IServerChannelSinkProvider.Next
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
         Get
            Return myIServerChannelSinkProviderNew
         End Get
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
         Set
            myIServerChannelSinkProviderNew = value
         End Set
      End Property

      Public Property Mode() As FilterMode
         Get
            Return(IIf(myAcceptMode ,FilterMode.Accept ,FilterMode.Reject))
         End Get
         Set(ByVal Value As FilterMode)
             If Value = FilterMode.Accept Then
                 myAcceptMode = Value
             End If
         End Set
      End Property

      Public Shared Sub PrintValues(myList As IEnumerable)
         Dim myEnumerator As IEnumerator = myList.GetEnumerator()
         While myEnumerator.MoveNext()
            Console.Write(ControlChars.Tab + "{0}", myEnumerator.Current)
         End While
         Console.WriteLine()
      End Sub 'PrintValues
   End Class 'MySinkProviderData
     ' class MySinkProviderData
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
   Public Class MyIPFilterChannelSink
      Inherits BaseChannelSinkWithProperties
      Implements IServerChannelSink
      Private myIServerChannelSink_newSink As IServerChannelSink

        Overrides ReadOnly Property Properties() As Collections.IDictionary Implements _
                                                         IServerChannelSink.Properties
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
            Get

            End Get
        End Property

      Private myBool_Accept As Boolean
      ' List of filters to filter with.
      Private myFilterSet As ArrayList

      Private Class MyFilter
         Implements IFilter
         Private myNewMask As Integer
         Private myNewIPAddress As Integer

         Private myMaskObject As IPAddress
         Private myIPAddressObject As IPAddress


         Public Sub New(mask As IPAddress, ipAddress1 As IPAddress)
            myBase.New()
            myMaskObject = mask
            myIPAddressObject = ipAddress1

            myNewMask = mask.Address
            myNewIPAddress = ipAddress1.Address

            If(Not myNewMask And myNewIPAddress) <> 0 Then
               Throw New Exception("Unable to create filter: IP address " + _
               "(" + ipAddress1.ToString() + ") cannot be more specific than mask " + _
                                                      "(" + mask.ToString() + ")")
            End If
         End Sub 'New

         Public Function MatchIPAddress(ipToMatch As Integer) As Boolean
            Return(myNewMask And ipToMatch) = myNewIPAddress
         End Function 'MatchIPAddress ' MatchIPAddress

         Public ReadOnly Property Mask() As IPAddress Implements IFilter.Mask
            Get
               Return myMaskObject
            End Get
         End Property

         Public ReadOnly Property IP() As IPAddress Implements IFilter.IP
            Get
               Return myIPAddressObject
            End Get
         End Property
      End Class 'MyFilter

<SecurityPermission(SecurityAction.Demand)> _
      Public Sub New(myAcceptMode As Boolean, myIServerChannelSink_nextSink As IServerChannelSink)
         myFilterSet = New ArrayList()
         myIServerChannelSink_newSink = myIServerChannelSink_nextSink

         myBool_Accept = myAcceptMode
      End Sub 'New
       ' MyIPFilterChannelSink

      Public Sub AddFilter(mask As IPAddress, ipAddress1 As IPAddress)
         Dim f As New MyFilter(mask, ipAddress1)
         myFilterSet.Add(f)
      End Sub 'AddFilter

<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Function ProcessMessage(sinkStack As IServerChannelSinkStack, requestMsg As _
        IMessage, requestHeaders As ITransportHeaders, requestStream As _
        IO.Stream, ByRef responseMsg As IMessage, ByRef responseHeaders As _
        ITransportHeaders, ByRef responseStream As IO.Stream) As ServerProcessing _
        Implements IServerChannelSink.ProcessMessage

         Dim ipAddress1 As IPAddress = _
                                 CType(requestHeaders(CommonTransportKeys.IPAddress), IPAddress)
         Console.WriteLine(ipAddress1)

         Dim accept As Boolean = Not MatchIPAddress(ipAddress1) ^ myBool_Accept

         If accept Then
            Return myIServerChannelSink_newSink.ProcessMessage(sinkStack, requestMsg, requestHeaders, _
                                             requestStream, responseMsg, responseHeaders, responseStream)
         Else
            responseHeaders = New TransportHeaders()
            responseHeaders("__HttpStatusCode") = "403"
            responseHeaders("__HttpReasonPhrase") = "Forbidden"
            Console.WriteLine("Reject.")

            responseMsg = Nothing
            responseStream = Nothing

            Return ServerProcessing.Complete
         End If
      End Function 'ProcessMessage
       ' ProcessMessage

<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Sub AsyncProcessResponse(sinkStack As IServerResponseChannelSinkStack, state As _
                           Object, msg As IMessage, headers As ITransportHeaders, stream As Stream) _
                                                Implements IServerChannelSink.AsyncProcessResponse
      End Sub 'AsyncProcessResponse

      ' AsyncProcessResponse

<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Function GetResponseStream(sinkStack As IServerResponseChannelSinkStack, state As _
                                 Object, msg As IMessage, headers As ITransportHeaders) As Stream _
                                 Implements IServerChannelSink.GetResponseStream
         Return Nothing
      End Function 'GetResponseStream ' GetResponseStream

      Public ReadOnly Property NextChannelSink() As IServerChannelSink _
                                    Implements IServerChannelSink.NextChannelSink
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
         Get
            Return myIServerChannelSink_newSink
         End Get
      End Property

      ' Match ip address against all filters in the filter set.
      Private Function MatchIPAddress(ipAddr As IPAddress) As Boolean
         Dim ip As Integer = ipAddr.Address

         Dim f As MyFilter
         For Each f In  myFilterSet
            If f.MatchIPAddress(ip) Then
               Return True
            End If
         Next f
         Return False
      End Function 'MatchIPAddress ' MatchIPAddress

      Public ReadOnly Property Mode() As FilterMode
         Get
            Return(IIf(myBool_Accept, FilterMode.Accept, FilterMode.Reject))
         End Get
      End Property

      Public ReadOnly Property Filters() As ICollection
         Get
            Return myFilterSet
         End Get
      End Property
   End Class 'MyIPFilterChannelSink
   ' class MyIPFilterChannelSink
   Public Enum FilterMode
      Accept
      Reject
   End Enum 'FilterMode

   Public Interface IFilter
      ReadOnly Property Mask() As IPAddress
      ReadOnly Property IP() As IPAddress
   End Interface 'IFilter
End Namespace 'IPFilter ' namespace IPFilter