' System.Runtime.Remoting.Messaging.IMethodMessage
' System.Runtime.Remoting.Messaging.IMethodMessage.MethodName
' System.Runtime.Remoting.Messaging.IMethodMessage.ArgCount
' System.Runtime.Remoting.Messaging.IMethodMessage.GetArgName
' System.Runtime.Remoting.Messaging.IMethodMessage.GetArg
' System.Runtime.Remoting.Messaging.IMethodMessage.HasVarArgs
' System.Runtime.Remoting.Messaging.IMethodMessage.Args

' The following program demonstrates the 'MethodName', 'ArgCount', 'HasVarArgs',
' 'Args' properties, 'GetArgName', 'GetArg' methods of 'IMethodMessage' interface and
' 'IMethodMessage' interface.
' In this example custom proxy is accessed by passing message to the Invoke method.
' The Invoke method calls the methods and properties of 'IMethodMessage' interface
' and displays the result to the console.

Imports System
Imports System.Reflection
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions
Imports MicroSoft.VisualBasic

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class Reverser
   Inherits MarshalByRefObject
   Private stringReversed As String
   
   Public Function GetReversedString() As String
      Return stringReversed
   End Function 'GetReversedString
   
   Public Sub SetString(temp As String)
      DoReverse(temp)
   End Sub 'SetString
   
   ' Exposed reverse as a method to reverse a string.
   Private Sub DoReverse(argString As String)
      stringReversed = ""
      Dim i As Integer
      For i = argString.Length - 1 To 0 Step -1
         stringReversed += argString.Chars(i)
      Next i
   End Sub 'DoReverse
End Class 'Reverser

' <Snippet1>
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class MyProxyClass
   Inherits RealProxy
   Private myObjectInstance As Object = Nothing
   Private myType As Type = Nothing
   
   Public Sub New(argType As Type)
      MyBase.New(argType)
      myType = argType
      myObjectInstance = Activator.CreateInstance(argType)
   End Sub 'New
   
' <Snippet2>
   ' Overriding the Invoke method of RealProxy.
   Public Overrides Function Invoke(message As IMessage) As IMessage
      Dim myMethodMessage As IMethodMessage = CType(message, IMethodMessage)
      
      Console.WriteLine("**** Begin Invoke ****")
      Console.WriteLine(ControlChars.Tab + "Type is : " + myType.ToString())
      Console.WriteLine(ControlChars.Tab + "Method name : " + myMethodMessage.MethodName)
      
      Dim i As Integer
      For i = 0 To myMethodMessage.ArgCount - 1
         Console.WriteLine(ControlChars.Tab + "ArgName is : " + myMethodMessage.GetArgName(i))
         Console.WriteLine(ControlChars.Tab + "ArgValue is: " + myMethodMessage.GetArg(i))
      Next i
      
      If myMethodMessage.HasVarArgs Then
         Console.WriteLine(ControlChars.Tab + " The method have variable arguments!!")
      Else
         Console.WriteLine(ControlChars.Tab + " The method does not have variable arguments!!")
      End If 
      ' Dispatch the method call to the real object.
      Dim returnValue As Object = myType.InvokeMember(myMethodMessage.MethodName, _
                     BindingFlags.InvokeMethod, Nothing, myObjectInstance, myMethodMessage.Args)
      Console.WriteLine("**** End Invoke ****")
      
      ' Build the return message to pass back to the transparent proxy.
      Dim myReturnMessage As New ReturnMessage(returnValue, Nothing, 0, Nothing, _
                                                         CType(message, IMethodCallMessage))
      Return myReturnMessage
   End Function 'Invoke
' </Snippet2>
End Class 'MyProxyClass
' </Snippet1>

Public Class ApplicationClass
<SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Dim myProxy As New MyProxyClass(GetType(Reverser))
      
      ' The real proxy dynamically creates a transparent proxy.
      Dim myReverser As Reverser = CType(myProxy.GetTransparentProxy(), Reverser)
      
      myReverser.SetString("Hello World!")
      Console.WriteLine("The out result is : {0}", myReverser.GetReversedString())
   End Sub 'Main
End Class 'ApplicationClass