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
End Class 'MyProxyClass