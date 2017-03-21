      Public Overrides Function Invoke(myMessage As IMessage) As IMessage
         Console.WriteLine("MyProxy 'Invoke method' Called...")
         If TypeOf myMessage Is IMethodCallMessage Then
            Console.WriteLine("IMethodCallMessage")
         End If
         If TypeOf myMessage Is IMethodReturnMessage Then
            Console.WriteLine("IMethodReturnMessage")
         End If
         If TypeOf myMessage Is IConstructionCallMessage Then
            ' Initialize a new instance of remote object
            Dim myIConstructionReturnMessage As IConstructionReturnMessage = _
                  Me.InitializeServerObject(CType(myMessage, IConstructionCallMessage))
            Dim constructionResponse As _
                  New ConstructionResponse(Nothing, CType(myMessage, IMethodCallMessage))
            Return constructionResponse
         End If
         Dim myIDictionary As IDictionary = myMessage.Properties
         Dim returnMessage As IMessage
         myIDictionary("__Uri") = myUri
         ' Synchronously dispatch messages to server.
         returnMessage = ChannelServices.SyncDispatchMessage(myMessage)
         ' Pushing return value and OUT parameters back onto stack.
         Dim myMethodReturnMessage As IMethodReturnMessage = _
               CType(returnMessage, IMethodReturnMessage)
         Return returnMessage
      End Function 'Invoke