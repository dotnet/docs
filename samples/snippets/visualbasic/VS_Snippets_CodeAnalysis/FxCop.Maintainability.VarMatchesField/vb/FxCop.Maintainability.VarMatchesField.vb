'<Snippet1>
Imports System

Namespace MaintainabilityLibrary

   Class MatchingNames
   
      Dim someField As Integer
   
      Sub SomeMethodOne(someField As Integer)
      End Sub
      
      Sub SomeMethodTwo()
         Dim someField As Integer
      End Sub
      
   End Class
   
End Namespace
'</Snippet1>
