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
   <SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure), _
   AttributeUsage(AttributeTargets.Class)>  _
   Public Class MyProxyAttribute
      Inherits ProxyAttribute

      Public Sub New()
      End Sub 'New

      ' Create an instance of ServicedComponentProxy
      Public Overrides Function CreateInstance(serverType As Type) As MarshalByRefObject
         Return MyBase.CreateInstance(serverType)
      End Function 'CreateInstance

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

      Public Overrides Function CreateObjRef(ServerType As Type) As ObjRef
         Console.WriteLine("CreateObjRef Method Called ...")
         Dim myObjRef As New CustomObjRef(myMarshalByRefObject, ServerType)
         myObjRef.URI = myUri
         Return myObjRef
      End Function 'CreateObjRef

      Public Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
         ' Add your custom data if any here.
         MyBase.GetObjectData(info, context)
      End Sub 'GetObjectData
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
         ' Create an instance of MyProxy.
         Dim myProxyInstance As New MyProxy(GetType(CustomServer))
         ' Get a CustomServer proxy.
         Dim myHelloServer As CustomServer = _
                     CType(myProxyInstance.GetTransparentProxy(), CustomServer)
         ' Get stubdata.
         Console.WriteLine("GetStubData = " + RealProxy.GetStubData(myProxyInstance).ToString())
         ' Get ProxyType.
         Console.WriteLine("Type of object represented by RealProxy is :" + _
                                                myProxyInstance.GetProxiedType().ToString())
         myHelloServer.HelloMethod("RealProxy Sample")
         Console.WriteLine("")
         ' Get a reference object from server.
         Console.WriteLine("Create an objRef object to be marshalled across Application Domains...")
         Dim CustomObjRef As ObjRef = myProxyInstance.CreateObjRef(GetType(CustomServer))
         Console.WriteLine("URI of 'ObjRef' object =  " + CustomObjRef.URI)
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'Samples.AspNet.VB