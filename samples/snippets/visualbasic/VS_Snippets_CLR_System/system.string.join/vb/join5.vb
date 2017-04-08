' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet5>
Imports System.Collections.Generic

Public Class Animal
   Public Kind As String
   Public Order As String
   
   Public Sub New(kind As String, order As String)
      Me.Kind = kind
      Me.Order = order
   End Sub
   
   Public Overrides Function ToString() As String
      Return Me.Kind
   End Function
End Class

Module Example
   Public Sub Main()
      Dim animals As New List(Of Animal)
      animals.Add(New Animal("Squirrel", "Rodent"))
      animals.Add(New Animal("Gray Wolf", "Carnivora"))
      animals.Add(New Animal("Capybara", "Rodent")) 
      Dim output As String = String.Join(" ", animals.Where(Function(animal) _
                                           animal.Order = "Rodent"))
      Console.WriteLine(output)                                           
   End Sub
End Module
' The example displays the following output:
'      Squirrel Capybara
' </Snippet5>
