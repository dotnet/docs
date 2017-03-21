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