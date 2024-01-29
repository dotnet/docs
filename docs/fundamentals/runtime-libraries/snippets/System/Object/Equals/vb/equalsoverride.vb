' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Public Class Person
   Private idNumber As String
   Private personName As String
   
   Public Sub New(name As String, id As String)
      Me.personName = name
      Me.idNumber = id
   End Sub
   
   Public Overrides Function Equals(obj As Object) As Boolean
      Dim personObj As Person = TryCast(obj, Person) 
      If personObj Is Nothing Then
         Return False
      Else
         Return idNumber.Equals(personObj.idNumber)
      End If   
   End Function
   
   Public Overrides Function GetHashCode() As Integer
      Return Me.idNumber.GetHashCode() 
   End Function
End Class

Module Example6
    Public Sub Main()
        Dim p1 As New Person("John", "63412895")
        Dim p2 As New Person("Jack", "63412895")
        Console.WriteLine(p1.Equals(p2))
        Console.WriteLine(Object.Equals(p1, p2))
    End Sub
End Module
' The example displays the following output:
'       True
'       True
' </Snippet6>
