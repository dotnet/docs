' Visual Basic .NET Document
Option Strict On

' <Snippet4>
' Define a value type that does not override Equals.
Public Structure Person
   Private personName As String
   
   Public Sub New(name As String)
      Me.personName = name
   End Sub
   
   Public Overrides Function ToString() As String
      Return Me.personName
   End Function 
End Structure

Module Example
   Public Sub Main()
      Dim p1 As New Person("John")
      Dim p2 As New Person("John")
      
      Console.WriteLine("Calling Equals:") 
      Console.WriteLine(p1.Equals(p2))
      Console.WriteLine()
      
      Console.WriteLine("Casting to an Object and calling Equals:")
      Console.WriteLine(CObj(p1).Equals(p2))
   End Sub
End Module
' The example displays the following output:
'       Calling Equals:
'       True
'       
'       Casting to an Object and calling Equals:
'       True
' </Snippet4>
