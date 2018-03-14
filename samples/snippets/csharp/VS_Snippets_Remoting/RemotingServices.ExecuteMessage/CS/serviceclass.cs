using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;

public class SampleService : ContextBoundObject {
    public bool UpdateServer(int i, double d, string s){
	    Console.WriteLine("SampleService.UpdateServer called: {0}, {1}, {2}", i, d, s);
	    return true;
	}
}

public class ReplicationSinkProp : IDynamicProperty, IContributeDynamicSink {
    public string Name{
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get{ return "ReplicationSinkProp";}
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public IDynamicMessageSink GetDynamicSink(){
        return new ReplicationSink();
    }
}

public class ReplicationSink : IDynamicMessageSink{
   const string replicatedServiceUri = "/SampleServiceUri";
   const string replicationServerUrl = "tcp://localhost:9001";
   // System.Runtime.Remoting.RemotingServices.ExecuteMessage
   // System.Runtime.Remoting.RemotingServices.GetSessionIdForMethodMessage
   // <Snippet1>
   [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void ProcessMessageStart(IMessage requestMessage, bool bClientSide, bool bAsyncCall) {
      
      Console.WriteLine("\nProcessMessageStart");
      Console.WriteLine("requestMessage = {0}", requestMessage);
      
      try {
         Console.WriteLine("SessionId = {0}.",
             RemotingServices.GetSessionIdForMethodMessage((IMethodMessage)requestMessage));
      }
      catch (InvalidCastException) {
         Console.WriteLine("The requestMessage is not an IMethodMessage.");
      }

      IMethodCallMessage requestMethodCallMessage;
      
      try {
         requestMethodCallMessage = (IMethodCallMessage)requestMessage;
         // Prints the details of the IMethodCallMessage to the console.
         Console.WriteLine("\nMethodCall details");
         Console.WriteLine("Uri = {0}", requestMethodCallMessage.Uri);
         Console.WriteLine("TypeName = {0}", requestMethodCallMessage.TypeName);
         Console.WriteLine("MethodName = {0}", requestMethodCallMessage.MethodName);
         Console.WriteLine("ArgCount = {0}", requestMethodCallMessage.ArgCount);
         
         Console.WriteLine("MethodCall.Args");
         foreach(object o in requestMethodCallMessage.Args)
             Console.WriteLine("\t{0}", o);
         
         // Sends this method call message to another server to replicate
         // the call at the second server.
         if (requestMethodCallMessage.Uri == replicatedServiceUri) {
            
            SampleService replicationService = 
               (SampleService)Activator.GetObject(typeof(SampleService), 
               replicationServerUrl + replicatedServiceUri);
            
            IMethodReturnMessage returnMessage = 
               RemotingServices.ExecuteMessage(replicationService, requestMethodCallMessage);
            
            // Prints the results of the method call stored in the IMethodReturnMessage.
            Console.WriteLine("\nMessage returned by ExecuteMessage.");
            Console.WriteLine("\tException = {0}", returnMessage.Exception);
            Console.WriteLine("\tReturnValue = {0}", returnMessage.ReturnValue);
            Console.WriteLine("\tOutArgCount = {0}", returnMessage.OutArgCount);
            Console.WriteLine("Return message OutArgs");
            
            foreach(object o in requestMethodCallMessage.Args)
               Console.WriteLine("\t{0}", o);
         }
      }
      catch (InvalidCastException) {
          Console.WriteLine("The requestMessage is not a MethodCall");
      }
   }
   // </Snippet1>

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void ProcessMessageFinish(IMessage requestMessage, bool bClientSide, bool bAsyncCall){
        
        Console.WriteLine("\nProcessMessageFinish");
        Console.WriteLine("requestMessage = {0}", requestMessage);
        ReturnMessage requestMethodReturn;
        try {
            requestMethodReturn = (ReturnMessage)requestMessage;
            // Print the details of the ReturnMessage to the console
            Console.WriteLine("\nReturnMessage details");
            Console.WriteLine("\tException = {0}", requestMethodReturn.Exception);
            Console.WriteLine("\tReturnValue = {0}", requestMethodReturn.ReturnValue);
            Console.WriteLine("\tOutArgCount = {0}", requestMethodReturn.OutArgCount);
            Console.WriteLine("Return message OutArgs");
            foreach(object o in requestMethodReturn.Args)
                Console.WriteLine("\t{0}", o);
        }
        catch (InvalidCastException) {
            Console.WriteLine("The requestMessage is not a ReturnMessage.");
        }
    }
}
