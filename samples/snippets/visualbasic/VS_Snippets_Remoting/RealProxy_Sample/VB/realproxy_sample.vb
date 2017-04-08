' System.Runtime.Remoting.Proxies.RealProxy.SupportsInterface(Guid);
' System.Runtime.Remoting.Proxies.RealProxy.GetCOMIUnknown(bool);
' System.Runtime.Remoting.Proxies.RealProxy.SetCOMIUnknown(IntPtr);
' The following example demonstrates implementation of methods
' 'GetCOMIUnknown','SupportsInterface' and 'SetCOMIUnknown' of 
' System.Runtime.Remoting.Proxies.RealProxy.
' 
' The following program has a 'CustomProxy' referring to unmanaged COM component.
' A COM Runtime Wrapper takes care of method call to unmanaged world. SupportsInterface
' method is overridden to return address of COM Runtime Wrapper.

Imports System
Imports System.Collections
Imports System.Runtime.Serialization
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Activation
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports ActiveDs

Namespace CustomProxySample
   Public Class MyProxy
      Inherits RealProxy
      Private m_URI As String
      Private myMarshalByRefObject As MarshalByRefObject

      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Sub New()
         MyBase.New()
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = CType(Activator.CreateInstance(GetType(WinNTSystemInfo)), MarshalByRefObject)
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         m_URI = myObjRef.URI
      End Sub 'New

      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Sub New(myType As Type)
         MyBase.New(myType)
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = CType(Activator.CreateInstance(myType), MarshalByRefObject)
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         m_URI = myObjRef.URI
      End Sub 'New

      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Sub New(myType As Type, targetObject As MarshalByRefObject)
         MyBase.New(myType)
         Console.WriteLine("MyProxy Constructor Called...")
         myMarshalByRefObject = targetObject
         Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
         m_URI = myObjRef.URI
      End Sub 'New

      <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Overrides Function Invoke(msg As IMessage) As IMessage
         If TypeOf msg Is IConstructionCallMessage Then
            ' Initialize a new instance of remote object
            Dim myIConstructionReturnMessage As IConstructionReturnMessage = _
                     Me.InitializeServerObject(CType(msg, IConstructionCallMessage))
            Dim constructionResponse As _
                     New ConstructionResponse(Nothing, CType(msg, IMethodCallMessage))
            Return constructionResponse
         End If
         Dim myIDictionary As IDictionary = msg.Properties
         Dim retMsg As IMessage
         myIDictionary("__Uri") = m_URI

         ' Synchronously dispatch messages to server.
         retMsg = ChannelServices.SyncDispatchMessage(msg)
         ' Pushing return value and OUT parameters back onto stack
         Dim mrm As IMethodReturnMessage = CType(retMsg, IMethodReturnMessage)
         Return retMsg
      End Function 'Invoke

' <Snippet1>
' <Snippet2>
' <Snippet3>
      <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Overrides Function SupportsInterface(ByRef myGuid As Guid) As IntPtr
         Console.WriteLine("SupportsInterface method called")
         ' Object reference is requested for communication with unmanaged objects
         ' in the current process through COM.
         Dim myIntPtr As IntPtr = Me.GetCOMIUnknown(False)
         ' Stores an unmanaged proxy of the object.
         Me.SetCOMIUnknown(myIntPtr)
         ' return COM Runtime Wrapper pointer.
         Return myIntPtr
      End Function 'SupportsInterface
' </Snippet3>
' </Snippet2>
' </Snippet1>
   End Class 'MyProxy

   Public Class ProxySample
      ' Acts as a custom proxy user.
      <SecurityPermission(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         Console.WriteLine("")
         Console.WriteLine("CustomProxy Sample")
         Console.WriteLine("==================")
         Dim mProxy As New MyProxy(GetType(WinNTSystemInfo))
         Dim myHelloServer As WinNTSystemInfo = CType(mProxy.GetTransparentProxy(), WinNTSystemInfo)
         Console.WriteLine("Machine Name = " + myHelloServer.ComputerName)
         Console.WriteLine("Domain Name = " + myHelloServer.DomainName)
         Console.WriteLine("User Name = " + myHelloServer.UserName)
         ' Construct Guid object from unmanaged Interface 'IADsWinNTSystemInfo' guid.
         Dim myGuid As New Guid("{6C6D65DC-AFD1-11D2-9CB9-0000F87A369E}")
         Dim myIntrPtr As IntPtr = mProxy.SupportsInterface(myGuid)
         Console.WriteLine("Requested Interface Pointer= " + myIntrPtr.ToInt32().ToString())
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'CustomProxySample