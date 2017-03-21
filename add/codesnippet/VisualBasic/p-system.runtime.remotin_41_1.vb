      Public Overrides Function Invoke(myMessage As IMessage) As IMessage
         Dim myCallMessage As IMethodCallMessage = CType(myMessage, IMethodCallMessage)

         Dim myIMethodReturnMessage As IMethodReturnMessage = RemotingServices. _
            ExecuteMessage(myMarshalByRefObject, myCallMessage)

         Console.WriteLine("Method name : " + myIMethodReturnMessage.MethodName)
         Console.WriteLine("The return value is : " + myIMethodReturnMessage.ReturnValue)
         
         ' Get number of 'ref' and 'out' parameters.
         Dim myArgOutCount As Integer = myIMethodReturnMessage.OutArgCount
         Console.WriteLine("The number of 'ref', 'out' parameters are : " + _
            myIMethodReturnMessage.OutArgCount.ToString())
         ' Gets name and values of 'ref' and 'out' parameters.
         Dim i As Integer
         For i = 0 To myArgOutCount - 1
            Console.WriteLine("Name of argument {0} is '{1}'.", i, _
               myIMethodReturnMessage.GetOutArgName(i))
            Console.WriteLine("Value of argument {0} is '{1}'.", i, _
               myIMethodReturnMessage.GetOutArg(i))
         Next i
         Console.WriteLine()
         Dim myObjectArray As Object() = myIMethodReturnMessage.OutArgs
         For i = 0 To myObjectArray.Length - 1
            Console.WriteLine("Value of argument {0} is '{1}' in OutArgs", i, myObjectArray(i))
         Next i
         Return myIMethodReturnMessage
      End Function 'Invoke