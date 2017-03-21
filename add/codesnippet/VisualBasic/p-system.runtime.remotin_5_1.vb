         ' Creating the 'IDictionary' to set the server object properties.
         Dim myDictionary As  New Hashtable()
         myDictionary("name") = "HttpClientChannel"
         myDictionary("priority") = 2
         ' Set the properties along with the constructor.
       Dim myHttpClientChannel As New _
                 HttpClientChannel( myDictionary, New BinaryClientFormatterSinkProvider)
         ' Register the server channel.
         ChannelServices.RegisterChannel(myHttpClientChannel)
         Dim myHelloServer1 As MyHelloServer = CType(Activator.GetObject(GetType(MyHelloServer), _
                 "http://localhost:8085/SayHello"), MyHelloServer)
         If myHelloServer1 Is Nothing Then
            System.Console.WriteLine("Could not locate server")
         Else
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"))
            ' Get the name of the channel.
            Console.WriteLine("Channel Name :" + myHttpClientChannel.ChannelName)
            ' Get the channel priority.
            Console.WriteLine("ChannelPriority :" + myHttpClientChannel.ChannelPriority.ToString())
            Dim myString, myObjectURI1 As String
            Console.WriteLine("Parse :" + _
                 myHttpClientChannel.Parse("http://localhost:8085/SayHello", myString) + myString)
            ' Get the key count.
            System.Console.WriteLine("Keys.Count : " + myHttpClientChannel.Keys.Count.ToString())
            ' Get the channel message sink that delivers message to the specified url.
            Dim myIMessageSink As IMessageSink =myHttpClientChannel.CreateMessageSink( _
                 "http://localhost:8085/NewEndPoint", Nothing, myObjectURI1)
          Console.WriteLine("The channel message sink that delivers the messages to the URL is :" + _
                  CType(myIMessageSink, Object).ToString)
          Console.WriteLine("URI of the new channel message sink is: " + myObjectURI1)
         End If 