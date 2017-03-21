   <SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure), _
   AttributeUsage(AttributeTargets.Class)>  _
   Public Class MyProxyAttribute
      Inherits ProxyAttribute

      Public Sub New()
      End Sub 'New

      ' Create an instance of ServicedComponentProxy
      Public Overrides Function CreateInstance(serverType As Type) As MarshalByRefObject
         Return MyBase.CreateInstance(serverType)
      End Function 'CreateInstance

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
   End Class 'MyProxyAttribute

   <MyProxyAttribute()> _
   Public Class CustomServer
      Inherits ContextBoundObject

      Public Sub New()
         Console.WriteLine("CustomServer Base Class constructor called")
      End Sub 'New

      Public Sub HelloMethod(str As String)
         Console.WriteLine("HelloMethod of Server is invoked with message : " + str)
      End Sub 'HelloMethod
   End Class 'CustomServer