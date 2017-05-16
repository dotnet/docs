' System.Web.UI.ValidationPropertyAttribute.ValidationPropertyAttribute(string)

' The following example demonstrates the constructor of 'ValidationPropertyAttribute(string)'.
' A custom control is created and ValidationPropertyAttribute is applied 
' to specify a property of the server control that can be validated by any validation control.
 
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace MyControls
' <Snippet1>
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
' </Snippet1>
End Namespace 
