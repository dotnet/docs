'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Delegate Sub AlarmEventHandler(sender As Object, e As AlarmEventArgs)
   
   Public Class AlarmEventArgs
      Inherits EventArgs
   End Class
   
End Namespace
'</Snippet1>
