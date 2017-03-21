
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