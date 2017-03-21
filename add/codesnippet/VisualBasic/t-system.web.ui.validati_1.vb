   <ValidationPropertyAttribute("Message")> Public Class MessageControl
      Inherits Label
      Private _message As Integer = 0

      Public Property Message() As Integer
         Get
            Return _message
         End Get
         Set(ByVal Value As Integer)
            _message = Value
         End Set
      End Property
   End Class 