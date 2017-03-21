   <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Sub ProcessMessageStart(requestMessage As IMessage, bClientSide As Boolean, bAsyncCall As Boolean) Implements IDynamicMessageSink.ProcessMessageStart
   
      Console.WriteLine(ControlChars.Cr + "ProcessMessageStart")
      Console.WriteLine("requestMessage = {0}", requestMessage)
      
      Try
         Console.WriteLine("SessionId = {0}.", RemotingServices.GetSessionIdForMethodMessage(CType(requestMessage, IMethodMessage)))
      Catch e As InvalidCastException
         Console.WriteLine("The requestMessage is not an IMethodMessage.")
      End Try
      
      Dim requestMethodCallMessage As IMethodCallMessage
      
      Try
         requestMethodCallMessage = CType(requestMessage, MethodCall)
         
         ' Prints the details of the IMethodCallMessage to the console
         Console.WriteLine(ControlChars.Cr + "MethodCall details")
         Console.WriteLine("Uri = {0}", requestMethodCallMessage.Uri)
         Console.WriteLine("TypeName = {0}", requestMethodCallMessage.TypeName)
         Console.WriteLine("MethodName = {0}", requestMethodCallMessage.MethodName)
         Console.WriteLine("ArgCount = {0}", requestMethodCallMessage.ArgCount)
         Console.WriteLine("MethodCall.Args")
         
         Dim o As Object
         For Each o In  requestMethodCallMessage.Args
            Console.WriteLine(ControlChars.Tab + "{0}", o)
         Next o 
         
         ' Sends this method call message to another server to replicate
         ' the call at the second server
         If requestMethodCallMessage.Uri = replicatedServiceUri Then
            
            Dim replicationService As SampleService = CType(Activator.GetObject(GetType(SampleService), replicationServerUrl + replicatedServiceUri), SampleService)
            Dim returnMessage As IMethodReturnMessage = RemotingServices.ExecuteMessage(replicationService, requestMethodCallMessage)
            
            ' Prints the results of the method call stored in the IMethodReturnMessage.
            Console.WriteLine(ControlChars.Cr + "Message returned by ExecuteMessage.")
            Console.WriteLine(ControlChars.Tab + "Exception = {0}", returnMessage.Exception)
            Console.WriteLine(ControlChars.Tab + "ReturnValue = {0}", returnMessage.ReturnValue)
            Console.WriteLine(ControlChars.Tab + "OutArgCount = {0}", returnMessage.OutArgCount)
            Console.WriteLine("Return message OutArgs")
            For Each o In  requestMethodCallMessage.Args
               Console.WriteLine(ControlChars.Tab + "{0}", o)
            Next o
            
         End If
         
      Catch e As InvalidCastException
         Console.WriteLine("The requestMessage is not a MethodCall")
      End Try
   
   End Sub 'ProcessMessageStart