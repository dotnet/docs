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
