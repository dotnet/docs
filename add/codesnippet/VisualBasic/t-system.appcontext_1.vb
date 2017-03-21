Imports System.Reflection

<Assembly: AssemblyVersion("1.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Return fullString.IndexOf(substr, StringComparison.Ordinal)
   End Function
End Class