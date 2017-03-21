         // Creating the 'IDictionary' to set the server object properties.
         IDictionary myDictionary = new Hashtable();
         myDictionary["name"]="HttpClientChannel";
         myDictionary["priority"]=2;
         // Set the properties along with the constructor.
         HttpClientChannel myHttpClientChannel = 
               new HttpClientChannel(myDictionary,new BinaryClientFormatterSinkProvider());
         // Register the server channel.
         ChannelServices.RegisterChannel(myHttpClientChannel);
         MyHelloServer myHelloServer1 = (MyHelloServer)Activator.GetObject(
         typeof(MyHelloServer), "http://localhost:8085/SayHello");
         if (myHelloServer1 == null)
            System.Console.WriteLine("Could not locate server");
         else
         {
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"));
            // Get the name of the channel.
            Console.WriteLine("Channel Name :"+myHttpClientChannel.ChannelName);
            // Get the channel priority.
            Console.WriteLine("ChannelPriority :"+myHttpClientChannel.ChannelPriority.ToString());
            string myString,myObjectURI1;
            Console.WriteLine("Parse :" + 
                myHttpClientChannel.Parse("http://localhost:8085/SayHello",out myString)+myString);
            // Get the key count.
            System.Console.WriteLine("Keys.Count : " + myHttpClientChannel.Keys.Count);
            // Get the channel message sink that delivers message to the specified url.
            IMessageSink myIMessageSink = 
            myHttpClientChannel.CreateMessageSink("http://localhost:8085/NewEndPoint", 
                                                                            null,out myObjectURI1);
            Console.WriteLine("The channel message sink that delivers the messages to the URL is : "
                                    +myIMessageSink.ToString());
            Console.WriteLine("URI of the new channel message sink is: " +myObjectURI1);
         }