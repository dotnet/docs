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