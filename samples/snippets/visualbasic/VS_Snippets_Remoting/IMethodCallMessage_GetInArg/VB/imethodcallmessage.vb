' System.Runtime.Remoting.IMethodCallMessage
' System.Runtime.Remoting.IMethodCallMessage.InArgCount
' System.Runtime.Remoting.IMethodCallMessage.InArgs
' System.Runtime.Remoting.IMethodCallMessage.GetArgName(Integer)
' System.Runtime.Remoting.IMethodCallMessage.GetInArg(Integer)

' The following example demonstrates 'GetInArg', 'GetArgName', 'InArgCount' and 'InArgs' 
' members of 'IMethodCallMessage' interface.
' In this example custom proxy is accessed by passing message to the Invoke method.  
' In invoke method check the type of message. If the type is IMethodCallMessage, 
' then InArgCount,InArgs,GetArgName(int) and GetInArg(int) of the interface are displayed.
' This example also shows how to create a custom proxy.


' <Snippet1>
Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

Namespace IMethodCallMessageNS

   ' MyProxy extends the CLR Remoting RealProxy.
   ' In the same class, in the Invoke method, we demonstrate the
   ' methods and properties of the IMethodCallMessage.

   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyProxy
      Inherits RealProxy

      Public Sub New(ByVal myType As Type)
         ' This constructor forwards the call to base RealProxy.
         ' RealProxy uses the Type to generate a transparent proxy.
         MyBase.New(myType)
      End Sub 'New

' <Snippet2>
      Public Overrides Function Invoke(ByVal myIMessage As IMessage) As IMessage
         Console.WriteLine("MyProxy.Invoke Start")
         Console.WriteLine("")

         If TypeOf myIMessage Is IMethodCallMessage Then
            Console.WriteLine("Message is of type 'IMethodCallMessage'.")
            Console.WriteLine("")

            Dim myIMethodCallMessage As IMethodCallMessage
            myIMethodCallMessage = CType(myIMessage, IMethodCallMessage)

            Console.WriteLine("InArgCount is : " + myIMethodCallMessage.InArgCount.ToString)
            Dim myObj As Object
            For Each myObj In myIMethodCallMessage.InArgs
               Console.WriteLine("InArgs is : " + myObj.ToString())
            Next

            Dim i As Integer
            For i = 0 To myIMethodCallMessage.InArgCount - 1
               Console.WriteLine("GetArgName(" + i.ToString() + ") is : " + myIMethodCallMessage.GetArgName(i))
               Console.WriteLine("GetInArg(" + i.ToString() + ") is : " + myIMethodCallMessage.GetInArg(i).ToString)
            Next i

            Console.WriteLine("")
         ElseIf TypeOf myIMessage Is IMethodReturnMessage Then
            Console.WriteLine("Message is of type 'IMethodReturnMessage'.")
         End If

         ' Build Return Message
         Dim myReturnMessage As New ReturnMessage(5, Nothing, 0, Nothing, _
                                    CType(myIMessage, IMethodCallMessage))

         Console.WriteLine("MyProxy.Invoke - Finish")
         Return myReturnMessage

      End Function 'Invoke



   End Class 'MyProxy

   ' The class used to obtain Metadata.
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class MyMarshalByRefClass
      Inherits MarshalByRefObject

      Public Function MyMethod(ByVal str As String, ByVal dbl As Double, ByVal i As Integer) As Integer
         Console.WriteLine("MyMarshalByRefClass.MyMethod {0} {1} {2}", str, dbl, i)
         Return 0
      End Function 'MyMethod
   End Class 'MyMarshalByRefClass

' </Snippet2>
   ' Main class that drives the whole sample.
   Public Class ProxySample

      <SecurityPermission(SecurityAction.LinkDemand)> _
      Shared Sub Main()
         Console.WriteLine("Generate a new MyProxy.")
         Dim myProxy As New MyProxy(GetType(MyMarshalByRefClass))

         Console.WriteLine("Obtain the transparent proxy from myProxy.")
         Dim myMarshalByRefClassObj As MyMarshalByRefClass = _
                        CType(myProxy.GetTransparentProxy(), MyMarshalByRefClass)

         Console.WriteLine("Calling the Proxy.")
         Dim myReturnValue As Object = myMarshalByRefClassObj.MyMethod("Microsoft", 1.2, 6)

         Console.WriteLine("Sample Done.")
      End Sub 'Main
   End Class 'ProxySample
End Namespace 'IMethodCallMessageNS
' </Snippet1>