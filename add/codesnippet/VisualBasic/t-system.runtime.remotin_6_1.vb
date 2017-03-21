   Class MyCustomChannel
         Implements IChannelReceiver 
         Private myChannelData As ChannelDataStore
         Private myChannelPriority As Integer = 25
         ' Set the 'ChannelName' to 'MyCustomChannel'.
         Private myChanneName As String = "tcp"
         ' Implement 'ChannelName' property.
         Private myTcpListener As TcpListener
         Private myPortNo As Integer
         Private myListening As Boolean = False
         Private myThread As Thread

         Public Sub New(ByVal portNo As Integer)
            myPortNo = portNo
         Dim myURI(0) As String
         myURI(0) = Dns.Resolve(Dns.GetHostName()).AddressList(0).ToString() + ":" + _
                                                                     portNo.ToString()
         ' Store the 'URI' in 'myChannelDataStore'.
         myChannelData = New ChannelDataStore(myURI)
         ' Create 'myTcpListener' to listen at the 'myPortNo' port.
         myTcpListener = New TcpListener(myPortNo)
         ' Create the thread 'myThread'.
         myThread = New Thread(New ThreadStart(AddressOf myTcpListener.Start))
         Me.StartListening(Nothing)
         End Sub 'New

         Public ReadOnly Property ChannelName() As String Implements IChannelReceiver.ChannelName
         Get
            Return myChanneName
         End Get
         End Property

         Public ReadOnly Property ChannelPriority() As Integer _
                                             Implements IChannelReceiver.ChannelPriority
         Get
            Return myChannelPriority
         End Get
         End Property

         Public Function Parse(ByVal myUrl As String, ByRef objectURI As String) As String _
                                                         Implements IChannelReceiver.Parse
         Dim myRegex As New Regex("/", RegexOptions.RightToLeft)
         ' Check for '/' in 'myUrl' from Right to left.
         Dim myMatch As Match = myRegex.Match(myUrl)
         ' Get the object URI.
         objectURI = myUrl.Substring(myMatch.Index)
         ' Return the channel url.
         Return myUrl.Substring(0, myMatch.Index)
         End Function 'Parse
         ' Implementation of 'IChannelReceiver' interface.

      Public ReadOnly Property ChannelData() As Object Implements IChannelReceiver.ChannelData
         Get
            Return myChannelData
         End Get
      End Property

      ' Create and send the object URL.
      Public Function GetUrlsForUri(ByVal objectURI As String) As String() _
                                                Implements IChannelReceiver.GetUrlsForUri
         Dim myString(0) As String
         myString(0) = Dns.Resolve(Dns.GetHostName()).AddressList(0).ToString() + "/" + objectURI
         Return myString
      End Function 'GetUrlsForUri

      ' Start listening to the port.
      Public Sub StartListening(ByVal data As Object) Implements IChannelReceiver.StartListening
         If myListening = False Then
             myTcpListener.Start()
             myListening = True
             Console.WriteLine("Server Started Listening !!!")
         End If
      End Sub 'StartListening

      ' Stop listening to the port.
      Public Sub StopListening(ByVal data As Object) Implements IChannelReceiver.StopListening
         If myListening = True Then
             myTcpListener.Stop()
             myListening = False
             Console.WriteLine("Server Stopped Listening !!!")
         End If
      End Sub 'StopListening
   End Class 'MyCustomChannel 