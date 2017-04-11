' System.Runtime.Remoting.Messaging.IMethodMessage.LogicalCallContext
' System.Runtime.Remoting.Messaging.IMethodMessage.Uri

' The program demonstrates the 'LogicalCallContext' and 'Uri' properties of 
' the IMethodMessage interface.
' In the program a remote object is created with a method by extending 'MarshalByRefObject'.
' A custom proxy is created by extending 'RealProxy' and overriding 'Invoke' 
' method of 'RealProxy'. In this example custom proxy is accessed by passing message 
' to the Invoke method. Then the values of 'Uri' and 'LogicalCallContext' properties
' are displayed to the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

<AttributeUsage(AttributeTargets.Class)>  _
Public Class MyProxyAttribute
   Inherits ProxyAttribute

<SecurityPermission(SecurityAction.LinkDemand)> _
   Public Sub New()
   End Sub 'New

<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.Infrastructure)> _
   Public Overrides Function CreateInstance(serverType As Type) As MarshalByRefObject
      If serverType.IsMarshalByRef Then
         Dim targetObject As MarshalByRefObject = _
                  CType(Activator.CreateInstance(serverType), MarshalByRefObject)
         Dim proxy As New MyProxy(serverType, targetObject)
         Return CType(proxy.GetTransparentProxy(), MarshalByRefObject)
      Else
         Throw New Exception("Proxies only work on MarshalByRefObject objects" + _
                             " and their children")
      End If
   End Function 'CreateInstance
End Class 'MyProxyAttribute

' MyProxy extends the CLR Remoting RealProxy.
' This demonstrate the RealProxy extensiblity.
' <Snippet1>
Public Class MyProxy
   Inherits RealProxy

   Private stringUri As String
   Private targetObject As MarshalByRefObject

   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Sub New(type As Type)
      MyBase.New(type)
      targetObject = CType(Activator.CreateInstance(type), MarshalByRefObject)
      Dim myObject As ObjRef = RemotingServices.Marshal(targetObject)
      stringUri = myObject.URI
   End Sub 'New

<SecurityPermission(SecurityAction.LinkDemand)> _
   Public Sub New(type As Type, targetObject As MarshalByRefObject)
      MyBase.New(type)
      Me.targetObject = targetObject
   End Sub 'New


' <Snippet2>
<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.Infrastructure)> _
   Public Overrides Function Invoke(message As IMessage) As IMessage
      message.Properties("__Uri") = stringUri
      Dim myMethodMessage As IMethodMessage = _
            CType(ChannelServices.SyncDispatchMessage(message), IMethodMessage)
      Console.WriteLine("---------IMethodMessage example-------")
      Console.WriteLine("Method name : " + myMethodMessage.MethodName)
      Console.WriteLine("LogicalCallContext has information : " + _
            myMethodMessage.LogicalCallContext.HasInfo.ToString())
      Console.WriteLine("Uri : " + myMethodMessage.Uri)
      Return myMethodMessage
   End Function 'Invoke
' </Snippet2>

End Class 'MyProxy
' </Snippet1>
Public Class Zip
   Inherits MarshalByRefObject
   Implements ILogicalThreadAffinative

   Public Sub New()
   End Sub 'New

   Public Function Method1(i As Integer) As Integer
      Return i
   End Function 'Method1
End Class 'Zip

Public Class ProxySample
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Dim proxy As New MyProxy(GetType(Zip))
      Dim myZip As Zip = CType(proxy.GetTransparentProxy(), Zip)
      CallContext.SetData("USER", New Zip())
      myZip.Method1(6)
   End Sub 'Main
End Class 'ProxySample