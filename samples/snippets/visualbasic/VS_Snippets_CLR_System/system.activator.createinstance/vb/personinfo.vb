' Visual Basic .NET Document
Option Strict On

' <Snippet1> 
Public Class Person
   Private _name As String
   
   Public Sub New()
   End Sub
   
   Public Sub New(name As String)
      Me._name = name
   End Sub
   
   Public Property Name As String
      Get
         Return Me._name
      End Get
      Set
         Me._name = value
      End Set
   End Property
   
   Public Overrides Function ToString() As String
      Return Me._name
   End Function
End Class
' </Snippet1>

