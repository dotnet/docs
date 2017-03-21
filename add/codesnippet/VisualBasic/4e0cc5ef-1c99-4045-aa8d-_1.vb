      Public Overrides Function CreateProxy(objRef1 As ObjRef, serverType As Type, _
                  serverObject As Object, serverContext As Context) As RealProxy
         Dim myCustomProxy As New MyProxy(serverType)
         If Not (serverContext Is Nothing) Then
            RealProxy.SetStubData(myCustomProxy, serverContext)
         End If
         If Not serverType.IsMarshalByRef And serverContext Is Nothing Then
            Throw New RemotingException("Bad Type for CreateProxy")
         End If
         Return myCustomProxy
      End Function 'CreateProxy