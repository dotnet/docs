' System.Runtime.Remoting.Proxies.ProxyAttribute.CreateInstance;
' System.Runtime.Remoting.Proxies.ProxyAttribute.CreateProxy;
' System.Runtime.Remoting.Proxies.RealProxy.SetStubData;
' System.Runtime.Remoting.Proxies.RealProxy.Invoke;
' System.Runtime.Remoting.Proxies.RealProxy.InitializeServerObject;
' System.Runtime.Remoting.Proxies.RealProxy.CreateObjRef;
' System.Runtime.Remoting.Proxies.RealProxy.GetObjectData;
' System.Runtime.Remoting.Proxies.RealProxy.GetTransparentProxy;
' System.Runtime.Remoting.Proxies.RealProxy.GetStubData;
' System.Runtime.Remoting.Proxies.RealProxy.GetProxiedType;
' System.Runtime.Remoting.Proxies.ProxyAttribute;
' System.Runtime.Remoting.Proxies.RealProxy;

' The following example demonstrates implementation of methods
' 'CreateInstance' and 'CreateProxy' of System.Runtime.Remoting.Proxies.ProxyAttribute and methods
' 'SetStubData', 'Invoke', 'InitializeServerObject', 'CreateObjRef', 'GetStubData', 'GetObjectData',
' 'GetTransparentProxy', 'GetProxiedType' of System.Runtime.Remoting.Proxies.RealProxy.
' 
' The following program has derived from'ProxyAttribute','RealProxy' classes. CustomProxy is 
' implemented by deriving from 'RealProxy' and overriding 'Invoke' method. The new statement for 
' 'CustomServer' class is intercepted to derived 'CustomProxyAttribute' by setting 'ProxyAttribute'
' on the CustomServer class. Implementation of 'RealProxy' and 'ProxyAttribute' methods are shown.

' <Snippet12>
Imports System
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Activation
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Permissions

Namespace Samples
' <Snippet11>
   <SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure), _
   AttributeUsage(AttributeTargets.Class)>  _
   Public Class MyProxyAttribute
      Inherits ProxyAttribute

      Public Sub New()
      End Sub 'New

' <Snippet1>
      ' Create an instance of ServicedComponentProxy
      Public Overrides Function CreateInstance(serverType As Type) As MarshalByRefObject
         Return MyBase.CreateInstance(serverType)
      End Function 'CreateInstance
' </Snippet1>

' <Snippet2>
' <Snippet3>
      Public Overrides Function CreateProxy(objRef1 As ObjRef, serverType As Type, _
                  serverObject As Object, serverContext As Context) As RealProxy
         Dim myCustomProxy As New MyProxy(serverType)
         If Not (serverContext Is Nothing) Then
            RealProxy.SetStubData(myCustomProxy, serverContext)
         End If
         If Not serverType.IsMarshalByRef And serverContext Is Nothing Then
            Throw New RemotingException("Bad Type for CreateProxy")
         End If
         Return myCustomProxy
      End Function 'CreateProxy
' </Snippet3>
' </Snippet2>
   End Class 'MyProxyAttribute

   <MyProxyAttribute()> _
   Public Class CustomServer
      Inherits ContextBoundObject

      Public Sub New()
         Console.WriteLine("CustomServer Base Class constructor called")
      End Sub 'New

      Public Sub HelloMethod(str As String)
         Console.WriteLine("HelloMethod of Server is invoked with message : " + str)
      End Sub 'HelloMethod
   End Class 'CustomServer
' </Snippet11>
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyProxy
      Inherits RealProxy
      Private myUri As String
      Private myMarshalByRefObject As MarshalByRefObject

      Public Sub New()
         MyBase.New()
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = _
               CType(Activator.CreateInstance(GetType(CustomServer)), MarshalByRefObject)
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         myUri = myObjRef.URI
      End Sub 'New

      Public Sub New(type1 As Type)
         MyBase.New(type1)
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = CType(Activator.CreateInstance(type1), MarshalByRefObject)
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         myUri = myObjRef.URI
      End Sub 'New

      Public Sub New(type1 As Type, targetObject As MarshalByRefObject)
         MyBase.New(type1)
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = targetObject
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         myUri = myObjRef.URI
      End Sub 'New

' <Snippet4>
' <Snippet5>
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
' </Snippet5>
' </Snippet4>

' <Snippet6>
      Public Overrides Function CreateObjRef(ServerType As Type) As ObjRef
         Console.WriteLine("CreateObjRef Method Called ...")
         Dim myObjRef As New CustomObjRef(myMarshalByRefObject, ServerType)
         myObjRef.URI = myUri
         Return myObjRef
      End Function 'CreateObjRef
' </Snippet6>

' <Snippet7>
      Public Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
         ' Add your custom data if any here.
         MyBase.GetObjectData(info, context)
      End Sub 'GetObjectData
' </Snippet7>
      <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
      Public Class CustomObjRef
         Inherits ObjRef
         Public Sub New(myMarshalByRefObject As MarshalByRefObject, serverType As Type)
            MyBase.New(myMarshalByRefObject, serverType)
            Console.WriteLine("ObjRef 'Constructor' called")
         End Sub 'New

         ' Override this method to store custom data.
         <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=true)> _
         Public Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
            MyBase.GetObjectData(info, context)
         End Sub 'GetObjectData
      End Class 'CustomObjRef
   End Class 'MyProxy
   
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class ProxySample
      ' Acts as a custom proxy user.
      Public Shared Sub Main()
         Console.WriteLine("")
         Console.WriteLine("CustomProxy Sample")
         Console.WriteLine("================")
         Console.WriteLine("")
' <Snippet8>
' <Snippet9>
' <Snippet10>
         ' Create an instance of MyProxy.
         Dim myProxyInstance As New MyProxy(GetType(CustomServer))
         ' Get a CustomServer proxy.
         Dim myHelloServer As CustomServer = _
                     CType(myProxyInstance.GetTransparentProxy(), CustomServer)
' </Snippet10>
         ' Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString())
' </Snippet9>
         ' Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" + _
                                                myProxyInstance.GetProxiedType().ToString())
' </Snippet8>
         myHelloServer.HelloMethod("RealProxy Sample")
         Console.WriteLine("")
         ' Get a reference object from server.
         Console.WriteLine("Create an objRef object to be marshalled across Application Domains...")
         Dim CustomObjRef As ObjRef = myProxyInstance.CreateObjRef(GetType(CustomServer))
         Console.WriteLine("URI of 'ObjRef' object =  " + CustomObjRef.URI)
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'Samples.AspNet.VB
' </Snippet12>
