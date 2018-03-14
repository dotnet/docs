' System.Runtime.Remoting.Channels.ChannelServices.SyncDispatchMessage(IMessage)

' The following example demonstrates 'SyncDispatchMessage' method of 
' 'ChannelServices' class. In the example, 'MyProxy' extends 'RealProxy'
' class and overrides its constructor and 'Invoke' messages. In the 'Main' 
' method, the 'MyProxy' class is instantiated and 'MyPrintMethod' method 
' is called on it.

Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions
Imports Microsoft.VisualBasic

' <Snippet1>
' Create a custom 'RealProxy'.
Public Class MyProxy
   Inherits RealProxy
   Private myURIString As String
   Private myMarshalByRefObject As MarshalByRefObject

   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Sub New(ByVal myType As Type)
      MyBase.New(myType)
      ' RealProxy uses the Type to generate a transparent proxy.
      myMarshalByRefObject = CType(Activator.CreateInstance(myType), MarshalByRefObject)
      ' Get 'ObjRef', for transmission serialization between application domains.
      Dim myObjRef As ObjRef = RemotingServices.Marshal(myMarshalByRefObject)
      ' Get the 'URI' property of 'ObjRef' and store it.
      myURIString = myObjRef.URI
      Console.WriteLine("URI :{0}", myObjRef.URI)
   End Sub 'New

<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.Infrastructure)> _
   Public Overrides Function Invoke(ByVal myIMessage As IMessage) As IMessage
      Console.WriteLine("MyProxy.Invoke Start")
      Console.WriteLine("")

      If TypeOf myIMessage Is IMethodCallMessage Then
         Console.WriteLine("IMethodCallMessage")
      End If
      If TypeOf myIMessage Is IMethodReturnMessage Then
         Console.WriteLine("IMethodReturnMessage")
      End If
      Dim msgType As Type
      msgType = CObj(myIMessage).GetType
      Console.WriteLine("Message Type: {0}", msgType.ToString())
      Console.WriteLine("Message Properties")
      Dim myIDictionary As IDictionary = myIMessage.Properties
      ' Set the '__Uri' property of 'IMessage' to 'URI' property of 'ObjRef'.
      myIDictionary("__Uri") = myURIString
      Dim myIDictionaryEnumerator As IDictionaryEnumerator = CType(myIDictionary.GetEnumerator(), _
                                                                    IDictionaryEnumerator)

      While myIDictionaryEnumerator.MoveNext()
         Dim myKey As Object = myIDictionaryEnumerator.Key
         Dim myKeyName As String = myKey.ToString()
         Dim myValue As Object = myIDictionaryEnumerator.Value

         Console.WriteLine(ControlChars.Tab + "{0} : {1}", myKeyName, myIDictionaryEnumerator.Value)
         If myKeyName = "__Args" Then
            Dim myObjectArray As Object() = CType(myValue, Object())
            Dim aIndex As Integer
            For aIndex = 0 To myObjectArray.Length - 1
               Console.WriteLine(ControlChars.Tab + ControlChars.Tab + "arg: {0} myValue: {1}", _
                                                              aIndex, myObjectArray(aIndex))
             Next aIndex
         End If

         If myKeyName = "__MethodSignature" And Not Nothing Is myValue Then
            Dim myObjectArray As Object() = CType(myValue, Object())
            Dim aIndex As Integer
            For aIndex = 0 To myObjectArray.Length - 1
               Console.WriteLine(ControlChars.Tab + ControlChars.Tab + "arg: {0} myValue: {1}", _
                                                           aIndex, myObjectArray(aIndex))
            Next aIndex
         End If
      End While

        Dim myReturnMessage As IMessage

        myIDictionary("__Uri") = myURIString
        Console.WriteLine("__Uri {0}", myIDictionary("__Uri"))

        Console.WriteLine("ChannelServices.SyncDispatchMessage")
        myReturnMessage = ChannelServices.SyncDispatchMessage(CObj(myIMessage))

        ' Push return value and OUT parameters back onto stack.
        Dim myMethodReturnMessage As IMethodReturnMessage = CType(myReturnMessage, IMethodReturnMessage)
        Console.WriteLine("IMethodReturnMessage.ReturnValue: {0}", myMethodReturnMessage.ReturnValue)

        Console.WriteLine("MyProxy.Invoke - Finish")

        Return myReturnMessage
    End Function 'Invoke
End Class 'MyProxy
' </Snippet1>

Public Class Client

   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Overloads Shared Sub Main()
      Try
         Dim myTcpChannel As New TcpChannel(8086)
         ChannelServices.RegisterChannel(myTcpChannel)
         Dim myProxyObject As New MyProxy(GetType(PrintServer))
         Dim myPrintServer As PrintServer = CType(myProxyObject.GetTransparentProxy(), PrintServer)
         If myPrintServer Is Nothing Then
            Console.WriteLine("Could not locate server")
         Else
             Console.WriteLine(myPrintServer.MyPrintMethod("String1", 1.2, 6))
         End If
         Console.WriteLine("Calling the Proxy")
         Dim kValue As Integer = myPrintServer.MyPrintMethod("String1", 1.2, 6)
         Console.WriteLine("Checking result")

         If kValue = 6 Then
            Console.WriteLine("PrintServer.MyPrintMethod PASSED : returned {0}", kValue)
         Else
            Console.WriteLine("PrintServer.MyPrintMethod FAILED : returned {0}", kValue)
         End If
         Console.WriteLine("Sample Done")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("The source of exception: " + e.Source)
         Console.WriteLine("The Message of exception: " + e.Message)
      End Try
   End Sub 'Main
End Class 'Client
