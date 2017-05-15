' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim persons() As Person = Person.AddRange( { "Abigail", "Abra",
                                                   "Abraham", "Adrian",
                                                   "Ariella", "Arnold", 
                                                   "Aston", "Astor" } )    
      Dim nameToFind As String = "Robert"
      Dim found As Person = Array.Find(persons, Function(p) p.FirstName = nameToFind)
      Console.WriteLine(found.FirstName)
   End Sub
End Module

Public Class Person
   Public Shared Function AddRange(firstNames() As String) As Person()
      Dim p(firstNames.Length - 1) As Person
      For ctr As Integer = 0 To firstNames.Length - 1
         p(ctr) = New Person(firstNames(ctr))
      Next   
      Return p
   End Function
   
   Public Sub New(firstName As String)
      Me.FirstName = firstName
   End Sub 
   
   Public FirstName As String
End Class
' The example displays the following output:
'       Unhandled Exception: System.NullReferenceException: 
'       Object reference not set to an instance of an object.
'          at Example.Main()
' </Snippet4>