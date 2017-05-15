'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Class History
   
      Sub AddToHistory(uriString As String)
          Dim newUri As New Uri(uriString)
          AddToHistory(newUri)
      End Sub

      Sub AddToHistory(uriType As Uri)
      End Sub

   End Class

End Namespace
'</Snippet1>
