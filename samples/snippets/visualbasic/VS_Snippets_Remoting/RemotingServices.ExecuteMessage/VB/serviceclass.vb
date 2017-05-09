Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Contexts
Imports System.Runtime.Remoting.Channels
Imports System.Security.Permissions
Imports Microsoft.VisualBasic


Public Class SampleService
   Inherits ContextBoundObject
   
   Public Function UpdateServer(i As Integer, d As Double, s As String) As Boolean
      Console.WriteLine("SampleService.UpdateServer called: {0}, {1}, {2}", i, d, s)
      Return True
   End Function 'UpdateServer
End Class 'SampleService


Public Class ReplicationSinkProp
   Implements IDynamicProperty
   Implements IContributeDynamicSink
   
   Public ReadOnly Property Name() As String Implements IDynamicProperty.Name
      <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Return "ReplicationSinkProp"
      End Get
   End Property

   <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Function GetDynamicSink() As IDynamicMessageSink Implements IContributeDynamicSink.GetDynamicSink
      Return New ReplicationSink()
   End Function 'GetDynamicSink
End Class 'ReplicationSinkProp


Public Class ReplicationSink
   Implements IDynamicMessageSink
   Private replicatedServiceUri As String = "/SampleServiceUri"
   Private replicationServerUrl As String = "tcp://localhost:9001"
   
   ' System.Runtime.Remoting.RemotingServices.ExecuteMessage
   ' System.Runtime.Remoting.RemotingServices.GetSessionIdForMethodMessage
   ' <Snippet1>
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
   ' </Snippet1>

   <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Sub ProcessMessageFinish(requestMessage As IMessage, bClientSide As Boolean, bAsyncCall As Boolean) Implements IDynamicMessageSink.ProcessMessageFinish
      
      Console.WriteLine(ControlChars.Cr + "ProcessMessageFinish")
      Console.WriteLine("requestMessage = {0}", requestMessage)
      Dim requestMethodReturn As ReturnMessage
      Try
         requestMethodReturn = CType(requestMessage, ReturnMessage)
         ' Print the details of the ReturnMessage to the console
         Console.WriteLine(ControlChars.Cr + "ReturnMessage details")
         Console.WriteLine(ControlChars.Tab + "Exception = {0}", requestMethodReturn.Exception)
         Console.WriteLine(ControlChars.Tab + "ReturnValue = {0}", requestMethodReturn.ReturnValue)
         Console.WriteLine(ControlChars.Tab + "OutArgCount = {0}", requestMethodReturn.OutArgCount)
         Console.WriteLine("Return message OutArgs")
         Dim o As Object
         For Each o In  requestMethodReturn.Args
            Console.WriteLine(ControlChars.Tab + "{0}", o)
         Next o
      Catch e As InvalidCastException
         Console.WriteLine("The requestMessage is not a ReturnMessage.")
      End Try
   End Sub 'ProcessMessageFinish
End Class 'ReplicationSink
