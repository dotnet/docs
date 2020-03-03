'<Snippet1>
Imports System.IO
  
Namespace DesignLibrary

   ' This class violates the rule.
   Public Class NoDisposeMethod
   
      Dim newFile As FileStream

      Sub New()
         newFile = New FileStream("c:\temp.txt", FileMode.Open)
      End Sub

   End Class

   ' This class satisfies the rule.
   Public Class HasDisposeMethod 
      Implements IDisposable
   
      Dim newFile As FileStream

      Sub New()
         newFile = New FileStream("c:\temp.txt", FileMode.Open)
      End Sub

      Overloads Protected Overridable Sub Dispose(disposing As Boolean)

         If disposing Then
            ' dispose managed resources
            newFile.Close()
         End If

         ' free native resources

      End Sub
     
      
      Overloads Public Sub Dispose() Implements IDisposable.Dispose

         Dispose(True)
         GC.SuppressFinalize(Me)

      End Sub
    
   End Class

End Namespace
'</Snippet1>
