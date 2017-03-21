      public override IMessage Invoke(IMessage myMessage)
      {
         IMethodCallMessage myCallMessage = (IMethodCallMessage)myMessage;

         IMethodReturnMessage myIMethodReturnMessage =
            RemotingServices.ExecuteMessage(myMarshalByRefObject,myCallMessage);
         if(myIMethodReturnMessage.Exception != null)
            Console.WriteLine(myIMethodReturnMessage.MethodName +
               " raised an exception.");
         else
            Console.WriteLine(myIMethodReturnMessage.MethodName +
               " does not raised an exception.");

         return myIMethodReturnMessage;
      }