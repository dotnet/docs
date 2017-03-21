         // Extract the channel URI and the remote well known object URI from the specified URL.
         Console.WriteLine("Parsed : " + 
                        myHttpServerChannel.Parse(myHttpServerChannel.GetChannelUri()+
                                                               "/SayHello",out myString));
         Console.WriteLine("Remote WellKnownObject : " + myString);
         Console.WriteLine("Hit <enter> to stop listening...");
         Console.ReadLine();
         // Stop listening to channel.
         myHttpServerChannel.StopListening((object)myPort);