         string myString = null ;
         Operation myOperation = new Operation();
         myDescription = ServiceDescription.Read("Operation_2_Input_CS.wsdl");
         Message[] myMessage = new Message[ myDescription.Messages.Count ] ;

         // Copy the messages from the service description.
         myDescription.Messages.CopyTo( myMessage, 0 );
         for( int i = 0 ; i < myDescription.Messages.Count; i++ )
         {
            MessagePart[] myMessagePart = 
               new MessagePart[ myMessage[i].Parts.Count ];

            // Copy the message parts into a MessagePart.
            myMessage[i].Parts.CopyTo( myMessagePart, 0 );
            for( int j = 0 ; j < myMessage[i].Parts.Count; j++ )
            {
               myString += myMessagePart[j].Name;
               myString += " " ;
            }
         }
         // Set the ParameterOrderString equal to the list of 
         // message part names.
         myOperation.ParameterOrderString = myString;
         string[] myString1 = myOperation.ParameterOrder;
         int k = 0 ;
         Console.WriteLine("The list of message part names is as follows:");
         while( k<5 )
         {
            Console.WriteLine( myString1[k] );
            k++;
         }