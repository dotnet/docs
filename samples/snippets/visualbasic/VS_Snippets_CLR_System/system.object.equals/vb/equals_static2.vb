' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim m1 As New Dog("Alaskan Malamute")
      Dim m2 As New Dog("Alaskan Malamute")
      Dim g1 As New Dog("Great Pyrenees")
      Dim g2 As Dog = g1
      Dim d1 As New Dog("Dalmation")
      Dim n1 As Dog = Nothing
      Dim n2 As Dog = Nothing
      
      Console.WriteLine("null = null: {0}", Object.Equals(n1, n2))
      Console.WriteLine("null Reference Equals null: {0}", Object.ReferenceEquals(n1, n2))
      Console.WriteLine()
      
      Console.WriteLine("{0} = {1}: {2}", g1, g2, Object.Equals(g1, g2))
      Console.WriteLine("{0} Reference Equals {1}: {2}", g1, g2, Object.ReferenceEquals(g1, g2))
      Console.WriteLine()
      
      Console.WriteLine("{0} = {1}: {2}", m1, m2, Object.Equals(m1, m2))
      Console.WriteLine("{0} Reference Equals {1}: {2}", m1, m2, Object.ReferenceEquals(m1, m2))
      Console.WriteLine()
      
      Console.WriteLine("{0} = {1}: {2}", m1, d1, Object.Equals(m1, d1))  
      Console.WriteLine("{0} Reference Equals {1}: {2}", m1, d1, Object.ReferenceEquals(m1, d1))  
   End Sub
End Module

Public Class Dog
   ' Public field.
   Public Breed As String
   
   ' Class constructor.
   Public Sub New(dogBreed As String)
      Me.Breed = dogBreed
   End Sub

   Public Overrides Function Equals(obj As Object) As Boolean
      If obj Is Nothing OrElse Not typeof obj Is Dog Then
         Return False
      Else
         Return Me.Breed = CType(obj, Dog).Breed
      End If   
   End Function
   
   Public Overrides Function GetHashCode() As Integer
      Return Me.Breed.GetHashCode()
   End Function
   
   Public Overrides Function ToString() As String
      Return Me.Breed
   End Function
End Class
' The example displays the following output:
'       null = null: True
'       null Reference Equals null: True
'       
'       Great Pyrenees = Great Pyrenees: True
'       Great Pyrenees Reference Equals Great Pyrenees: True
'       
'       Alaskan Malamute = Alaskan Malamute: True
'       Alaskan Malamute Reference Equals Alaskan Malamute: False
'       
'       Alaskan Malamute = Dalmation: False
'       Alaskan Malamute Reference Equals Dalmation: False
' </Snippet1>
