' System.Runtime.Remoting.Messaging.IMethodReturnMessage.Exception

' The following example demonstrates 'Exception' property of 'IMethodReturnMessage'interface.
' A 'CustomServer' class is defined extending 'MarshalByRefObject'. A custom proxy
' is created by extending 'RealProxy' and overriding 'Invoke' method of 'RealProxy'.
' The Invoke method calls the methods and properties of 'IMethodMessage' interface
' and display the 'Exception' property value of 'IMethodReturnMessage' interface to
' the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

Namespace CustomProxySample
   Public Class CustomServer
      Inherits MarshalByRefObject
      
      Public Sub RaiseException()
         Throw New Exception("Raising an exception.")
      End Sub 'RaiseException
   End Class 'CustomServer
   
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyProxy
      Inherits RealProxy
      Private _URI As String
      Private myMarshalByRefObject As MarshalByRefObject
      
      Public Sub New(myType As Type)
         MyBase.New(myType)
         myMarshalByRefObject = CType(Activator.CreateInstance(myType), MarshalByRefObject)
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         _URI = myObjRef.URI
      End Sub 'New
      
' <Snippet1>
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
' </Snippet1>
   End Class 'MyProxy

   Public Class ProxySample
      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         ' Create an instance of MyProxy.
         Dim myCustomProxy As New MyProxy(GetType(CustomServer))
         ' Get an instance of remote class.
         Dim myHelloServer As CustomServer = CType(myCustomProxy.GetTransparentProxy(), CustomServer)
         Try
            ' Invoke remote method.
            myHelloServer.RaiseException()
         Catch e As Exception
            Console.WriteLine("Exception: " + e.Message)
         End Try
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'CustomProxySample