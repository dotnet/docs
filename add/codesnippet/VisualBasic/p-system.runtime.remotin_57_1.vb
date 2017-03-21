Public Class MyProxy
   Inherits RealProxy

   Private stringUri As String
   Private targetObject As MarshalByRefObject

   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Sub New(type As Type)
      MyBase.New(type)
      targetObject = CType(Activator.CreateInstance(type), MarshalByRefObject)
      Dim myObject As ObjRef = RemotingServices.Marshal(targetObject)
      stringUri = myObject.URI
   End Sub 'New

<SecurityPermission(SecurityAction.LinkDemand)> _
   Public Sub New(type As Type, targetObject As MarshalByRefObject)
      MyBase.New(type)
      Me.targetObject = targetObject
   End Sub 'New


<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.Infrastructure)> _
   Public Overrides Function Invoke(message As IMessage) As IMessage
      message.Properties("__Uri") = stringUri
      Dim myMethodMessage As IMethodMessage = _
            CType(ChannelServices.SyncDispatchMessage(message), IMethodMessage)
      Console.WriteLine("---------IMethodMessage example-------")
      Console.WriteLine("Method name : " + myMethodMessage.MethodName)
      Console.WriteLine("LogicalCallContext has information : " + _
            myMethodMessage.LogicalCallContext.HasInfo.ToString())
      Console.WriteLine("Uri : " + myMethodMessage.Uri)
      Return myMethodMessage
   End Function 'Invoke

End Class 'MyProxy