<Serializable()> Public Class LogicalCallContextData
   Implements ILogicalThreadAffinative

   Private _nAccesses As Integer
   Private _principal As IPrincipal
   
   
   Public ReadOnly Property numOfAccesses() As String
      Get
         Return [String].Format("The identity of {0} has been accessed {1} times.", _principal.Identity.Name, _nAccesses)
      End Get
   End Property
   
   
   Public ReadOnly Property Principal() As IPrincipal
      Get
         _nAccesses += 1
         Return _principal
      End Get
   End Property
   
   
   Public Sub New(p As IPrincipal)
      _nAccesses = 0
      _principal = p
   End Sub 'New

End Class 'LogicalCallContextData