' System.Runtime.Remoting.Messaging.IMessage
' System.Runtime.Remoting.Messaging.IMessage.Properties
' System.Runtime.Remoting.Messaging.IMessageSink
' System.Runtime.Remoting.Messaging.IMessageSink.SyncProcessMessage(IMessage)

' The following example demonstrates 'IMessage.Properties', 'IMessage' interface,
' 'IMessageSink.SyncProcessMessage' and 'IMessageSink' interface.
' In the example the MyProxy is derived from 'RealProxy' class. In MyProxy
' 'MessageSink' is created using 'CreateMessageSink' method of 'IChannelSender'
' interface. The 'IMessageSink' return by 'CreateMessageSink' is used to demonstrate
' 'IMessageSink.SyncProcessMessage' of 'IMessageSink' interface. The 'Invoke' method
' is overridden in 'MyProxy' class.to demonstrate its properties.

'Note : Web.config file should have the following code :

         '<configuration>
         '  <system.runtime.remoting>
         '    <application>

         '      <service>
         '        <wellknown mode="SingleCall" type="Share.MyHelloService, Share" objectUri="myServiceAccess.soap" />
         '      </service>

         '    </application>
         '  </system.runtime.remoting>
         '</configuration>


'<Snippet1>
'<Snippet3>

Imports System
Imports System.Collections
Imports System.Threading
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions
Imports Share


Namespace MyNameSpace

   Public Class MyProxy
      Inherits RealProxy
      Private myUrl As String
      Private myObjectURI As String
      Private myMessageSink As IMessageSink

      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Sub New(myType As Type, myUrl1 As String)
         MyBase.New(myType)

         myUrl = myUrl1

         Dim myRegisteredChannels As IChannel() = ChannelServices.RegisteredChannels

         Dim channel As IChannel
         For Each channel In  myRegisteredChannels
            If TypeOf channel Is IChannelSender Then
               Dim myChannelSender As IChannelSender = CType(channel, IChannelSender)

               myMessageSink = myChannelSender.CreateMessageSink(myUrl, Nothing, myObjectURI)
               If Not (myMessageSink Is Nothing) Then
                  Exit For
               End If
            End If
         Next channel
         If myMessageSink Is Nothing Then
            Throw New Exception("A supported channel could not be found for myUrl1:" + myUrl)
         End If
      End Sub 'New

      <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Public Overrides Function Invoke(ByVal myMesg As IMessage) As IMessage
         Console.WriteLine("MyProxy.Invoke Start")

         If TypeOf myMesg Is IMethodCallMessage Then
            Console.WriteLine("IMethodCallMessage")
         End If
         If TypeOf myMesg Is IMethodReturnMessage Then
            Console.WriteLine("IMethodReturnMessage")
         End If

'<Snippet2>
         Console.WriteLine("Message Properties")
         Dim myDictionary As IDictionary = myMesg.Properties
         Dim myEnum As IDictionaryEnumerator = CType(myDictionary.GetEnumerator(), IDictionaryEnumerator)

         While myEnum.MoveNext()
            Dim myKey As Object = myEnum.Key
            Dim myKeyName As String = myKey.ToString()
            Dim myValue As Object = myEnum.Value

            Console.WriteLine( "{0} : {1}", myKeyName, myEnum.Value)
            If myKeyName = "__Args" Then
               Dim myArgs As Object() = CType(myValue, Object())
               Dim myInt As Integer
               For myInt = 0 To myArgs.Length - 1
                  Console.WriteLine(  "arg: {0} myValue: {1}", myInt, myArgs(myInt))
               Next myInt
            End If
            If myKeyName = "__MethodSignature" And Not (myValue Is Nothing) Then
               Dim myArgs As Object() = CType(myValue, Object())
               Dim myInt As Integer
               For myInt = 0 To myArgs.Length - 1
                  Console.WriteLine("arg: {0} myValue: {1}", myInt, myArgs(myInt))
               Next myInt
            End If
         End While

         Console.WriteLine("myUrl1 {0} object URI{1}", myUrl, myObjectURI)

         myDictionary("__Uri") = myUrl
         Console.WriteLine("URI {0}", myDictionary("__URI"))

'</Snippet2>
'<Snippet4>
         Dim myRetMsg As IMessage = myMessageSink.SyncProcessMessage(myMesg)

         If TypeOf (myRetMsg) Is IMethodReturnMessage Then
            Dim myMethodReturnMessage As IMethodReturnMessage = CType(myRetMsg, IMethodReturnMessage)
         End If
'</Snippet4>

         Console.WriteLine("MyProxy.Invoke - Finish")
         Return myRetMsg
      End Function 'Invoke
   End Class 'MyProxy

   '
   ' Main class that drives the whole sample
   '
   Public Class ProxySample
      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         ChannelServices.RegisterChannel(New HttpChannel())

         Console.WriteLine("Remoting Sample:")

         Console.WriteLine("Generate a new MyProxy using the Type")
         Dim myType As Type = GetType(MyHelloService)
         Dim myUrl1 As String = "http://localhost/myServiceAccess.soap"
         Dim myProxy As New MyProxy(myType, myUrl1)

         Console.WriteLine("Obtain the transparent proxy from myProxy")
         Dim myService As MyHelloService = CType(myProxy.GetTransparentProxy(), MyHelloService)

         Console.WriteLine("Calling the Proxy")
         Dim myReturnString As String = myService.myFunction("bill")

         Console.WriteLine("Checking result : {0}", myReturnString)

         If myReturnString = "Hi there bill, you are using .NET Remoting" Then
            Console.WriteLine("myService.HelloMethod PASSED : returned {0}", myReturnString)
         Else
            Console.WriteLine("myService.HelloMethod FAILED : returned {0}", myReturnString)
         End If
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'MyNameSpace
'</Snippet1>
'</Snippet3>