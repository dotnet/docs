' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Public Class [case]
   Private _id As Guid
   Private name As String  
   
   Public Sub New(name As String)
      _id = Guid.NewGuid()
      Me.name = name 
   End Sub   
        
   Public ReadOnly Property ClientName As String
      Get
         Return name
      End Get
   End Property
End Class
' </Snippet22>
