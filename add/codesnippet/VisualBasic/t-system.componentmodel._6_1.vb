 ' The following code shows how to publish a service using a callback function.

 ' Creates a service creator callback.
 Dim callback1 As New ServiceCreatorCallback _
 (AddressOf myCallBackMethod)
        
 ' Adds the service using its type and the service creator.
 serviceContainer.AddService(GetType(myService), callback1)