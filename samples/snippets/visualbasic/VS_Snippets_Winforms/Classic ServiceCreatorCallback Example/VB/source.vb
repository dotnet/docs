Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class Sample   
    
    Public Sub SampleMethod()
        
        Dim serviceContainer As New ServiceContainer()

' <Snippet1>
 ' The following code shows how to publish a service using a callback function.

 ' Creates a service creator callback.
 Dim callback1 As New ServiceCreatorCallback _
 (AddressOf myCallBackMethod)
        
 ' Adds the service using its type and the service creator.
 serviceContainer.AddService(GetType(myService), callback1)
' </Snippet1>
    End Sub

    ' Method added so class will compile
    Public Function myCallBackMethod _
    (container As IServiceContainer, serviceType As Type) As Object
        Return New Object()
    End Function

End Class

' Class added so sample will compile
Public Class myService
End Class
