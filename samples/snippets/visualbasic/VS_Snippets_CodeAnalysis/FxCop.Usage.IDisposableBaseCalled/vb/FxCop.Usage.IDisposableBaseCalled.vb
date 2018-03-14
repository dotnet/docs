'<Snippet1>
Imports System

Namespace UsageLibrary

  Public Class TypeB
      Inherits TypeA
   
      Protected Overrides Sub Finalize()
          Try
              Dispose(False)
          Finally
              MyBase.Finalize()
          End Try
      End Sub
   
  End Class
  
End Namespace
'</Snippet1>
Namespace UsageLibrary

    Public Class TypeA
        Friend Overridable Sub Dispose(ByVal disposing As Boolean)
            Dispose(False)
        End Sub
    End Class

End Namespace
