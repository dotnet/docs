' Visual Basic .NET Document
Option Strict On

' <Snippet4>
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
      ' This implementation contains an error in program logic:
      ' It assumes that the obj argument is not null.
      Dim p As Person = CType(obj, Person)
      Return Me.Name.Equals(p.Name)
   End Function
End Class

Module Example2
    Public Sub Main()
        Dim p1 As New Person()
        p1.Name = "John"
        Dim p2 As Person = Nothing

        ' The following throws a NullReferenceException.
        Console.WriteLine("p1 = p2: {0}", p1.Equals(p2))
    End Sub
End Module
' </Snippet4>
