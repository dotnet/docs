' <snippet5>
' Create a custom control with two properties named Text and 
' FontSize that get their values from and set their values
' to the control's ViewState property.
Imports System
Imports System.Web.UI
Imports System.Collections
Imports System.Web.UI.WebControls


Namespace ViewStateSamples1

Public Class ctlViewState1
   Inherits Control
   
   Public Property Text() As String
      Get
         Return CType(ViewState("Text"), String)
      End Get
      Set
         ViewState("Text") = value
      End Set
   End Property
   
   
   Public Property FontSize() As Integer
      Get
         Return CType(ViewState("FontSize"), Integer)
      End Get
      Set
         ViewState("FontSize") = value
      End Set
   End Property
   
   ' Because the Control.ViewState property is modified by the protected
   ' keyword, this GetState function is required here so that the page
   ' that contains this control can access the control's
   ' view state. 
   Public Function GetState() As StateBag
      Return CType(ViewState, StateBag)
   End Function 'GetState
End Class 'ctlViewState1

End Namespace

' </snippet5>

