      Public Overrides Function Invoke(myMessage As IMessage) As IMessage
         Dim myCallMessage As IMethodCallMessage = CType(myMessage, IMethodCallMessage)
         
         Dim myIMethodReturnMessage As IMethodReturnMessage = RemotingServices.ExecuteMessage _
                                                         (myMarshalByRefObject, myCallMessage)
         If Not (myIMethodReturnMessage.Exception Is Nothing) Then
            Console.WriteLine(myIMethodReturnMessage.MethodName + " raised an exception.")
         Else
            Console.WriteLine(myIMethodReturnMessage.MethodName + " does not raised an exception.")
         End If
         
         Return myIMethodReturnMessage
      End Function 'Invoke