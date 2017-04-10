 ' <snippet1>
Imports System
Imports System.Text

' <snippet2>
Public Class SampleObject
   Private stringValue As String = Nothing
   Private intValue As Integer = Integer.MinValue
   
   
   Public Property StringProperty() As String
      Get
         Return Me.stringValue
      End Get 
      Set
         Me.stringValue = value
      End Set
   End Property 
   
   Public Property IntProperty() As Integer
      Get
         Return Me.intValue
      End Get 
      Set
         Me.intValue = value
      End Set
   End Property
End Class 
' </snippet2>
' </snippet1>