' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Public Class Person
   Private _name As String
   
   Public Property Name As String
      Get
         Return _name
      End Get
      Set
         _name = value
      End Set
   End Property
   
   Public Overrides Function Equals(obj As Object) As Boolean
      ' This implementation handles a null obj argument.
      Dim p As Person = TryCast(obj, Person)
      If p Is Nothing Then 
         Return False
      Else
         Return Me.Name.Equals(p.Name)
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      Dim p1 As New Person()
      p1.Name = "John"
      Dim p2 As Person = Nothing
      
      Console.WriteLine("p1 = p2: {0}", p1.Equals(p2))   
   End Sub
End Module
' The example displays the following output:
'       p1 = p2: False
' </Snippet5>
