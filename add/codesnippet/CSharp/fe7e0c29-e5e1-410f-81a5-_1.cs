      // Start listening to the port.
      public void StartListening(object data)
      {
         if(myListening == false)
         {
            myTcpListener.Start();
            myListening = true;
            Console.WriteLine("Server Started Listening !!!");
         }
      }