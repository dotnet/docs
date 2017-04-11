' System.Runtime.Remoting.Messaging.IMethodReturnMessage
' System.Runtime.Remoting.Messaging.IMethodReturnMessage.OutArgs
' System.Runtime.Remoting.Messaging.IMethodReturnMessage.ReturnValue
' System.Runtime.Remoting.Messaging.IMethodReturnMessage.OutArgCount
' System.Runtime.Remoting.Messaging.IMethodReturnMessage.GetOutArg
' System.Runtime.Remoting.Messaging.IMethodReturnMessage.GetOutArgName

' The following example demonstrates 'ReturnValue', 'OutArgCount' properties,
' 'GetOutArg', 'GetOutArgName' methods of 'IMethodReturnMessage' interface 
' and 'IMethodReturnMessage' interface.
' A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' method of
''RealProxy'. The custom proxy is accessed by passing message to the Invoke method.
' The Invoke method calls properties of 'IMethodReturnMessage' interface and
' prints the values to the console.

Imports System
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

Namespace CustomProxySample
   Public Class CustomServer
      Inherits MarshalByRefObject
      
      Public Function HelloMethod(myString As String, ByRef myDoubleValue As Double, _
                                                   ByRef myIntValue As Integer) As String
         myIntValue = 100
         Return myString
      End Function 'HelloMethod
   End Class 'CustomServer

' <Snippet1>
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyProxy
      Inherits RealProxy
      Private stringUri As String
      Private myMarshalByRefObject As MarshalByRefObject
      
      Public Sub New(myType As Type)
         MyBase.New(myType)
         myMarshalByRefObject = CType(Activator.CreateInstance(myType), MarshalByRefObject)
         Dim myObject As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         stringUri = myObject.URI
      End Sub 'New
      
' <Snippet2>
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
' </Snippet2>
   End Class 'MyProxy
' </Snippet1>

   Public Class ProxySample
      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         ' Create an instance of MyProxy.
         Dim myCustomProxy As New MyProxy(GetType(CustomServer))
         ' Get an instance of remote class.
         Dim myHelloServer As CustomServer = CType(myCustomProxy.GetTransparentProxy(), CustomServer)
         Dim myDoubleValue As Double = 10.5
         Dim myIntValue As Integer = 200
         ' Invoke the remote method.
         myHelloServer.HelloMethod("Hello", myDoubleValue, myIntValue)
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'CustomProxySample