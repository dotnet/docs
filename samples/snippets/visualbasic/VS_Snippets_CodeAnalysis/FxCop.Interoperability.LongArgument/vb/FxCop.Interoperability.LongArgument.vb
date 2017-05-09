'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(False)>
Namespace InteroperabilityLibrary

   <ComVisibleAttribute(True)> _ 
   Public Class SomeClass

      Public Sub LongArgument(argument As Long)
      End Sub

   End Class

End Namespace
'</Snippet1>
