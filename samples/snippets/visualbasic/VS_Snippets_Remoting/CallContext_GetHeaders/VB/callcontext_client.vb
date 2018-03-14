' System.Runtime.Remoting.CallContext.FreeNamedDataSlot(string)
' System.Runtime.Remoting.CallContext.GetHeaders()
' System.Runtime.Remoting.CallContext.SetHeaders(Header[])

' The following example demonstrates 'FreeNamedDataSlot','GetHeaders',
' and 'SetHeaders' methods of 'CallContext' class. 
'
' In the example 'SetData' method is used to set dataSlot. The 'DataSlot' is freed using 
' 'FreeNamedDataSlot' method by passing the Name parameter.
' For Setting header an array of type 'Messaging.Header' is passed with method call. 
' Headers are set in 'HeaderMethod' of remote object using 'SetHeaders' method.
' Finally the 'GetHeaders' method is used to get all headers.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Contexts
Imports System.Security
Imports System.Security.Principal

Namespace RemotingSamples

   Class HelloClient
      
      Shared Sub Main()
' <Snippet1>
         ' Register the channel.
         Dim myChannel As New TcpChannel()
         ChannelServices.RegisterChannel(myChannel)
         RemotingConfiguration.RegisterActivatedClientType(GetType(HelloService), "Tcp://localhost:8082")


         Dim myIdentity As New GenericIdentity("Bob")
         Dim myPrincipal As New GenericPrincipal(myIdentity, New String() {"Level1"})
         Dim myData As New MyLogicalCallContextData(myPrincipal)

         ' Set DataSlot with name parameter.
         CallContext.SetData("test data", myData)

         ' Create a remote object.
         Dim myService As New HelloService()
         If myService Is Nothing Then
            Console.WriteLine("Cannot locate server.")
            return
         End If

         ' Call the Remote methods.
         Console.WriteLine("Remote method output is " + myService.HelloMethod("Microsoft"))

         Dim myReturnData As MyLogicalCallContextData = _
                           CType(CallContext.GetData("test data"), MyLogicalCallContextData)

         If myReturnData Is Nothing Then
            Console.WriteLine("Data is null.")
         Else
            Console.WriteLine("Data is '{0}'", myReturnData.numOfAccesses)
         End If 

         ' DataSlot with same Name Parameter which was Set is Freed.
         CallContext.FreeNamedDataSlot("test data")
         Dim myReturnData1 As MyLogicalCallContextData = _
                           CType(CallContext.GetData("test data"), MyLogicalCallContextData)

         If myReturnData1 Is Nothing Then
            Console.WriteLine("FreeNamedDataSlot Successful for test data")
         Else
            Console.WriteLine("FreeNamedDataSlot Failed  for test data")
         End If 
' </Snippet1>

' <Snippet2>
         ' Array of Headers with name and values initialized.
         Dim myArrSetHeader As Header() =  {New Header("Header0", "CallContextHeader0"), _
                                                   New Header("Header1", "CallContextHeader1")}

         ' Pass the Header Array with method call.
         ' Header will be set in the method by'CallContext.SetHeaders' method in remote object.

         Console.WriteLine("Remote HeaderMethod output is " _
                              + myService.HeaderMethod("CallContextHeader", myArrSetHeader))

         Dim myArrGetHeader() As Header
         ' Get Header Array.

         myArrGetHeader = CallContext.GetHeaders()
         If myArrGetHeader Is Nothing Then
            Console.WriteLine("CallContext.GetHeaders Failed")
         Else
            Console.WriteLine("Headers:")
         End If

         Dim myHeader As Header
         For each myHeader in myArrGetHeader
            Console.WriteLine("Value in Header '{0}' is '{1}'.",myHeader.Name,myHeader.Value)
         Next
' </Snippet2>
      End Sub 'Main 
   End Class 'HelloClient
End Namespace 'RemotingSamples